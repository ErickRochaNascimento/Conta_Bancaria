using System;

contaBancaria contaBancaria1 = new contaBancaria();
contaBancaria1.nomeTitular = "Erick Nascimento";
contaBancaria1.numeroConta = 2026020001;
contaBancaria1.saldo = 5000;

contaBancaria contaBancaria2 = new contaBancaria();
contaBancaria2.nomeTitular = "Matheus Luciano";
contaBancaria2.numeroConta = 2026020002;
contaBancaria2.saldo = 2000;

contaBancaria1.ExibirInformacaoConta();
contaBancaria2.ExibirInformacaoConta();