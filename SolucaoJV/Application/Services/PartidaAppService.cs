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

        bool posicao = false;

        public PartidaAppService(
            Tabuleiro tabuleiro, 
            PartidaDomainService partidaDomainService, 
            ConfiguraTela configuraTela,
            JogadaService jogadaService)
        {
            _tabuleiroUI = tabuleiro;
            _partidaDomainService = partidaDomainService;
            _configuraTela = configuraTela;
            _jogadaService = jogadaService;
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
                
                _jogadaService.LerJogada();

                if (_partidaDomainService.ObterTurno() > 2)
                {
                    _partidaDomainService.VefificarVitoria();
                }
                MudarJogador();
            }
        }

            //_partidaController.LerJogada();
        public void RegistrarJogada(int linha, int coluna) 
        {
            if (_partidaDomainService.PosicaoDisponivel(linha, coluna))
            {
                _partidaDomainService.Jogadas[linha, coluna] = Convert.ToString(_partidaDomainService.JogadorAtual);
                _tabuleiroUI.ImprimeJogadas(Convert.ToString(_partidaDomainService.JogadorAtual), linha, coluna);

                if (_partidaDomainService.ObterTurno() > 2)
                {
                    _partidaDomainService.VefificarVitoria();
                }
                posicao = true;
            }
            else
            {
                posicao = false;
            }

            //while (!posicao)
            //    {
            //        bool posicaoTabuleiroDisponivel = _partidaDomainService.PosicaoDisponivel(_partidaController.Linha, _partidaController.Coluna);

            //        if (posicaoTabuleiroDisponivel)
            //        {
            //            _partidaDomainService.Jogadas[_partidaController.Linha, _partidaController.Coluna] = Convert.ToString(_partidaDomainService.JogadorAtual);

            //            _tabuleiroUI.ImprimeJogadas(Convert.ToString(_partidaDomainService.JogadorAtual), _partidaController.Linha, _partidaController.Coluna);

            //            if (_partidaDomainService.ObterTurno() > 2)
            //            {
            //                _partidaDomainService.VefificarVitoria();
            //            }
            //            posicao = true;
            //        }
            //        else
            //        {
            //            _partidaController.JogadaInvalida();
            //            _partidaController.LerJogada();
            //        }
            //    }
            //    MudarJogador();
            //}
            //_partidaController.IniciarJogo();
        }

        public void MudarJogador()
        {
            _partidaDomainService.MudarJogador();
        }

        public void ReiniciarPartida()
        {
            _tabuleiroUI.DesenharTabuleiroJogo();
            //_partidaDomainService.Reiniciar();
        }
    }
}
