using System;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.ValueObjects;
using SolucaoJV.UI;
using System.Threading;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using SolucaoJV.UI.Views;

namespace SolucaoJV.UI.Controllers
{
    internal class PartidaController
    {
        private readonly PartidaAppService _partidaAppService;
        
        Posicao p = new Posicao();

        public PartidaController(PartidaAppService partidaAppService)
        {
            _partidaAppService = partidaAppService;
        }

        public int Linha { get; set; }
        public int Coluna { get; set; }

        public void RegistrarJogada(int linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

        public void IniciarPartida()
        {
            PartidaDomainService partida = new PartidaDomainService();

            Tabuleiro tabuleiro = new Tabuleiro();
           
            TipoJogador jogadorAtual = TipoJogador.X;

            partida.Terminada = false;

            partida.Turno = 1;

            tabuleiro.ImprimirTelaJogo();

            while (!partida.Terminada)
            {
                bool posicao = false;

                tabuleiro.ImprimirControladores(partida);

                LerJogada();

                while (!posicao)
                {
                    bool posicaoTabuleiroDisponivel = partida.Tabuleiro[p.Linha, p.Coluna] == null;

                    if (posicaoTabuleiroDisponivel)
                    {
                        partida.Tabuleiro[p.Linha, p.Coluna] = Convert.ToString(partida.JogadorAtual);

                        tabuleiro.ImprimeJogadas(Convert.ToString(partida.JogadorAtual), p.Linha, p.Coluna);

                        if (partida.Turno > 2)
                        {
                            partida.VefificarVitoria(tabuleiro);
                        }
                        posicao = true;
                    }
                    else
                    {
                        JogadaInvalida();
                        LerJogada();
                    }
                }
                MudarJogador(jogadorAtual);
            }
        }

        public void LerJogada()
        {

            try
            {
                string jogada = Console.ReadLine();

                if (p.JogadaValida(jogada))
                {
                    char linha = jogada[0];
                    int coluna = int.Parse(jogada[1] + "");
                    //RegistrarJogada(linha, coluna);
                }
                else
                {
                    JogadaInvalida();
                }
            }
            catch
            {
                JogadaInvalida();
            }
        }

        public void JogadaInvalida()
        {
            int t = 3;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < 3; i++)
            {
                PosicaoCursorMsg($"Jogada Inválida...({t})");
                Thread.Sleep(1000);
                t--;
            }

            LimpaMsg();
        }

        private void LimpaMsg()
        {
            PosicaoCursorMsg("                           ");
            PosicaoCursorMsg("");
        }

        private void PosicaoCursorMsg(string msg)
        {
            Console.SetCursorPosition(17, 15);
            Console.Write(msg);
            Thread.Sleep(1000);
        }
        public void MudarJogador(TipoJogador jogadorAtual)
        {
            if (jogadorAtual == TipoJogador.X)
                jogadorAtual = TipoJogador.O;
        }
    }
}
