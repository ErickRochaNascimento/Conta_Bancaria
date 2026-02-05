using System;

class contaBancaria
{

    public string nomeTitular;
    public int numeroConta;
    public decimal saldo;
    
    public void ExibirInformacaoConta()
    {
        Console.WriteLine($"Conta informações: \n Nome titular{nomeTitular} \n Numero conta: {numeroConta} \n Saldo: {saldo}");
    }
}
