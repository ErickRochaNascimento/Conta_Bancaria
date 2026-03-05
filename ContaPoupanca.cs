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
