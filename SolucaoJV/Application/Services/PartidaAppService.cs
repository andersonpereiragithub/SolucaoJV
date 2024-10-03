using SolucaoJV.UI.Views;
using SolucaoJV.UI.Controllers;
using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System;

namespace SolucaoJV.Application.Services
{
    internal class PartidaAppService : IPartidaService
    {
        private TipoJogador _jogadorAtual;
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiroUI;
        private readonly PartidaController _partidaController;

        // A lógica de domínio (regras do jogo) e a lógica de apresentação (interface do console)
        // estão misturadas em várias classes (PartidaDomainService.cs, PartidaAppService.cs).

        // Sugestão: Separe essas responsabilidades. Por exemplo, PartidaDomainService deve se
        // concentrar nas regras do jogo e não na interação com o usuário.

        public PartidaAppService(Tabuleiro tabuleiro, PartidaDomainService partidaDomainService, PartidaController partidaController)
        {
            //_jogadorAtual = TipoJogador.X;
            _tabuleiroUI = tabuleiro;
            _partidaDomainService = partidaDomainService;
            _partidaController = partidaController;
        }

        public void IniciarPartida()
        {
            //PartidaController partidaController = new PartidaController(this);
            _partidaController.IniciarPartida();
        }
        public void MudarJogador()
        {
            if (_jogadorAtual == TipoJogador.X)
            {
                _jogadorAtual = TipoJogador.O;
            }
            else
            {
                _jogadorAtual = TipoJogador.X;
            }
        }

        public void ReiniciarPartida()
        {
            // Mistura lógica de controle de fluxo e apresenta
            // Retirar a escrita no tabuleiro da lógica de reiniciar a partida

            _tabuleiroUI.EscreverEm("                        ", 8, 15);
            _tabuleiroUI.EscreverEm("Deseja Reiniciar (s/n)? ", 10, 16);

            char resposta = char.Parse(Console.ReadLine());
            if (resposta.Equals('s'))
            {
                IniciarPartida();
            }
            Environment.Exit(0);
        }
    }
}
