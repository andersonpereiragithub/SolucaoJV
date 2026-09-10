using SolucaoJV.Application.Interfaces;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;

namespace SolucaoJV.Application.Services
{
    internal class PartidaAppService : IPartidaAppService
    {
        private readonly PartidaDomainService _partidaDomainService;
        private readonly ITabuleiro _tabuleiroUI;
        private readonly IConfiguraTela _configuraTela;
        private readonly IJogadaService _jogadaService;
        private readonly IMensagemService _imensagemService;
        private readonly IBoasVindas _boasVindas;

        public PartidaAppService(
            ITabuleiro tabuleiro,
            PartidaDomainService partidaDomainService,
            IConfiguraTela configuraTela,
            IJogadaService jogadaService,
            IMensagemService imensagemService,
            IBoasVindas boasVindas)
        {
            _tabuleiroUI = tabuleiro;
            _partidaDomainService = partidaDomainService;
            _configuraTela = configuraTela;
            _jogadaService = jogadaService;
            _imensagemService = imensagemService;
            _boasVindas = boasVindas;
        }

        public void IniciarPartida()
        {
            while (true)
            {
                _configuraTela.ViewTela();

                _boasVindas.Exibir();

                _tabuleiroUI.DesenharTabuleiroJogo();

                while (!_partidaDomainService.Terminada)
                {
                    int turnoAtual = _partidaDomainService.Turno;

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
                        _imensagemService.ExibirPosicaoOcupada(linha, coluna);
                        continue;
                    }

                    _imensagemService.LimparMensagemJogada();

                    ResultadoPartida resultadoPartida = _partidaDomainService.VerificarResultado(out TipoJogador? vencedor);

                    if (resultadoPartida == ResultadoPartida.Vitoria)
                    {
                        _imensagemService.ExibirVencedor(vencedor.Value);
                    }
                    else if (resultadoPartida == ResultadoPartida.Empate)
                    {
                        _imensagemService.ExibirEmpate();
                    }
                    if (!_partidaDomainService.Terminada)
                    {
                        _partidaDomainService.MudarJogador();
                    }
                }

                bool reiniciar = ReiniciarPartida();
                if (!reiniciar)
                {
                    return;
                }
            }
        }

        private bool RegistrarJogada(int linha, int coluna)
        {
            bool jogadaAceita = _partidaDomainService.TentarRegistrarJogada(linha, coluna);

            if (!jogadaAceita)
            {
                return false;
            }

            TipoJogador jogadorAtual = _partidaDomainService.JogadorAtual;

            _tabuleiroUI.ImprimeJogadas(jogadorAtual, linha, coluna);

            return true;
        }

        private bool ReiniciarPartida()
        {
            _imensagemService.ExibirMensagemReinicio();

            bool reiniciar = _jogadaService.DesejaReiniciar();

            if (reiniciar)
            {
                _partidaDomainService.ReiniciarEstadoPartida();
            }
            return reiniciar;
        }
    }
}
