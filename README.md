# SolucaoJV - Jogo da Velha

## Descrição

O **SolucaoJV** é um projeto de console de um Jogo da Velha desenvolvido em C# com o objetivo de **treinar as lições de programação** como parte de um desafio de aprendizado. A ideia inicial era criar um jogo simples, mas ao longo do tempo, o código foi refatorado para seguir as boas práticas de design de software, como os princípios SOLID. Este repositório demonstra a evolução da codificação, mostrando a transição de um código amador para um código mais robusto e limpo.

---

## Funcionalidades

- Jogo da Velha jogável no console.
- Verificação automática de vencedores ou empate.
- Reiniciar o jogo ao final de cada partida.
- Interface simples e intuitiva.
- **(Em breve)** Possibilidade de jogar contra uma IA.

---

## Estrutura do Projeto

O projeto segue os princípios de responsabilidade única (SRP), separando as camadas de lógica de negócio e interface do usuário. Abaixo, estão as classes principais do projeto e suas responsabilidades:

- `PartidaDomainService.cs`: Contém a lógica principal do jogo, como iniciar a partida e verificar as regras de vitória.
- `PartidaAppService.cs`: Responsável por orquestrar as chamadas entre a lógica do domínio e a interface.
- `Program.cs`: Ponto de entrada da aplicação.
- `IPartidaAppService.cs`: Interface para garantir a separação de dependências e facilitar testes unitários.

---

## Evolução do Código

O projeto **SolucaoJV** começou com uma abordagem simples e ao longo do tempo foi evoluindo. Abaixo estão alguns marcos importantes:

### 1. Primeira Versão (Código Amador)

A primeira versão do projeto era funcional, mas o código era monolítico, com responsabilidades misturadas. O jogo funcionava, mas a manutenção seria difícil à medida que novas funcionalidades fossem adicionadas.

```csharp
// Exemplo de código da primeira versão
Console.WriteLine("Bem-vindo ao Jogo da Velha!");
// Lógica do jogo e interface no mesmo arquivo
