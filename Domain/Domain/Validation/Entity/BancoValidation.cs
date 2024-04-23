using Domain.DTO;
using Domain.Entity;
using FluentValidation;

namespace Domain.Validation.Entity;

public class BancoValidation : AbstractValidator<Banco>
{
    public BancoValidation()
    {
        RuleFor(banco => banco.Nome)
            .NotEmpty().WithMessage("O nome do banco é obrigatório")
            .NotNull().WithMessage("O nome do banco não pode ser nulo");

        RuleFor(banco => banco.Codigo)
            .NotEqual(0).WithMessage("O código do banco é obrigatório");

        RuleFor(banco => banco.PercentualJuros)
            .NotEqual(0).WithMessage("A porcentagem de juros do banco é obrigatória");
    }
}
