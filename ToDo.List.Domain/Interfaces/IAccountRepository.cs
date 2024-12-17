using ToDo.List.Domain.Domain;

namespace ToDo.List.Domain.Interfaces;

public interface IAccountRepository
{
    Task CriarConta(Account account);
    Task<Account> BuscarContaPorEmail(string email);
}