using FluentValidation;
using ToDo.List.Domain.Models;

namespace ToDo.List.Domain;

public class TarefaValidator : AbstractValidator<Tarefa>
{
    public TarefaValidator()
    {
        RuleFor(t => t.Titulo)
            .NotEmpty().WithMessage("O título é obrigatório.")
            .MaximumLength(100).WithMessage("O título não pode ter mais de 100 caracteres.");

        RuleFor(t => t.Descricao)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(255).WithMessage("A descrição não pode ter mais de 255 caracteres.");

        RuleFor(t => t.DataCriacao)
            .NotEmpty().WithMessage("A data de criação é obrigatória.");

        RuleFor(t => t.DataConclusao)
            .GreaterThanOrEqualTo(t => t.DataCriacao).WithMessage("A data de conclusão não pode ser anterior à data de criação.");

        RuleFor(t => t.AccountId)
            .NotEmpty().WithMessage("O ID do usuário é obrigatório.");
    }
}