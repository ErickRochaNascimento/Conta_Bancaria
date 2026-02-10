using System;

ContaBancaria contaBancaria1 = new ContaBancaria();
contaBancaria1.NomeTitular = "Erick Nascimento";
contaBancaria1.NumeroConta = 2026020001;
contaBancaria1.Saldo = 5000;


ContaBancaria contaBancaria2 = new ContaBancaria();
contaBancaria2.NomeTitular = "Matheus Luciano";
contaBancaria2.NumeroConta = 2026020002;
contaBancaria2.Saldo = 2000;



contaBancaria1.ExibirInformacaoConta();
contaBancaria2.ExibirInformacaoConta();


