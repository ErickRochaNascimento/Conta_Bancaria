using System;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

public static class InputHelper
{
    public static decimal ReadDecimal(string prompt, decimal minValue = 0, decimal maxValue = decimal.MaxValue)
    {
        decimal value;
        string input;
        bool isValid;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()!;
            isValid = decimal.TryParse(input, out value);
            if (!isValid)
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número decimal válido.");
            }
            else if (value < minValue || value > maxValue)
            {
                Console.WriteLine($"O valor deve estar entre {minValue} e {maxValue}.");
                isValid = false;
            }
                

        }
        while (!isValid);
        return value;
    }

    public static int ReadInt(string prompt, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        int value;
        string input;
        bool isValid;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()!;
            isValid = int.TryParse(input, out value);

            if (!isValid)
            {
                Console.WriteLine();
            }
            else if (value < minValue || value > maxValue)
            {
                Console.WriteLine($"O valor deve estar entre {minValue} e {maxValue}.");
                isValid = false;
            }

        } while (!isValid);

        return value;
    }

   

    public static string ReadString(string prompt, int minLength = 1, int maxLength = 100)
    {
        string value;
        bool isValid;

        do
        {
            Console.Write(prompt);
            value = Console.ReadLine()!;
            isValid = !string.IsNullOrWhiteSpace(value) && value.Length >= minLength && value.Length <= maxLength;

            if (!isValid)
            {
                Console.WriteLine($"Entrada inválida. O texto não pode ser vazio e deve ter entre {minLength} e {maxLength} caracteres.");
            }

        } while (!isValid);

        return value;
    }

}

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
            for(int i = 0; i < 5; i++)
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



public class ContaCorrente : ContaBancaria
{
    public ContaCorrente(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    public decimal TaxaSaque = 0.10m;


    public override void Saque(decimal valor)
    {
        decimal valorTaxa = valor * TaxaSaque;
        decimal valorComTaxa = valor + valorTaxa;

       
            if (Saldo >= valorComTaxa && valor > 0)
            {
                Saldo -= valorComTaxa;
                Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo}");

            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para realizar o saque. \n Saldo: {Saldo}");
                Console.WriteLine($"Taxa de Saque: {valorTaxa}");
            }
    }
}

public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    

    public override void Rendimento()
    {
        decimal rendeu = Saldo * 0.1m;
        Saldo += rendeu;
        Console.WriteLine($"Saldo Atual: {Saldo} | Rendimento: {rendeu}");
    }
}

public class ContaEmpresarial : ContaBancaria
{
    public ContaEmpresarial(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    public override void LimiteEmprestimo(decimal valor)
    {
        decimal limiteEmprestimo = 2 * Saldo;
        if (valor <= limiteEmprestimo)
        {
            Console.WriteLine($"Limite de emprestimo de {limiteEmprestimo}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Parcela {i + 1}: {valor / 5}");
            }

        }
        else
        {
            Console.WriteLine($"Pedido maior que o limite. \n Limite emprestimo: {limiteEmprestimo}");
        }
    }
}

class Program
{
    static List<ContaBancaria> ContasBancaria = new List<ContaBancaria>();

    static int QuantidadeContasBancaria = 0;




    static void Menu()
    {
        int opcaoConta;
        bool ehNumero;
        string opcaoInput;
        bool continuarApp = true;


       
        while (continuarApp)
        {
            Console.Write($"Digite o numero da opção:\n 1 Criar Conta \n 2 Acessar conta \n 3 Sair \n Digite:");
            opcaoInput = Console.ReadLine()!;
            ehNumero = int.TryParse(opcaoInput, out opcaoConta);
            switch (opcaoConta)
            {
                case 1:
                    Console.WriteLine("\nCriação de conta:");
                    CriarConta();
                    continuarApp = true;

                    break;
                case 2:
                    Console.WriteLine("\nAcesso a conta:");
                    AcessarConta();
                    continuarApp = true;
                    break;
                case 3:
                    Console.WriteLine("Saindo do aplicativo...");
                    continuarApp = false;
                    break;
            }
            if (opcaoConta >= 1 && opcaoConta <= 3 && ehNumero)
            {
                break;
            }
            Console.WriteLine("Opcão invalida. Digite um valor correspondente ao menu.");
            Thread.Sleep(1000);
            Console.Clear();

        }
    }

    static void MenuConta(ContaBancaria contaAtual)
    {
        int opcaoConta;
        bool ehNumero;
        string opcaoInput;
        bool continuarMenu = true;
        



        while (continuarMenu)
        {
            Console.Clear();
            Console.WriteLine($"=== Menu da Conta {contaAtual.NumeroConta} ===");
            Console.WriteLine($"Digite o numero da opção:\n 1 Saque \n 2 Deposito \n 3 Emprestimo \n 4 Consultar saldo");
          
            opcaoInput = Console.ReadLine()!;  
            ehNumero = int.TryParse(opcaoInput, out opcaoConta);

            switch (opcaoConta)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("Saque:");

                    decimal valorSaque = InputHelper.ReadDecimal("Digite o valor que deseja sacar: ", minValue: 0.01m); 

                    contaAtual.Saque(valorSaque);
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
                case 2:
                    Console.Clear();

                    Console.WriteLine("Deposito:");

                    decimal valorDeposito = InputHelper.ReadDecimal("Digite o valor que deseja depositar: ", minValue: 0.01m);
                    


                    
                    contaAtual.Depositar(valorDeposito);
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Emprestimo:");

                    decimal valorEmprestimo = InputHelper.ReadDecimal("Digite o valor que deseja solicitar: ", minValue: 0.01m);

                    contaAtual.LimiteEmprestimo(valorEmprestimo);
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Consultar Saldo:");
                    contaAtual.Rendimento();
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
        
            }
            if (opcaoConta >= 1 && opcaoConta <= 4 && ehNumero)
            {
                break;
            }
            else
            {

                Console.Clear();
            }
                Console.WriteLine("Opcão invalida. Tente novamente.");

        };
    }

    static void AcessarConta()
    {

        bool NumeroConta;
        int numeroContaConferir = 0;
        string numeroContaInput;

        do
        {
            Console.Write("Digite o Numero da Conta: ");
            numeroContaInput = Console.ReadLine()!;
            NumeroConta = int.TryParse(numeroContaInput, out numeroContaConferir);

            if (NumeroConta)
            {
                break;
            }
            else
            {
                Console.WriteLine("Numero de conta inválido. Tente novamente.");
                Console.Clear();
            }



        } while (true);



        int senha = 0;
        string senhaInput;
        bool ehNumero;

        do
        {
            Console.Write("Digite a senha de 6 digitos: ");
            senhaInput = Console.ReadLine()!;
            ehNumero = int.TryParse(senhaInput, out senha);

            if (!string.IsNullOrWhiteSpace(senhaInput) && senhaInput.Length == 6 && ehNumero)
            {
                break;
            }
            else
            {
                Console.WriteLine("Senha incorreta. Tente novamente.");
            }
        } while (true);


        foreach (var contaBancaria in ContasBancaria)
        {
            if (contaBancaria.NumeroConta.ToString() == numeroContaInput && contaBancaria.Senha == senha)
            {
                Console.WriteLine("Acesso concedido à conta.");
                contaBancaria.ExibirInformacaoConta();
                MenuConta(contaBancaria);
                return;
            }
        }
        Console.WriteLine("Conta não encontrada.");
        Console.Write("Tente novamente: ");
    }

    static void CriarConta()
    {
        string nomeTitular = InputHelper.ReadString("Digite o nome do titular da conta: ");
        


        
        decimal saldo = 0;
        int senha = 0;
        string senhaInput;
        bool ehNumero;


        do
        {
            Console.Write("Crie uma senha de 6 digitos. \nA senha dever ser numerica. Exemplo: 123456 \nDigite: ");
            senhaInput = Console.ReadLine()!;
            ehNumero = int.TryParse(senhaInput, out senha);

            if (!string.IsNullOrWhiteSpace(senhaInput) && senhaInput.Length == 6 && ehNumero)
            {
                 break;
            }
            else
            {
                Console.WriteLine("Senha não atende os requisitos. Tente novamente.");
                Thread.Sleep(1000);
                Console.Clear();
            }
        } while (true);
        



        int opcaoTipoConta;
        string tipoContaInput;
        bool NumeroTipoConta;
        string tipoConta = "";
        do
        {
            Console.WriteLine($"Digite o numero da opção: \n 1 - Conta Corrente \n 2 - Conta Poupança \n 3 - Conta Empresarial ");
            tipoContaInput = Console.ReadLine()!;
            NumeroTipoConta = int.TryParse(tipoContaInput, out opcaoTipoConta);

            if(opcaoTipoConta >= 1 && opcaoTipoConta <= 3)
            {
                tipoConta = opcaoTipoConta switch
                {
                    1 => "Corrente",
                    2 => "Poupança",
                    3 => "Empresarial",
                };
                break;
            }
            else
            {
                Console.WriteLine("Erro ao criar a conta. Tipo de conta inválido ou outro problema.");
                Console.Clear();
            }

        } while (true);
        

        ContaBancaria novaConta = null;
        if (tipoConta == "Corrente")
        {
            novaConta = new ContaCorrente(nomeTitular, QuantidadeContasBancaria + 1, saldo, tipoConta, senha);
        }
        else if (tipoConta == "Poupança")
        {
            novaConta = new ContaPoupanca(nomeTitular, QuantidadeContasBancaria + 1, saldo, tipoConta, senha);
        }
        else if (tipoConta == "Empresarial")
        {
            novaConta = new ContaEmpresarial(nomeTitular, QuantidadeContasBancaria + 1, saldo, tipoConta, senha);
        }
        if(novaConta != null)
        {
            QuantidadeContasBancaria++;

            novaConta.ExibirInformacaoConta();
            ContasBancaria.Add(novaConta);
            Console.WriteLine("Conta criada com sucesso!");
            MenuConta(novaConta);
        }
        
    }

    static void Main(string[] args)
    {
     
        
            Console.WriteLine("=== BANCO ===");
            Menu();

    
        
        
    } }