using AutoMapper;
using ToDo.List.Domain.Domain;
using ToDo.List.Domain.DTOs;
using ToDo.List.Domain.Interfaces;

namespace ToDo.List.Domain.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    public AccountService(IAccountRepository accountRepository,
                          ITokenService tokenService,
                          IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _tokenService = tokenService;
    }


    public async Task<string> CriarConta(AccountRequestDTO accountDTO)
    {
        var accountExists = await _accountRepository.BuscarContaPorEmail(accountDTO.Email);

        if (accountExists != null)
            return "";

        var account = _mapper.Map<Account>(accountDTO);
        await _accountRepository.CriarConta(account);

        var token = await _tokenService.GenerateToken(account.Email, account.Id.ToString());
        return token;
    }

    public async Task<string> Login(LoginRequestDTO request)
    {
        var account = await _accountRepository.BuscarContaPorEmail(request.Email);

        if (account == null)
            return "";

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Senha, account.Senha);

        if (!passwordValid)
            return "";

        var token = await _tokenService.GenerateToken(account.Email, account.Id.ToString());
        return token;
    }
}
