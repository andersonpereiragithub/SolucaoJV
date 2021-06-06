using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Tela
    {
        public static void ViewTela()
        {
            Partida partida = new Partida();
            string[,] tab = new string[3, 3];
                       
            partida.ImprimirTelaJogo(tab);

            while (!partida.Terminada)
            {
                bool posicao = false;
                Posicao p = new Posicao();
                Console.WriteLine("Turno: {0}", partida.Turno);
                Console.Write("Jogador [");
                Partida.EscreverEm(Convert.ToString(partida.jogadorAtual), 9, 14);
                Partida.EscreverEm("]", 10, 14);
                p.InserirJogada();
                
                while (!posicao)
                {
                    if (tab[p.Linha, p.Coluna] == null)
                    {
                        tab[p.Linha, p.Coluna] = Convert.ToString(partida.jogadorAtual);
                        posicao = true;
                    }
                    else
                    {
                        p.JogadaInvalida();
                        p.InserirJogada();
                    }
                }


                partida.ImprimirTelaJogo(tab);
                
                partida.MudarJogador();
            }
        }
    }
}
