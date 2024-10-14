using System;
using System.Collections.Generic;
using System.Text;
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

        public (int, int) LerJogada()
        {
            string jogada = Console.ReadLine().ToLower();

            if (_posicao.JogadaValida(jogada))
            {
                char linha = jogada[0];
                int coluna = int.Parse(jogada[1] + "");
                
                RegistrarJogada(linha, coluna);
                
                return (ConverterLinha(linha), coluna - 1); // Subtrai 1 para adequar à matriz 0-indexada
            }
            else
            {
                JogadaInvalida();
                return LerJogada();
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
            Console.WriteLine("Jogada inválida. Tente novamente.");
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
