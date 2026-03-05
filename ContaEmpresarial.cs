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