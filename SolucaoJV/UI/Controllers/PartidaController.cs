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
        private readonly IPartidaAppService _partidaService;
        private readonly JogadaService _jogadaService;

        bool posicao = false;
        
        public PartidaController(
            Tabuleiro tabuleiro,
            PartidaDomainService partidaDomainService,
            Posicao posicao,
            IMensagemService mensagemService,
            IPartidaAppService partidaService,
            JogadaService jogadaService)
        {
            _partidaDomainService = partidaDomainService;
            _tabuleiro = tabuleiro;
            _posicao = posicao;
            _imensagemService = mensagemService;
            _partidaService = partidaService;
            _jogadaService = jogadaService;
        }

        public (int, int) LerJogada()
        {
            string jogada = Console.ReadLine().ToLower();
            bool jogadaValida = _posicao.JogadaValida(jogada);

            if (jogadaValida)
            {
                char linha = jogada[0];
                int coluna = int.Parse(jogada[1] + "");
                (int, int) posicaoDaJogada = _jogadaService.RegistrarJogada(linha, coluna);

                return posicaoDaJogada;
            }
            else
            {
                JogadaInvalida();
                return LerJogada();
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
