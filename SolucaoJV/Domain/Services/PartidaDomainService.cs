using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.ValueObjects;
using SolucaoJV.UI.Controllers;
using SolucaoJV.UI.Views;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Channels;

namespace SolucaoJV.Domain.Services
{
    //Refatoração de Métodos Complexos
    // Métodos como VefificarVitoria em PartidaDomainService.cs são grandes e
    // misturam várias responsabilidades, como lógica de verificação e apresentação de resultados.
    // Sugestão: Divida esses métodos em partes menores e mais focadas.Crie métodos auxiliares que
    // cada um tenha uma única responsabilidade.

    // Uso de Tipos Específicos
    // Coordenadas(Linha e Coluna) são armazenadas como valores primitivos.Isso reduz a
    // legibilidade e pode aumentar a chance de erros.
    // Sugestão: Crie uma classe Coordenada para representar a posição no tabuleiro,
    // melhorando a clareza do código.

    internal class PartidaDomainService
    {
        private readonly Tabuleiro _tabuleiro;
        //private readonly PartidaAppService _partidaAppService;
        //private readonly PartidaController _partidaController;

        public int Linha { get; set; } //TORNAR ESSA VARIÁVEL PRIVADA
        public int Coluna { get; set; } //TORNAR ESSA VARIÁVEL PRIVADA
        public string[,] Jogadas { get; private set; }
        public TipoJogador JogadorAtual { get; set; }
        public bool Terminada { get; set; }

        public int Turno;

        public PartidaDomainService(Tabuleiro tabuleiro)
        {
            _tabuleiro = tabuleiro;
            //  _partidaAppService = partidaAppService;
            //_partidaController = paridaController;
            IniciarJogadas();
        }

        public PartidaDomainService()
        {
            Linha = 0;
            Coluna = 0;
            JogadorAtual = TipoJogador.X;
            Terminada = false;
            Turno = 1;
            IniciarJogadas();
        }

        private void IniciarJogadas()
        {
            Jogadas = new string[3, 3];
        }
        public void VefificarVitoria(Tabuleiro tabuleiro)
        {
            int v = CondicaoDeVitoria(Jogadas);

            if (v == 1)
            {
                tabuleiro.EscreverEm(Convert.ToString(JogadorAtual), 20, 15);

                Console.BackgroundColor = ConsoleColor.White;

                if (JogadorAtual.ToString() == "X")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                tabuleiro.EscreverEm("Venceu!!!", 14, 14); //ATENÇÃO!!! RETIRAR ESSA MENSAGEM. RESPOSABILIDA DA UI
                ReiniciarPartida();
            }
            else if (v == -1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Cyan;

                tabuleiro.EscreverEm("Deu EMPATE!", 17, 15);
                ReiniciarPartida();
            }
            Console.ResetColor();
        }
        public bool PosicaoDisponivel(int linha, int coluna)
        {
            if (Jogadas[Linha, coluna] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RegistrarJogada(char linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

        public int CondicaoDeVitoria(string[,] mat)
        {
            if (VerificarVitoria("X"))
            {
                Terminada = true;
                return 1;  // Vitória de "X"
            }

            if (VerificarVitoria("O"))
            {
                Terminada = true;
                return 1;  // Vitória de "O"
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mat[i, j] == null)
                    {
                        return 0;  // Jogo ainda em andamento
                    }
                }
            }

            return -1;

            bool VerificarVitoria(string jogador)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((mat[i, 0] == jogador && mat[i, 1] == jogador && mat[i, 2] == jogador) ||  // Linha
                        (mat[0, i] == jogador && mat[1, i] == jogador && mat[2, i] == jogador))   // Coluna
                    {
                        return true;
                    }
                }
                if ((mat[0, 0] == jogador && mat[1, 1] == jogador && mat[2, 2] == jogador) ||  // Diagonal principal
                    (mat[0, 2] == jogador && mat[1, 1] == jogador && mat[2, 0] == jogador))   // Diagonal secundária
                {
                    return true;
                }

                return false;
            }
        }
        public void ReiniciarPartida()
        {
            //Este médto está ERRADO. não deveria instanciar e chamar PartidaService diretamente
            //A responsabilidade de iniciar uma nova partida pode ser movida para um serviço de
            //controle ou para a camada de aplicação.

            // Controle de Fluxo
            // A lógica de controle de fluxo(ReiniciarPartida()) está dispersa por várias classes e
            // misturada com a lógica de aplicação e apresentação.
            // Sugestão: Centralize o controle do fluxo do jogo em uma classe específica, que pode
            // ser chamada de GameFlowController, por exemplo.

            //Tabuleiro tabuleiro = new Tabuleiro();
            //PartidaDomainService partidaDomainService = new PartidaDomainService();
            // PartidaAppService partidaAppService = new PartidaAppService(tabuleiro, partidaDomainService);

            _tabuleiro.EscreverEm("                       ", 8, 15);
            _tabuleiro.EscreverEm("Deseja Reinciar (s/n)? ", 10, 16);

            char resp = char.Parse(Console.ReadLine());
            if (resp.Equals('s'))
            {
                _tabuleiro.DesenharTabuleiroJogo();
                //_partidaAppService.IniciarPartida();
            }

            Environment.Exit(1);
        }
        public void MudarJogador()
        {
            if (JogadorAtual == TipoJogador.X)
                JogadorAtual = TipoJogador.O;
            else
            {
                JogadorAtual = TipoJogador.X;
            }
        }
        public void LimparTabuleiro()
        {
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    Jogadas[linha, coluna] = null;
                }

            }
        }

    }
}

