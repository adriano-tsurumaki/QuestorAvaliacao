using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validation.ValueObject;

public class CpfValidation : AbstractValidator<Cpf>
{
    public CpfValidation()
    {
        RuleFor(x => x.Valido).Equal(true).WithMessage("Cpf inválido");
    }
}
