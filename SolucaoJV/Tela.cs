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
            partida.PreencherTela(tab);
            partida.PreencherJogada(tab);

            while (!partida.Terminada)
            {
                Posicao p = new Posicao();
                Console.WriteLine("Turno: {0}", partida.Turno);
                Console.WriteLine("Jogador [{0}]", partida.jogadorAtual);
                Console.Write("\tSua vez: ");
                p.IncerirJogada();
                tab[p.Linha, p.Coluna] = " " + Convert.ToString(partida.jogadorAtual);

                partida.PreencherJogada(tab);
                
                partida.MudarJogador();
            }
        }
    }
}
