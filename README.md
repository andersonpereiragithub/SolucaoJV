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

## Imagens

### Tela de Boas-Vindas
![TelaBoasVindas](https://github.com/andersonpereiragithub/SolucaoJV/Img/TelaBoasVindas.png)

### Vencedores por Coluna

#### Coluna 1 - O Venceu
![TelaColuna1_O_Venceu](./Img/TelaColuna1_O_Venceu.png)

#### Coluna 1 - X Venceu
![TelaColuna1_X_Venceu](./Img/TelaColuna1_X_Venceu.png)

#### Coluna 2 - O Venceu
![TelaColuna2_O_Venceu](./Img/TelaColuna2_O_Venceu.png)

#### Coluna 2 - X Venceu
![TelaColuna2_X_Venceu](./Img/TelaColuna2_X_Venceu.png)

### Vencedores por Diagonal

#### Diagonal Principal - O Venceu
![TelaDiagonaPrincipal_O_Venceu](./Img/TelaDiagonaPrincipal_O_Venceu.png)

#### Diagonal Principal - X Venceu
![TelaDiagonaPrincipal_X_Venceu](./Img/TelaDiagonaPrincipal_X_Venceu.png)

#### Diagonal Secundária - O Venceu
![TelaDiagonaSecundaria_O_Venceu](./Img/TelaDiagonaSecundaria_O_Venceu.png)

#### Diagonal Secundária - X Venceu
![TelaDiagonaSecundaria_X_Venceu](./Img/TelaDiagonaSecundaria_X_Venceu.png)

### Empate
![TelaEmpate](./Img/TelaEmpate.png)

---

## Evolução do Código

O projeto **SolucaoJV** começou com uma abordagem simples e ao longo do tempo foi evoluindo. Abaixo estão alguns marcos importantes:

### 1. Primeira Versão (Código Amador)

A primeira versão do projeto era funcional, mas o código era monolítico, com responsabilidades misturadas. O jogo funcionava, mas a manutenção seria difícil à medida que novas funcionalidades fossem adicionadas.

```csharp
// Exemplo de código da primeira versão
Console.WriteLine("Bem-vindo ao Jogo da Velha!");
// Lógica do jogo e interface no mesmo arquivo
