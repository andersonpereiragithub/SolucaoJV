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
                       
            partida.PreencherJogada(tab);

            while (!partida.Terminada)
            {
                bool posicao = false;
                Posicao p = new Posicao();
                Console.WriteLine("Turno: {0}", partida.Turno);
                Console.WriteLine("Jogador [{0}]", partida.jogadorAtual);
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Partida.EscreverEm("Posicação Inválida:", 20, 15);
                        Console.ResetColor();
                        Console.ReadKey();
                        Partida.EscreverEm("                       ", 17, 15);
                        p.InserirJogada();
                    }
                }


                partida.PreencherJogada(tab);
                
                partida.MudarJogador();
            }
        }
    }
}
