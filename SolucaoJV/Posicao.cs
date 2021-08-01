using System;
using System.Collections.Generic;
using System.Text;
using View;

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
        public void LerJogada()
        {
            try
            {
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
                    LerJogada();
                }
            }
            catch
            {
                Console.SetCursorPosition(20, 15);
                Console.Write("Insira uma posição");
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
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(18, 15);
            Console.Write("Jogada Inválida");
            Console.SetCursorPosition(18, 16);
            Console.Write("Qualquer tecla continua!");
            Console.ReadKey();
            Console.SetCursorPosition(17, 15);
            Console.Write("                             ");
            Console.SetCursorPosition(17, 16);
            Console.Write("                             ");
            Console.SetCursorPosition(17, 1);
        }
    }
}

