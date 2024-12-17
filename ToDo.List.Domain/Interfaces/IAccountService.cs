using ToDo.List.Domain.DTOs;

namespace ToDo.List.Domain.Interfaces;

public interface IAccountService
{
    Task<string> CriarConta(AccountRequestDTO conta);
    Task<string> Login(LoginRequestDTO request);
}
