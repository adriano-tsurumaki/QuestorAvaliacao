using System.Collections.Generic;

namespace Domain.Entity;

public class Banco
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public float PercentualJuros { get; set; }
    public IList<Boleto> ListBoleto { get; set; }
}
