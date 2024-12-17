namespace ToDo.List.Domain.DTOs;

public class AccountRequestDTO
{
    public AccountRequestDTO() { }

    public AccountRequestDTO(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
