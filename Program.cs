using System;
using System.Drawing;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

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
            Console.WriteLine($"=== Menu da Conta {contaAtual.NumeroConta} ===");
            Console.WriteLine($"Digite o numero da opção:\n 1 Saque \n 2 Deposito \n 3 Emprestimo \n 4 Consultar saldo \n 5 Sair" );
          
            opcaoInput = Console.ReadLine()!;  
            ehNumero = int.TryParse(opcaoInput, out opcaoConta);

            switch (opcaoConta)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("Saque:");

                    decimal valorSaque = InputHelper.ReadDecimal("Digite o valor que deseja sacar: ", minValue: 0.01m); 

                    contaAtual.Saque(valorSaque);
                    continuarMenu = true;
                    Console.WriteLine("\n\n");

                    break;
                case 2:
                    Console.Clear();

                    Console.WriteLine("Deposito:");

                    decimal valorDeposito = InputHelper.ReadDecimal("Digite o valor que deseja depositar: ", minValue: 0.01m);
                    


                    
                    contaAtual.Depositar(valorDeposito);
                    continuarMenu = true;

                    Console.WriteLine("\n\n");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Emprestimo:");

                    decimal valorEmprestimo = InputHelper.ReadDecimal("Digite o valor que deseja solicitar: ", minValue: 0.01m);

                    contaAtual.LimiteEmprestimo(valorEmprestimo);
                    continuarMenu = true;

                    Console.WriteLine("\n\n");
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Consultar Saldo:");
                    contaAtual.Rendimento();
                    continuarMenu = true;

                    Console.WriteLine("\n\n");
                    break;
                case 5:
                    Console.Clear();
                    continuarMenu = false;
                    opcaoConta = 0;
                    ehNumero = false;
                    opcaoInput = "";

                    Menu();
                    break;
        
            }
            if (opcaoConta <= 1 && opcaoConta >= 5 && ehNumero)
            {
                Console.WriteLine("Opcão invalida. Tente novamente.");
            }
           
             

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
                Thread.Sleep(1000);
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
        Console.Write("Tente novamente");
        Thread.Sleep(1000);
        Console.Clear();

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
                Thread.Sleep(1000);
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
            Console.Clear();
            MenuConta(novaConta);
        }
        
    }

    static void Main(string[] args)
    {
     
        
            Console.WriteLine("=== BANCO ===");
            Menu();


    
        
        
    } }