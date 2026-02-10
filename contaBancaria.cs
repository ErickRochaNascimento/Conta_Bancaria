using System;

class ContaBancaria
{
    private List<ContaCorrente> ContasCorrente = new List<ContaCorrente>();


    public string NomeTitular { get; set; }
    public int NumeroConta { get; set; }
    public decimal Saldo { get; set; }



    public void ExibirInformacaoConta()
    {
        Console.WriteLine($"Conta informações: \n Nome titular: {NomeTitular} \n Numero conta: {NumeroConta} \n Saldo: {Saldo}");
    }

    public void AdicionarContaCorrente(ContaCorrente contaCorrente)
    {
        ContasCorrente.Add( contaCorrente );
    }



    public void ExibirContas()
    {
        Console.WriteLine("Contas corrente: ");
        foreach ( var ContaBancaria in ContasCorrente)
        {
            Console.WriteLine($"Conta corrente: {ContaBancaria.NomeTitular}");
        }

    }
}

class ContaCorrente : ContaBancaria
{
    public string CriarContaCorrente
    {
        get; set; 
    }

}