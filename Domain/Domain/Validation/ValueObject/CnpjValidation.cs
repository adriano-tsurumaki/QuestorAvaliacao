using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validation.ValueObject;

public class CnpjValidation : AbstractValidator<Cnpj>
{
    public CnpjValidation()
    {
        RuleFor(x => x.Valido).Equal(true).WithMessage("Cnpj inválido");
    }
}
