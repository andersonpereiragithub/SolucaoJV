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
            char linha = jogada[0];
            int coluna = int.Parse(jogada[1] + "");

            InserirJogada(linha, coluna);
        }
        public void InserirJogada(char linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }

    }
}
