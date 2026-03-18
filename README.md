# POO-Sprint1: Sistema Bancário Simplificado em C#

## Descrição do Projeto

Este projeto consiste em um sistema bancário simplificado desenvolvido em C#, utilizando os princípios da Programação Orientada a Objetos (POO). A aplicação permite a criação de diferentes tipos de contas bancárias (Corrente, Poupança e Empresarial) e a realização de operações básicas como saque, depósito e solicitação de empréstimo. O sistema é executado via console e gerencia as contas em memória durante a execução.

## Funcionalidades

O sistema oferece as seguintes funcionalidades:

*   **Criação de Contas**: Os usuários podem criar três tipos de contas:
    *   **Conta Corrente**: Permite saques com a aplicação de uma taxa.
    *   **Conta Poupança**: Oferece rendimento sobre o saldo.
    *   **Conta Empresarial**: Possui um limite de empréstimo diferenciado, baseado no saldo.
*   **Operações Bancárias**: Após acessar uma conta, o titular pode realizar:
    *   **Saque**: Retirada de valores, com validação de saldo suficiente e aplicação de taxa para Conta Corrente.
    *   **Depósito**: Adição de valores à conta.
    *   **Empréstimo**: Solicitação de empréstimo com base no limite disponível para o tipo de conta.
*   **Consulta de Saldo**: Visualização do saldo atual da conta, incluindo o rendimento para Conta Poupança.
*   **Autenticação**: Acesso seguro à conta através de número da conta e senha numérica de 6 dígitos.
*   **Validação de Entrada**: Utiliza uma classe auxiliar (`InputHelper`) para garantir que as entradas do usuário (valores e senhas) sejam válidas.

## Estrutura do Projeto

O projeto é organizado nas seguintes classes:

*   `ContaBancaria.cs`: Classe abstrata base que define as propriedades e métodos comuns a todas as contas bancárias (NomeTitular, NumeroConta, Saldo, TipoConta, Senha, Saque, Depositar, LimiteEmprestimo, Rendimento, ExibirInformacaoConta).
*   `ContaCorrente.cs`: Herda de `ContaBancaria` e implementa lógica específica para saques com taxa.
*   `ContaPoupanca.cs`: Herda de `ContaBancaria` e sobrescreve o método `Rendimento` para aplicar juros.
*   `ContaEmpresarial.cs`: Herda de `ContaBancaria` e sobrescreve o método `LimiteEmprestimo` com uma regra de cálculo diferente.
*   `InputHelper.cs`: Classe estática utilitária para auxiliar na leitura e validação de entradas do usuário (decimal, int, string).
*   `Program.cs`: Contém a lógica principal da aplicação, incluindo os menus de interação, criação e acesso às contas, e a chamada das operações bancárias.

## Tecnologias Utilizadas

*   **C#**: Linguagem de programação principal.
*   **.NET 10.0**: Framework de desenvolvimento.

## Como Compilar e Executar

Para compilar e executar este projeto, você precisará ter o SDK do .NET 10.0 instalado em sua máquina.

1.  **Clone o repositório**:
    ```bash
    git clone https://github.com/ErickRochaNascimento/POO-Sprint1.git
    cd POO-Sprint1
    ```
2.  **Compile o projeto**:
    ```bash
    dotnet build
    ```
3.  **Execute a aplicação**:
    ```bash
    dotnet run
    ```

---

## 🧑‍💻 Autor

**Erick Rocha Nascimento**  
🔗 [LinkedIn](https://www.linkedin.com/in/erickrochanascimento) | [GitHub](https://github.com/ErickRochaNascimento)
