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
        private readonly Posicao _posicao;
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiro;

        public PartidaController(Tabuleiro tabuleiro, PartidaDomainService partidaDomainService, Posicao posicao)
        {
            _partidaDomainService = partidaDomainService;
            _tabuleiro = tabuleiro;
            _posicao = posicao;
        }

        public int Linha { get; set; }
        public int Coluna { get; set; }
        private int contador = 1;

        public void RegistrarJogada(int linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

        public void IniciarPartida()
        {
            while (!_partidaDomainService.Terminada)
            {
                bool posicao = false;
                int teste = _partidaDomainService.Turno;

                _tabuleiro.ImprimirControladores(_partidaDomainService.Turno, _partidaDomainService.JogadorAtual);

                LerJogada();

                while (!posicao)
                {
                    bool posicaoTabuleiroDisponivel = _partidaDomainService.PosicaoDisponivel(Linha, Coluna);

                    if (posicaoTabuleiroDisponivel)
                    {
                        _partidaDomainService.Jogadas[Linha, Coluna] = Convert.ToString(_partidaDomainService.JogadorAtual);

                        _tabuleiro.ImprimeJogadas(Convert.ToString(_partidaDomainService.JogadorAtual), Linha, Coluna);

                        if (_partidaDomainService.Turno > 4)
                        {
                            _partidaDomainService.VefificarVitoria(_tabuleiro);
                        }
                        posicao = true;
                    }
                    else
                    {
                        JogadaInvalida();
                        LerJogada();
                    }
                }
                MudarJogador();
            }
        }

        public void LerJogada()
        {
            string jogada = Console.ReadLine();

            if (_posicao.JogadaValida(jogada))
            {
                char linha = jogada[0];
                int coluna = int.Parse(jogada[1] + "");
                RegistrarJogada(linha, coluna);
                IncrementarTurno();
            }
            else
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
        public void IncrementarTurno()
        {
            bool par = contador % 2 == 0;

            if (par)
            {
                _partidaDomainService.Turno++;
            }
            else
            {
                contador++;
            }
        }
        public void MudarJogador()
        {
            if (_partidaDomainService.JogadorAtual == TipoJogador.X)
            {
                _partidaDomainService.JogadorAtual = TipoJogador.O;
            }
            else
            {
                _partidaDomainService.JogadorAtual = TipoJogador.X;
                IncrementarTurno();
            }
        }
    }
}
