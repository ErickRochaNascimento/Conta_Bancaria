using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;


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

    public void CriarContaBancaria(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha)
    {

        NomeTitular = nomeTitular;
        NumeroConta = numeroConta;
        Saldo = saldo;
        TipoConta = tipoConta;
        Senha = senha;

    }

    
    public virtual void Saque(decimal valor)
    {
        if (Saldo > valor)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo}");

        }
        else
        {
            Console.WriteLine($"Saldo insuficiente para realizar o saque. \n Saldo: {Saldo}");
        }
    }

    public virtual void LimiteEmprestimo(decimal valor)
    {
       decimal LimiteEmprestimo = 1 * Saldo;
        if (valor <= LimiteEmprestimo)
        {
            Console.WriteLine($"Limite de emprestimo de {LimiteEmprestimo}");
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Parcela {i + 1}: {valor / 5}");
            }

        }
        else
        {
            Console.WriteLine($"Pedido maior que o limite. \n Limite emprestimo: {LimiteEmprestimo}");
        }
    }

    public virtual void Rendimento(decimal Saldo)
    {
        Console.WriteLine("Essa conta não tem rendimento");
    }


    public void ExibirInformacaoConta()
    {
        Console.WriteLine($"Conta informações: \n Nome titular: {NomeTitular} \n Numero conta: {NumeroConta} \n Saldo: {Saldo} \n Tipo conta: {TipoConta}");
    }



  

}



public class ContaCorrente : ContaBancaria
{
    public ContaCorrente(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    public decimal TaxaSaque = 0.10m;

    

    protected ContaCorrente(decimal taxasaque)
    {
        TaxaSaque = taxasaque;
    }

    protected ContaCorrente()
    {
    }

    public override void Saque(decimal valor)
    {
        decimal valorComTaxa = valor + (valor * TaxaSaque);
        if (Saldo > valorComTaxa)
        {
            Saldo -= valorComTaxa;
            Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo}");

        }
        else
        {
            Console.WriteLine($"Saldo insuficiente para realizar o saque. \n Saldo: {Saldo}");
        }
    }

 
}

public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    

    public override void Rendimento(decimal Saldo)
    {
        Saldo += Saldo * 0.5m;
        Console.WriteLine($"Saldo Atual: {Saldo}");
    }
    
   
    

}

public class ContaEmpresarial : ContaBancaria
{
    public ContaEmpresarial(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    public override void LimiteEmprestimo(decimal valor)
    {
        decimal LimiteEmprestimo = 2 * Saldo;
        if (valor <= LimiteEmprestimo)
        {
            Console.WriteLine($"Limite de emprestimo de {LimiteEmprestimo}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Parcela {i + 1}: {valor / 5}");
            }

        }
        else
        {
            Console.WriteLine($"Pedido maior que o limite. \n Limite emprestimo: {LimiteEmprestimo}");
        }
    }

    public override void Saque(decimal valor)
    {

    }


}

class Program
{
    static List<ContaBancaria> ContasBancaria = new List<ContaBancaria>();

    static int QuantidadeContasBancaria = 0;




    static void Menu()
    {
        Console.WriteLine($"Digite o numero da opção:\n 1- Criar Conta \n 2- Acessar conta");
        int opcao = int.Parse(Console.ReadLine());
        do
        {
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Criação de conta:");
                    CriarConta();
                    break;
                case 2:
                    Console.WriteLine("Acesso a conta:");
                    AcessarConta();
                    break;
                default:
                    Console.WriteLine("Opção inválida, digite novamente:");
                    break;
            }
            if (opcao == 1 || opcao == 2)
            {
                break;
            }
            Console.WriteLine($"Digite o numero da opção:\n 1- Criar Conta \n 2- Acessar conta");
            opcao = int.Parse(Console.ReadLine());

        } while (true);
    }

    static void MenuConta(ContaBancaria contaAtual)
    {
        Console.WriteLine($"Digite o numero da opção:\n 1- Saque \n 2- Deposito");
        int opcaoConta = int.Parse(Console.ReadLine());
        do
        {
            switch (opcaoConta)
            {
                case 1:
                    Console.WriteLine("Saque:");
                    Console.WriteLine("Digite o valor que deseja sacar:");
                    decimal valorSaque = decimal.Parse(Console.ReadLine());
                    contaAtual.Saque(valorSaque);
                    break;
                case 2:
                    Console.WriteLine("Acesso a conta:");
                    AcessarConta();
                    break;
                default:
                    Console.WriteLine("Opção inválida, digite novamente:");
                    break;
            }
            if (opcaoConta == 1 || opcaoConta == 2)
            {
                break;
            }
            Console.WriteLine($"Digite o numero da opção:\n 1- Saque \n 2- Deposito");
            opcaoConta = int.Parse(Console.ReadLine());

        } while (true);
    }

    static void AcessarConta()
    {

        Console.WriteLine("Digite o Numero da Conta:");
        string numeroContaAcesso = Console.ReadLine();
        Console.WriteLine("Digite a Senha:");
        int senhaAcesso = int.Parse(Console.ReadLine());
        foreach (var contaBancaria in ContasBancaria)
        {
            if (contaBancaria.NumeroConta.ToString() == numeroContaAcesso && contaBancaria.Senha == senhaAcesso)
            {
                Console.WriteLine("Acesso concedido à conta.");
                contaBancaria.ExibirInformacaoConta();
                MenuConta(contaBancaria);
                return;
            }
        }
        Console.WriteLine("Conta não encontrada.");

    }
    static void CriarConta()
    {
        Console.WriteLine("Digite o nome do titular da conta:");
        string nomeTitular = Console.ReadLine();
        Console.WriteLine("Digite o saldo inicial:");
        decimal saldo = decimal.Parse(Console.ReadLine());
        Console.WriteLine($"Digite o numero da opção: \n 1 - Conta Corrente \n 2 - Conta Poupança \n 3 - Conta Empresarial");
        int opcaoTipoConta = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite uma senha de 6 digitos");
        int senha = int.Parse(Console.ReadLine());

        string tipoConta = opcaoTipoConta switch
        {
            1 => "Corrente",
            2 => "Poupança",
            3 => "Empresarial",
            _ => throw new ArgumentException("Tipo de conta inválido")
        };
        if (tipoConta == "Corrente")
        {
            QuantidadeContasBancaria++;
            ContaBancaria novaConta = new ContaCorrente(nomeTitular, QuantidadeContasBancaria, saldo, tipoConta, senha);
            novaConta.ExibirInformacaoConta();
            ContasBancaria.Add(novaConta);

        }
        else if (tipoConta == "Poupança")
        {
            QuantidadeContasBancaria++;
            ContaBancaria novaConta = new ContaPoupanca(nomeTitular, QuantidadeContasBancaria, saldo, tipoConta, senha);
            novaConta.ExibirInformacaoConta();
            ContasBancaria.Add(novaConta);
        }
        else if (tipoConta == "Empresarial")
        {
            QuantidadeContasBancaria++;
            ContaBancaria novaConta = new ContaEmpresarial(nomeTitular, QuantidadeContasBancaria, saldo, tipoConta, senha);
            novaConta.ExibirInformacaoConta();
            ContasBancaria.Add(novaConta);
        }
        Menu();
    }
    static void Main(string[] args)
    {
        Menu();
    
        
        
    } }