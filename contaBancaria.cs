public abstract class ContaBancaria
{


    public string NomeTitular { get; private set; }
    public int NumeroConta { get; private set; }
    public decimal Saldo { get; protected set; }
    public string TipoConta { get; protected set; }
    public int Senha { get; protected set; }





    protected ContaBancaria(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha)
    {
        NomeTitular = nomeTitular;
        NumeroConta = numeroConta;
        Saldo = saldo;
        TipoConta = tipoConta;
        Senha = senha;
    }

    protected ContaBancaria()
    {
    }

    public virtual void Saque(decimal valor)
    {



        if (Saldo >= valor && valor > 0)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo}");
        }
        else
        {
            Console.WriteLine($"Saldo insuficiente para realizar o saque. \n Saldo: {Saldo}");
        }

    }

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Deposito realizado com sucesso. Saldo atual: {Saldo}");
        }
        else
        {
            Console.WriteLine("Valor de deposito igual 0 ou menor que 0. Digite um valor valido.");


        }
    }

    public virtual void LimiteEmprestimo(decimal valor)
    {
        decimal limiteEmprestimo = 1 * Saldo;
        if (valor <= limiteEmprestimo)
        {
            Console.WriteLine($"Limite de emprestimo de {limiteEmprestimo}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Parcela {i + 1}: {valor / 6}");
            }

        }
        else
        {
            Console.WriteLine($"Pedido maior que o limite. \n Limite emprestimo: {limiteEmprestimo}");
        }
    }



    public virtual void Rendimento()
    {
        Console.WriteLine("Essa conta não tem rendimento");
        Console.WriteLine($"Saldo: {Saldo}");
    }


    public void ExibirInformacaoConta()
    {
        Console.WriteLine($"Conta informações: \n Nome titular: {NomeTitular} \n Numero conta: {NumeroConta} \n Saldo: {Saldo} \n Tipo conta: {TipoConta}");
    }
}
