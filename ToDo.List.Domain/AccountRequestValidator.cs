using FluentValidation;
using System.Text.RegularExpressions;
using ToDo.List.Domain.DTOs;

namespace ToDo.List.Domain;

public class AccountRequestValidator : AbstractValidator<AccountRequestDTO>
{
    public AccountRequestValidator()
    {
        RuleFor(x => x.Nome)
            .Must(nome => ValidaNome(nome)).WithMessage("Nome inválido")
            .MinimumLength(3).WithMessage("Nome deve ter no minimo 3 caracteres")
            .MaximumLength(200).WithMessage("Nome deve ter no maximo 200 caracteres")
            .NotEmpty().WithMessage("Nome deve ter no minimo 3 caracteres")
            .NotNull().WithMessage("Nome deve ter no minimo 3 caracteres")
            .OverridePropertyName("NomeCompleto")
            .WithErrorCode("1");

        RuleFor(x => x.Email)
            .MinimumLength(8).WithMessage("Email deve ter no minimo 8 caracteres")
            .MaximumLength(200).WithMessage("Email deve ter no maximo 200 caracteres")
            .NotEmpty().WithMessage("Email deve ser preenchido")
            .NotNull().WithMessage("Email deve ser preenchido")
            .Must(p => Regex.IsMatch(p, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                .WithMessage("Email está com o formato incorreto")
            .OverridePropertyName("Email")
            .WithErrorCode("3");

        RuleFor(x => x.Senha)
            .MinimumLength(8).WithMessage("Senha deve ter no minimo 8 caracteres")
            .MaximumLength(100).WithMessage("Senha deve ter no maximo 100 caracteres")
            .NotEmpty().WithMessage("Senha deve ser preenchida")
            .NotNull().WithMessage("Senha deve ser preenchida")
            .Must(p => Regex.IsMatch(p, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).{6,}$"))
                .WithMessage("Senha deve ter letras maiusculas, minusculas e numeros")
            .OverridePropertyName("Senha")
            .WithErrorCode("5");
    }

    private bool ValidaNome(string nome)
    => nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
}
