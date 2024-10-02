using SolucaoJV.Application.Services;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.ValueObjects;
using SolucaoJV.UI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV.Domain.Services
{
    internal class PartidaDomainService
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public string[,] Jogadas { get; set; }
        public TipoJogador JogadorAtual { get; set; }
        public bool Terminada { get; set; }

        public int Turno;

        public PartidaDomainService()
        {
            Linha = 0;
            Coluna = 0;
            Jogadas = new string[3, 3];
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
        }

        public void VefificarVitoria(Tabuleiro tabuleiro)
        {
            int v = CondicaoDeVitoria(Jogadas);

            if (v == 1)
            {
                tabuleiro.EscreverEm(Convert.ToString(JogadorAtual), 20, 15);

                Console.BackgroundColor = ConsoleColor.White;

                if (JogadorAtual.ToString() == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                tabuleiro.EscreverEm("Venceu!!!", 14, 14);
                ReiniciarPartida();
            }
            else if (v == -1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;

                tabuleiro.EscreverEm("Deu EMPATE!", 17, 15);
                ReiniciarPartida();
            }
            Console.ResetColor();
        }
        public void RegistrarJogada(char linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

        public int CondicaoDeVitoria(string[,] mat)
        {
            if (VerificarVitoria("X"))
            {
                Terminada = true;
                return 1;  // Vitória de "X"
            }

            if (VerificarVitoria("O"))
            {
                Terminada = true;
                return 1;  // Vitória de "O"
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[i, j] == null)
                    {
                        return 0;  // Jogo ainda em andamento
                    }
                }
            }

            return -1;

            bool VerificarVitoria(string jogador)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((mat[i, 0] == jogador && mat[i, 1] == jogador && mat[i, 2] == jogador) ||  // Linha
                        (mat[0, i] == jogador && mat[1, i] == jogador && mat[2, i] == jogador))   // Coluna
                    {
                        return true;
                    }
                }
                if ((mat[0, 0] == jogador && mat[1, 1] == jogador && mat[2, 2] == jogador) ||  // Diagonal principal
                    (mat[0, 2] == jogador && mat[1, 1] == jogador && mat[2, 0] == jogador))   // Diagonal secundária
                {
                    return true;
                }

                return false;
            }
        }
        public void ReiniciarPartida()
        {
            Tabuleiro tabuleiro = new Tabuleiro();
            PartidaDomainService partidaDomainService = new PartidaDomainService();
            PartidaAppService partidaAppService = new PartidaAppService(tabuleiro, partidaDomainService);

            tabuleiro.EscreverEm("                       ", 8, 15);
            tabuleiro.EscreverEm("Deseja Reinciar (s/n)? ", 10, 16);

            char resp = char.Parse(Console.ReadLine());
            if (resp.Equals('s'))
            {
                tabuleiro.DesenharTabuleiroJogo();
                partidaAppService.IniciarPartida();
            }

            Environment.Exit(1);
        }
        public void MudarJogador()
        {
            if (JogadorAtual == TipoJogador.X)
                JogadorAtual = TipoJogador.O;
            else
            {
                //       IncrementarTurno();
                JogadorAtual = TipoJogador.X;
            }
        }
        public void LimparTabuleiro()
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Jogadas[linha, coluna] = null;
                }

            }
        }

    }
}

