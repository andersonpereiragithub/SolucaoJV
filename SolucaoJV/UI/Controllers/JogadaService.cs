using System;
using System.Threading;
using SolucaoJV.Application.Interfaces;
namespace SolucaoJV.UI.Controllers
{
    class JogadaService : IJogadaService
    {

        public (int, int)? LerJogada()
        {
            while (true)
            {
                string jogada = Console.ReadLine();

                if (jogada == null)
                {
                    return null;
                }

                jogada = jogada.Trim().ToLower();

                if (JogadaValida(jogada))
                {
                    char linha = jogada[0];
                    int coluna = int.Parse(jogada[1] + "");

                    RegistrarJogada(linha, coluna);

                    return (ConverterLinha(linha), coluna - 1);
                }

                JogadaInvalida();
            }
        }

        public (int, int) RegistrarJogada(int linha, int coluna)
        {
            int linhaIndex = linha - 'a';
            int colunaIndex = coluna - 1;
            return (linhaIndex, colunaIndex);
        }

        private void JogadaInvalida()
        {
            int tempo = 3;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(17, 15);
                Console.WriteLine($"Jogada Inválida...({tempo})");
                Thread.Sleep(1000);
                tempo--;
            }
            Console.SetCursorPosition(17, 15);
            
            Console.Write(new string(' ', 25));
            
            Console.SetCursorPosition(17, 15);
        }

        private int ConverterLinha(char linha)
        {
            return linha switch
            {
                'a' => 0,
                'b' => 1,
                'c' => 2,
                _ => throw new ArgumentException("Linha inválida")
            };
        }
        private bool JogadaValida(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length != 2)
            {
                return false;
            }
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
        public bool DesejaReiniciar()
        {
            string jogarNovamente = Console.ReadLine();

            if (jogarNovamente == null)
            {
                return false;
            }

            jogarNovamente = jogarNovamente.Trim().ToLower();

            return jogarNovamente == "s";
        }
    }
}
