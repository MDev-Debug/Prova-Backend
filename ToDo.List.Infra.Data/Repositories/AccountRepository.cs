using Microsoft.EntityFrameworkCore;
using ToDo.List.Domain.Domain;
using ToDo.List.Domain.Interfaces;
using ToDo.List.Infra.Data.Data;

namespace ToDo.List.Infra.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ToDoListDbContext _context;

    public AccountRepository(ToDoListDbContext context)
    {
        _context = context;
    }

    public async Task<Account> BuscarContaPorEmail(string email)
    {
        var account = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        return account;
    }

    public async Task CriarConta(Account account)
    {
        await _context.Usuarios.AddAsync(account);
        await _context.SaveChangesAsync();
    }
}
