using System;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.ValueObjects;
using SolucaoJV.UI;
using System.Threading;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using SolucaoJV.UI.Views;
using SolucaoJV.Application.Interfaces;

namespace SolucaoJV.UI.Controllers
{
    internal class PartidaController
    {
        private readonly Posicao _posicao;
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiro;
        private readonly IMensagemService _imensagemService;

        bool posicao = false;
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public PartidaController(Tabuleiro tabuleiro, PartidaDomainService partidaDomainService, Posicao posicao, IMensagemService mensagemService)
        {
            _partidaDomainService = partidaDomainService;
            _tabuleiro = tabuleiro;
            _posicao = posicao;
            _imensagemService = mensagemService;
        }

        public void RegistrarJogada(int linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

        public void LerJogada()
        {
            string jogada = Console.ReadLine().ToLower();

            if (_posicao.JogadaValida(jogada))
            {
                char linha = jogada[0];
                int coluna = int.Parse(jogada[1] + "");
                RegistrarJogada(linha, coluna);
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
    }
}
