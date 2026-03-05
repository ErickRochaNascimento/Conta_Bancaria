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