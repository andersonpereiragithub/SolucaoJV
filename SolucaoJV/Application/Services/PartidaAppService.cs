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
            while (true)
            {

                _configuraTela.ViewTela();

                ConsoleBoasVindas.Exibir();

                _tabuleiroUI.DesenharTabuleiroJogo();

                while (!_partidaDomainService.Terminada)
                {
                    int turnoAtual = _partidaDomainService.ObterTurno();
                    TipoJogador jogadorAtual = _partidaDomainService.JogadorAtual;

                    _tabuleiroUI.ImprimirControladores(turnoAtual, jogadorAtual);


                    (int linha, int coluna)? jogada = _jogadaService.LerJogada();

                    if (jogada == null)
                    {
                        return;
                    }

                    (int linha, int coluna) = jogada.Value;

                    bool jogadaAceita = RegistrarJogada(linha, coluna);

                    if (!jogadaAceita)
                    {
                        string posicao = $"{(char)('a' + linha)}{coluna + 1}";
                        _imensagemService.ExibirPosicaoOcupada(posicao);
                        continue;
                    }

                    _imensagemService.LimparMensagemJogada();

                    bool podeHaverGanhador = _partidaDomainService.ObterTurno() > 2;

                    if (podeHaverGanhador)
                    {
                        string vencedor = _partidaDomainService.VerificarVitoria();
                        bool houveVitoria = vencedor != null;
                        bool houveEmpate = vencedor == null && _partidaDomainService.Terminada;

                        if (houveVitoria)
                        {
                            _imensagemService.ExibirVencedor(vencedor);
                        }
                        else if (houveEmpate)
                        {
                            _imensagemService.ExibirEmpate();
                        }
                    }
                    if (!_partidaDomainService.Terminada)
                    {
                        MudarJogador();
                    }
                }

                bool reiniciar = ReiniciarPartida();
                if (!reiniciar)
                {
                    return;
                }
            }
        }

        public bool RegistrarJogada(int linha, int coluna)
        {
            bool jogadaAceita = _partidaDomainService.TentarRegistrarJogada(linha, coluna);

            if (!jogadaAceita)
            {
                return false;
            }

            string jogadorAtual = Convert.ToString(_partidaDomainService.JogadorAtual);
            _tabuleiroUI.ImprimeJogadas(jogadorAtual, linha, coluna);

            return true;
        }

        public void MudarJogador()
        {
            _partidaDomainService.MudarJogador();
        }

        public bool ReiniciarPartida()
        {
            _imensagemService.MensagemSeDesejaReiniciar();

            string jogarNovamente = Console.ReadLine();

            if (jogarNovamente == null)
            {
                return false;
            }

            if (jogarNovamente == "s")
            {
                ResetarParametros();
                return true;
            }
            return false;
        }

        private void ResetarParametros()
        {
            _partidaDomainService.LimparTabuleiro();
        }
    }
}
