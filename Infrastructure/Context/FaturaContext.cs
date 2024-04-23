using Domain.Entity;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class FaturaContext(DbContextOptions<FaturaContext> op) : DbContext(op)
{
    public DbSet<Banco> Banco { get; set; }
    public DbSet<Boleto> Boleto { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Boleto>()
            .Property(b => b.CpfCnpjBeneficiario)
            .HasConversion(v => v.ToString(),
                v => new CpfCnpj(v));

        modelBuilder.Entity<Boleto>()
            .Property(b => b.CpfCnpjPagador)
            .HasConversion(v => v.ToString(),
                v => new CpfCnpj(v));
    }
}
