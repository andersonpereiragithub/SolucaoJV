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
        private readonly PartidaDomainService _partidaDomainService;
        private readonly Tabuleiro _tabuleiroUI;
        private TipoJogador _jogadorAtual;
        private readonly PartidaController _partidaController;
        private readonly ConfiguraTela _configuraTela;

        // A lógica de domínio (regras do jogo) e a lógica de apresentação (interface do console)
        // estão misturadas em várias classes (PartidaDomainService.cs, PartidaAppService.cs).

        // Sugestão: Separe essas responsabilidades. Por exemplo, PartidaDomainService deve se
        // concentrar nas regras do jogo e não na interação com o usuário.

        public PartidaAppService(Tabuleiro tabuleiro, PartidaDomainService partidaDomainService, PartidaController partidaController, ConfiguraTela configuraTela)
        {
            _tabuleiroUI = tabuleiro;
            _partidaDomainService = partidaDomainService;
            _partidaController = partidaController;
            _configuraTela = configuraTela;
        }

        public void IniciarPartida()
        {
            _configuraTela.ViewTela();
            _tabuleiroUI.DesenharTabuleiroJogo();
            _partidaController.IniciarPartidaController();
        }

        public void MudarJogador()
        {
            _partidaDomainService.MudarJogador();
        }

        public void ReiniciarPartida()
        {
            _tabuleiroUI.DesenharTabuleiroJogo();
            _partidaController.IniciarPartidaController();
        }
    }
}
