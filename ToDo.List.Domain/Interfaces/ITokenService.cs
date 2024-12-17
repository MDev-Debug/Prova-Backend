namespace ToDo.List.Domain.Interfaces;

public interface ITokenService
{
    Task<string> GenerateToken(string email, string idUsuario);
}
