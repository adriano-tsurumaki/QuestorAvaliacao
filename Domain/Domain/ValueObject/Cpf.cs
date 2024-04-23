using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Domain.ValueObject;

public readonly partial struct Cpf
{
    private readonly bool _valido;
    private readonly string _valor;
    private readonly string _formatado;

    public Cpf(string valor)
    {
        _valor = !string.IsNullOrWhiteSpace(valor)
            ? RetornarSomenterNumeros(valor)
            : null;

        _valido = Validar(valor);

        _formatado = _valido
            ? Convert.ToInt64(_valor).ToString(@"000\.000\.000\-00")
            : string.Empty;
    }

    public string Formatado
    {
        get => _formatado;
    }

    public bool Valido
    {
        get => _valido;
    }

    private bool Validar(string valor)
    {

        if (string.IsNullOrWhiteSpace(_valor) || _valor.Length != 11 || _valor.Distinct().Count() == 1)
        {
            return false;
        }

        int[] multiplicador1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] multiplicador2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

        int soma1 = 0;
        int soma2 = 0;

        string tempCpf = _valor[..10];

        for (int i = 0; i < 10; i++)
        {
            if (i < 9)
            {
                soma1 += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        }

        int resto1 = ObterResto(soma1);
        int resto2 = ObterResto(soma2);

        if (resto1.ToString() != _valor[9].ToString() || resto2.ToString() != _valor[10].ToString())
        {
            return false;
        }

        return true;
    }

    private static int ObterResto(int soma)
    {
        int resto = soma * 10 % 11;

        if (resto == 10)
        {
            return 0;
        }

        return resto;
    }

    private static string RetornarSomenterNumeros(string valor) =>
        string.Join("", Formatacao().Matches(valor).Select(x => x.Value));

    public override readonly string ToString() => _valor;
    [GeneratedRegex(@"\d+")]
    private static partial Regex Formatacao();

    public static implicit operator Cpf(string valor) => new(valor);
}
