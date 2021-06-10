using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

         public void InserirJogada(char linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }
        public void InserirJogada()
        {
            try
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Tela.EscreverEm("Sua vez: ", 8, 15);
                string jogada = Console.ReadLine();
                Tela.EscreverEm("Sua vez:   ", 8, 15);
                Console.ResetColor();

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
            catch(Exception e)
            {
                Tela.EscreverEm(Convert.ToString(e.Message), 20, 15);
            }
        }

        public bool JogadaValida(string str)
        {
            if ((str[0] == 'a' || str[0] == 'b' || str[0] == 'c') &&
                (str[1] == '1' || str[1] == '2' || str[1] == '3'))
                return true;
            else
                return false;
        }
       
        public void JogadaInvalida()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Tela.EscreverEm("Jogada Inválida", 18, 15);
            Tela.EscreverEm("Qualquer tecla continua!", 8, 16);
            Console.ResetColor();
            Console.ReadKey();
            Tela.EscreverEm("                             ", 17, 15);
            Tela.EscreverEm("                             ", 8, 16);
        }
    }
}

