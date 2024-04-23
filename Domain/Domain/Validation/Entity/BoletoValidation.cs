using Domain.Entity;
using Domain.Validation.ValueObject;
using Domain.ValueObject;
using FluentValidation;

namespace Domain.Validation.Entity;

public class BoletoValidation : AbstractValidator<Boleto>
{
    public BoletoValidation()
    {
        RuleFor(boleto => boleto.NomePagador)
            .NotEmpty().WithMessage("O nome do pagador é obrigatório.")
            .NotNull().WithMessage("O nome do pagador não pode ser nulo.");

        RuleFor(boleto => boleto.CpfCnpjPagador)
            .NotEmpty().WithMessage("O CPF/CNPJ do pagador é obrigatório.")
            .NotNull().WithMessage("O CPF/CNPJ do pagador não pode ser nulo.")
            .SetValidator(new CpfCnpjValidation());

        RuleFor(boleto => boleto.NomeBeneficiario)
            .NotEmpty().WithMessage("O nome do beneficiário é obrigatório.")
            .NotNull().WithMessage("O nome do beneficiário não pode ser nulo.");

        RuleFor(boleto => boleto.CpfCnpjBeneficiario)
            .NotEmpty().WithMessage("O CPF/CNPJ do beneficiário é obrigatório.")
            .NotNull().WithMessage("O CPF/CNPJ do beneficiário não pode ser nulo.")
            .SetValidator(new CpfCnpjValidation());

        RuleFor(boleto => boleto.Valor)
            .NotEqual(0).WithMessage("O valor do boleto é obrigatório.");

        RuleFor(boleto => boleto.DataVencimento)
            .NotNull().WithMessage("A data de vencimento do boleto é obrigatória.");

        RuleFor(boleto => boleto.BancoId)
            .NotEqual(0).WithMessage("O ID do banco é obrigatório.");
    }
}
