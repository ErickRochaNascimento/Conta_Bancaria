using System;
using System.Drawing;
using System.Numerics;
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

    public virtual void Saque(decimal valor)
    {
        bool saqueRealizado = false;

        do
        {
            if (Saldo > valor && valor != 0)
            {
                Saldo -= valor;
                Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo}");
                saqueRealizado = true;
                break;
            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para realizar o saque. \n Saldo: {Saldo}");
                break;
            }
        } while (true);
        
    }

    public void Depositar(decimal valor)
    {
        Saldo += valor;
        Console.WriteLine($"Deposito realizado com sucesso. Saldo atual: {Saldo}");
        
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



    public virtual void Rendimento(decimal Saldo)
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
        decimal valorComTaxa = valor + TaxaSaque;
        bool saqueRealizado = false;

        do
        {
            if (Saldo > valorComTaxa)
            {
                Saldo -= valorComTaxa;
                Console.WriteLine($"Saque realizado com sucesso. Saldo atual: {Saldo}");
                saqueRealizado = true;

            }
            else
            {
                Console.WriteLine($"Saldo insuficiente para realizar o saque. \n Saldo: {Saldo}");
                Console.WriteLine($"Taxa de Saque: {valorTaxa}");
            }
        } while (saqueRealizado); 
    }
}

public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(string nomeTitular, int numeroConta, decimal saldo, string tipoConta, int senha) : base(nomeTitular, numeroConta, saldo, tipoConta, senha)
    {
    }
    

    public override void Rendimento(decimal Saldo)
    {
        Saldo += Saldo * 0.1m;
        decimal rendeu = Saldo * 0.1m;
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


       
        do
        {
            Console.WriteLine($"Digite o numero da opção:\n 1 Criar Conta \n 2 Acessar conta");
            opcaoInput = Console.ReadLine()!;
            ehNumero = int.TryParse(opcaoInput, out opcaoConta);
            switch (opcaoConta)
            {
                case 1:
                    Console.WriteLine("Criação de conta:");
                    CriarConta();
                    break;
                case 2:
                    Console.WriteLine("Acesso a conta:");
                    AcessarConta();
                    break;
            }
            if (opcaoConta >= 1 && opcaoConta <= 2 && ehNumero)
            {
                break;
            }
            else
            {
                Console.Clear();
            }
            Console.WriteLine("Opcão invalida. Tente novamente.");
        } while (true);
    }

    static void MenuConta(ContaBancaria contaAtual)
    {
        int opcaoConta;
        bool ehNumero;
        string opcaoInput;
        



        do
        {
            Console.WriteLine($"Digite o numero da opção:\n 1 Saque \n 2 Deposito \n 3 Emprestimo \n 4 Consultar saldo");
          
            opcaoInput = Console.ReadLine()!;  
            ehNumero = int.TryParse(opcaoInput, out opcaoConta);

            switch (opcaoConta)
            {
                case 1:
                    Console.Clear();

                    Console.WriteLine("Saque:");

                    bool NumeroSaque;
                    decimal valorSaque;
                    string valorSaqueInput;

                    do
                    {
                        Console.Write("Digite o valor que deseja sacar: ");
                        valorSaqueInput = Console.ReadLine()!;
                        NumeroSaque = decimal.TryParse(valorSaqueInput, out valorSaque);

                        if(NumeroSaque)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Valor de saque inválido. Tente novamente.");
                            Console.Clear();
                        }



                    } while (true);
                    

                    contaAtual.Saque(valorSaque);
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
                case 2:
                    Console.Clear();

                    Console.WriteLine("Deposito:");

                    bool NumeroDeposito;
                    decimal valorDeposito;
                    string valorDepositoInput;

                    do
                    {
                        Console.Write("Digite o valor que deseja depositar: ");
                        valorDepositoInput = Console.ReadLine()!;
                        NumeroDeposito = decimal.TryParse(valorDepositoInput, out valorDeposito);

                        if (NumeroDeposito)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Valor de deposito inválido. Tente novamente.");
                            Console.Clear();
                        }



                    } while (true);


                    
                    contaAtual.Depositar(valorDeposito);
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Emprestimo:");

                    bool NumeroEmprestimo;
                    decimal valorEmprestimo;
                    string valorEmprestimoInput;

                    do
                    {
                        Console.Write("Digite o valor que deseja solicitar: ");
                        valorEmprestimoInput = Console.ReadLine()!;
                        NumeroEmprestimo = decimal.TryParse(valorEmprestimoInput, out valorEmprestimo);

                        if (NumeroEmprestimo)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Valor de emprestimo inválido. Tente novamente.");
                            Console.Clear();
                        }



                    } while (true);



                    contaAtual.LimiteEmprestimo(valorEmprestimo);
                    Console.WriteLine("\n\n");
                    MenuConta(contaAtual);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Consultar Saldo:");
                    contaAtual.Rendimento(contaAtual.Saldo);
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

        } while (true);
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
        string nomeTitular;
        do
        {
            Console.Write("Digite o nome do titular da conta: ");
            nomeTitular = Console.ReadLine()!;

        } while (string.IsNullOrWhiteSpace(nomeTitular));


        
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



            

          
            tipoConta = opcaoTipoConta switch
            {
                1 => "Corrente",
                2 => "Poupança",
                3 => "Empresarial",
                _ => throw new ArgumentException("Tipo de conta inválido")
            };
        } while (opcaoTipoConta < 1 || opcaoTipoConta > 3);
        

        ContaBancaria novaConta = null;
        if (tipoContaInput == "Corrente")
        {
            QuantidadeContasBancaria++;
            novaConta = new ContaCorrente(nomeTitular, QuantidadeContasBancaria, saldo, tipoConta, senha);
        }
        else if (tipoConta == "Poupança")
        {
            QuantidadeContasBancaria++;
            novaConta = new ContaPoupanca(nomeTitular, QuantidadeContasBancaria, saldo, tipoConta, senha);
        }
        else if (tipoConta == "Empresarial")
        {
            QuantidadeContasBancaria++;
            novaConta = new ContaEmpresarial(nomeTitular, QuantidadeContasBancaria, saldo, tipoConta, senha);
        }
        if(novaConta != null)
        {
            novaConta.ExibirInformacaoConta();
            ContasBancaria.Add(novaConta);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== BANCO ===");
        do
        {
            Thread.Sleep(3500);
            Console.Clear();
            Menu();

        }while(true);
    
        
        
    } }