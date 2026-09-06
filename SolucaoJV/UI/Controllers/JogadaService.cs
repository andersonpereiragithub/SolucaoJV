using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SolucaoJV.Domain.ValueObjects;
namespace SolucaoJV.UI.Controllers
{
    class JogadaService
    {
        private readonly Posicao _posicao;

        public JogadaService(Posicao posicao)
        {
            _posicao = posicao;
        }

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

                if (_posicao.JogadaValida(jogada))
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
    }
}
