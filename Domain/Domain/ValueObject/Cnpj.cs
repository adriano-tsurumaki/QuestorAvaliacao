using System.Linq;
using System.Text.RegularExpressions;
using System;

namespace Domain.ValueObject;

public readonly partial struct Cnpj
{
    private readonly bool _valido;
    private readonly string _valor;
    private readonly string _formatado;

    public Cnpj(string valor)
    {
        _valor = !string.IsNullOrWhiteSpace(valor)
            ? RetornarSomenterNumeros(valor)
            : null;

        _valido = Validar(valor);

        _formatado = _valido
            ? Convert.ToInt64(_valor).ToString(@"00\.000\.000\/0000\-00")
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
        if (string.IsNullOrWhiteSpace(valor) || valor.Length != 14 || valor.Distinct().Count() == 1)
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

        int resto = soma1 % 11;

        if (((resto == 0 || resto == 1) && _valor[12] != '0') || (11 - resto).ToString() != _valor[12].ToString())
        {
            return false;
        }

        resto = soma2 % 11;

        if (((resto == 0 || resto == 1) && _valor[13] != '0') || (11 - resto).ToString() != _valor[13].ToString())
        {
            return false;
        }

        return true;
    }

    private static string RetornarSomenterNumeros(string valor) =>
        string.Join("", Formatacao().Matches(valor).Select(x => x.Value));

    public override readonly string ToString() => _valor;
    [GeneratedRegex(@"\d+")]
    private static partial Regex Formatacao();

    public static implicit operator Cnpj(string valor) => new(valor);
}
