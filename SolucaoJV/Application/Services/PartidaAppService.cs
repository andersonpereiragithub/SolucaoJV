using SolucaoJV.UI.Views;
using SolucaoJV.UI.Controllers;
using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;
using SolucaoJV.Domain.ValueObjects;

namespace SolucaoJV.Application.Services
{
    internal class PartidaAppService : IPartidaService
    {
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiroUI;
        private TipoJogador _jogadorAtual;
        private readonly ConfiguraTela _configuraTela;
        private readonly JogadaService _jogadaService;
        private readonly IMensagemService _imensagemService;
        bool posicao = false;

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
                posicao = false;
                int turnoAtual = _partidaDomainService.ObterTurno();
                TipoJogador jogadorAtual = _partidaDomainService.JogadorAtual;

                _tabuleiroUI.ImprimirControladores(turnoAtual, jogadorAtual);

                (int linha, int coluna) = _jogadaService.LerJogada();

                RegistrarJogada(linha, coluna);

                if (_partidaDomainService.ObterTurno() > 2)
                {
                    string vencedor = _partidaDomainService.VerificarVitoria();

                    if (vencedor != null)
                    {
                        _imensagemService.ExibirVencedor(vencedor);
                        ReiniciarPartida();
                        break;
                    }
                }
                MudarJogador();
            }
        }

        public void RegistrarJogada(int linha, int coluna)
        {
            if (_partidaDomainService.PosicaoDisponivel(linha, coluna))
            {
                _partidaDomainService.Jogadas[linha, coluna] = Convert.ToString(_partidaDomainService.JogadorAtual);
                _tabuleiroUI.ImprimeJogadas(Convert.ToString(_partidaDomainService.JogadorAtual), linha, coluna);

                posicao = true;
            }
            else
            {
                posicao = false;
            }
        }

        public void MudarJogador()
        {
            _partidaDomainService.MudarJogador();
        }

        public void ReiniciarPartida()
        {
            //_tabuleiroUI.DesenharTabuleiroJogo();
            _imensagemService.MensagemSeDesejaReiniciar();
            string jogarNovamente = Console.ReadLine().ToLower();

            if (jogarNovamente == 's'.ToString())
            {
                ResetarParametros();
                IniciarPartida();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void ResetarParametros()
        {
            _partidaDomainService.LimparTabuleiro();
        }
    }
}
