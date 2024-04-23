using System;
using Domain.ValueObject;

namespace Domain.Entity;
public class Boleto
{
    public int Id { get; set; }
    public string NomePagador { get; set; }
    public CpfCnpj CpfCnpjPagador { get; set; }
    public string NomeBeneficiario { get; set; }
    public CpfCnpj CpfCnpjBeneficiario { get; set; }
    public float Valor { get; set; }
    public DateTime DataVencimento { get; set; }
    public string Observacao { get; set; }
    public int BancoId { get; set; }
    public Banco Banco { get; set; }
}
