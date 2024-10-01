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
        public string[,] Tabuleiro { get; set; }
        public TipoJogador JogadorAtual { get; set; }
        public bool Terminada { get; set; }
        public int Turno;

        public PartidaDomainService()
        {
            Linha = 0;
            Coluna = 0;
            Tabuleiro = new string[3, 3];
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
        }

        PartidaDomainService tab = new PartidaDomainService();
        Tabuleiro tabuleiro = new Tabuleiro();
        
        //public void IniciarPartida(PartidaDomainService tab)
        //{
        //    Tabuleiro = new string[3, 3];

        //    JogadorAtual = TipoJogador.X;

        //    Terminada = false;

        //    Turno = 1;

        //    tabuleiro.ImprimirTelaJogo();

        //    PartidaDomainService partida = new PartidaDomainService();

        //    while (!partida.Terminada)
        //    {
        //        bool posicao = false;
        //        Posicao p = new Posicao();

        //        tabuleiro.ImprimirControladores(partida);

        //        p.LerJogada();

        //        while (!posicao)
        //        {
        //            bool posicaoTabuleiroDisponivel = partida.Tabuleiro[p.Linha, p.Coluna] == null;

        //            if (posicaoTabuleiroDisponivel)
        //            {
        //                partida.Tabuleiro[p.Linha, p.Coluna] = Convert.ToString(partida.JogadorAtual);

        //                tabuleiro.ImprimeJogadas(Convert.ToString(partida.JogadorAtual), p.Linha, p.Coluna);

        //                if (partida.Turno > 2)
        //                {
        //                    partida.VefificarVitoria(tabuleiro);
        //                }
        //                posicao = true;
        //            }
        //            else
        //            {
        //                p.JogadaInvalida();
        //                p.LerJogada();
        //            }
        //        }
        //        MudarJogador();
        //    }
        //}

        public void VefificarVitoria(string[,] Tabuleiro)
        {
            Tabuleiro t = new Tabuleiro();

            int v = CondicaoDeVitoria(Tabuleiro);

            if (v == 1)
            {
                t.EscreverEm(Convert.ToString(JogadorAtual), 20, 15);

                Console.BackgroundColor = ConsoleColor.White;

                if (JogadorAtual.ToString() == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                t.EscreverEm("Venceu!!!", 14, 14);
                ReiniciarPartida();
            }
            else if (v == -1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;

                t.EscreverEm("Deu EMPATE!", 17, 15);
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
            Tabuleiro t = new Tabuleiro();
            t.EscreverEm("                       ", 8, 15);
            t.EscreverEm("Deseja Reinciar (s/n)? ", 10, 16);

            char resp = char.Parse(Console.ReadLine());
            if (resp.Equals('s'))
                t.ImprimirTelaJogo();

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
                    Tabuleiro[linha, coluna] = null;
                }

            }
        }

    }
}

