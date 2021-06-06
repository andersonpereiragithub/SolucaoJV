using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public void InserirJogada()
        {
            Partida.EscreverEm("Sua vez: ", 8, 15);
            string jogada = Console.ReadLine();
            
            if (JogadaValida(jogada))
            {
                char linha = jogada[0];
                int coluna = int.Parse(jogada[1] + "");
                InserirJogada(linha, coluna);
            }
            else
            {
                JogadaInvalida();   
                InserirJogada();
            }
        }

        public bool JogadaValida(string str)
        {
            if ((str[0] == 'a' || str[0] == 'b' || str[0] == 'c') &&
                (str[1] == '1' || str[1] == '2' || str[1] == '3'))
            {
                return true;
            }
            else
            {
                
                return false;
            }
        }
        public void InserirJogada(char linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }
        public void JogadaInvalida()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Partida.EscreverEm("Posicação Inválida", 20, 15);
            Partida.EscreverEm("Qualquer tecla continua!", 20, 16);
            Console.ResetColor();
            Console.ReadKey();
            Partida.EscreverEm("                             ", 17, 15);
            Partida.EscreverEm("                             ", 17, 16);
        }
    }
}

