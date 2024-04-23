namespace Domain.ValueObject;

public readonly struct CpfCnpj
{
    private readonly Cpf _cpf;
    private readonly Cnpj _cnpj;
    private readonly string _tipo;

    public string Formatado
    {
        get
        {
            if (_tipo == "CPF")
            {
                return _cpf.Formatado;
            }

            if (_tipo == "CNPJ")
            {
                return _cnpj.Formatado;
            }

            return string.Empty;
        }
    }

    public bool Valido
    {
        get
        {
            if (_tipo == "CPF")
            {
                return _cpf.Valido;
            }

            if (_tipo == "CNPJ")
            {
                return _cnpj.Valido;
            }

            return false;
        }
    }

    public CpfCnpj(Cpf cpf)
    {
        if (cpf.Valido)
        {
            _cpf = cpf;
            _cnpj = string.Empty;
            _tipo = "CPF";

            return;
        }

        throw new System.Exception("Valor inválido para CpfCnpj");
    }

    public CpfCnpj(Cnpj cnpj)
    {
        if (cnpj.Valido)
        {
            _cpf = string.Empty;
            _cnpj = cnpj;
            _tipo = "CNPJ";

            return;
        }

        throw new System.Exception("Valor inválido para CpfCnpj");
    }

    public CpfCnpj(string cpfcnpj)
    {
        if (cpfcnpj == null)
        {
            throw new System.Exception("Não é permitido string nullable.");
        }

        Cpf cpf = cpfcnpj;

        if (cpf.Valido)
        {
            _cpf = cpf;
            _cnpj = string.Empty;
            _tipo = "CPF";

            return;
        }

        Cnpj cnpj = cpfcnpj;

        if (cnpj.Valido)
        {
            _cpf = string.Empty;
            _cnpj = cnpj;
            _tipo = "CNPJ";

            return;
        }

        throw new System.Exception("Valor inválido para CpfCnpj");
    }

    public static implicit operator CpfCnpj(Cpf cpf) => new(cpf);

    public static implicit operator CpfCnpj(Cnpj cnpj) => new(cnpj);

    public static implicit operator CpfCnpj(string cpfcnpj)
    {
        if (cpfcnpj == null)
        {
            throw new System.Exception("Não é permitido string nullable.");
        }

        Cpf cpf = cpfcnpj;

        if (cpf.Valido)
        {
            return new(cpf);
        }

        Cnpj cnpj = cpfcnpj;

        if (cnpj.Valido)
        {
            return new(cnpj);
        }

        throw new System.Exception("Valor inválido para CpfCnpj");
    }
}
