using SolucaoJV.UI.Views;
using SolucaoJV.UI.Controllers;
using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;
using SolucaoJV.Domain.ValueObjects;

namespace SolucaoJV.Application.Services
{
    internal class PartidaAppService : IPartidaAppService
    {
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiroUI;
        private TipoJogador _jogadorAtual;
        private readonly ConfiguraTela _configuraTela;
        private readonly JogadaService _jogadaService;
        private readonly IMensagemService _imensagemService;

        public PartidaAppService(
            Tabuleiro tabuleiro,
            PartidaDomainService partidaDomainService,
            ConfiguraTela configuraTela,
            JogadaService jogadaService,
            IMensagemService imensagemService)
        {
            _tabuleiroUI = tabuleiro;
            _partidaDomainService = partidaDomainService;
            _configuraTela = configuraTela;
            _jogadaService = jogadaService;
            _imensagemService = imensagemService;
        }

        public void IniciarPartida()
        {
            _configuraTela.ViewTela();
            _tabuleiroUI.DesenharTabuleiroJogo();

            while (!_partidaDomainService.Terminada)
            {
                int turnoAtual = _partidaDomainService.ObterTurno();
                TipoJogador jogadorAtual = _partidaDomainService.JogadorAtual;

                _tabuleiroUI.ImprimirControladores(turnoAtual, jogadorAtual);

                (int linha, int coluna) = _jogadaService.LerJogada();

                RegistrarJogada(linha, coluna);

                bool podeHaverGanhador = _partidaDomainService.ObterTurno() > 2;

                if (podeHaverGanhador)
                {
                    string vencedor = _partidaDomainService.VerificarVitoria();
                    bool houveVitoria = vencedor != null;
                    bool houveEmpate = vencedor == null && turnoAtual == 5;

                    if (houveVitoria)
                    {
                        _imensagemService.ExibirVencedor(vencedor);
                        ReiniciarPartida();
                    }
                    else if (houveEmpate)
                    {
                        _imensagemService.ExibirEmpate();
                        ReiniciarPartida();
                    }
                }
                MudarJogador();
            }
        }

        public void RegistrarJogada(int linha, int coluna)
        {
            bool PosicaoEstaDisponivel = _partidaDomainService.PosicaoDisponivel(linha, coluna);

            if (PosicaoEstaDisponivel)
            {
                string jogadorAtual = Convert.ToString(_partidaDomainService.JogadorAtual);

                _partidaDomainService.Jogadas[linha, coluna] = jogadorAtual;
                _tabuleiroUI.ImprimeJogadas(jogadorAtual, linha, coluna);

            }
        }

        public void MudarJogador()
        {
            _partidaDomainService.MudarJogador();
        }

        public void ReiniciarPartida()
        {
            _imensagemService.MensagemSeDesejaReiniciar();
            string jogarNovamente = Console.ReadLine().ToLower();

            if (jogarNovamente == 's'.ToString())
            {
                ResetarParametros();
                IniciarPartida();
            }
            else
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }

        private void ResetarParametros()
        {
            _partidaDomainService.LimparTabuleiro();
        }
    }
}
