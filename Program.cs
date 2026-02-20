using System;
using System.Security.Cryptography.X509Certificates;


public abstract class ContaBancaria
{
    private List<ContaCorrente> ContasCorrente = new List<ContaCorrente>();


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





    public void ExibirInformacaoConta()
    {
        Console.WriteLine($"Conta informações: \n Nome titular: {NomeTitular} \n Numero conta: {NumeroConta} \n Saldo: {Saldo} \n Tipo conta: {TipoConta}");
    }

    public void ExibirContas()
    {
        Console.WriteLine("Contas corrente: ");
        foreach (var ContaBancaria in ContasCorrente)
        {
            Console.WriteLine($"Conta corrente: {ContaBancaria.NomeTitular}");
        }

    }

    public abstract void DefinirLimiteEmprestimo();
}



public class ContaCorrente : ContaBancaria
{
    public ContaCorrente(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    decimal TaxaSaque = 0.10m;
    public override void DefinirLimiteEmprestimo()
    { }
}

public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    bool Taxa = false;
    decimal Rendimento = 0.05m; public override void DefinirLimiteEmprestimo()
    { }
    }

public class ContaEmpresarial : ContaBancaria
{
    public ContaEmpresarial(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    public decimal LimiteEmprestimo { get; private set;}
    public override void DefinirLimiteEmprestimo()
    {
        LimiteEmprestimo = 2 * Saldo; 
    }
   
}

class Program
{

    static int QuantidadeContasCorrente = 0;
    static int QuantidadeContasEmpresarial = 0;
    static int QuantidadeContasPoupanca = 0;
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
        int numeroConta;
        if (tipoConta == "Corrente")
        {
            QuantidadeContasCorrente++;
            ContaBancaria novaConta = new ContaCorrente(nomeTitular, QuantidadeContasCorrente, saldo, tipoConta, senha);
            novaConta.ExibirInformacaoConta();

        }
        else if (tipoConta == "Poupança")
        {
            QuantidadeContasPoupanca++;
            ContaBancaria novaConta = new ContaPoupanca(nomeTitular, QuantidadeContasPoupanca, saldo, tipoConta, senha);
            novaConta.ExibirInformacaoConta();
        }
        else if (tipoConta == "Empresarial")
        {
            QuantidadeContasEmpresarial++;
            ContaBancaria novaConta = new ContaEmpresarial(nomeTitular, QuantidadeContasEmpresarial, saldo, tipoConta, senha);
            novaConta.ExibirInformacaoConta();
        }
    }
    static void Main(string[] args)
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
                    Console.WriteLine("Digite o Numero da Conta:");
                    string numeroContaAcesso = Console.ReadLine();
                    Console.WriteLine("Digite a Senha:");
                    int senhaAcesso = int.Parse(Console.ReadLine());

                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            if (opcao == 1 || opcao == 2)
            {
                break;
            }
            Console.WriteLine("Opção inválida, digite novamente:");
            opcao = int.Parse(Console.ReadLine());

        } while (true);
        

    } }