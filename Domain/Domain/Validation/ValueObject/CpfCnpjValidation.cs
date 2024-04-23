using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validation.ValueObject;

public class CpfCnpjValidation : AbstractValidator<CpfCnpj>
{
    public CpfCnpjValidation()
    {
        RuleFor(x => x.Valido).Equal(true).WithMessage("Formatação para Cpf ou Cnpj inválido");
    }
}
