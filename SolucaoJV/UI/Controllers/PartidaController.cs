using System;
using SolucaoJV.Application.Services;
using SolucaoJV.Domain.Entities;
using SolucaoJV.Domain.Services;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV.UI.Controllers
{
    internal class PartidaController
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public void MudarJogador(TipoJogador jogadorAtual)
        {
            if (jogadorAtual == TipoJogador.X)
                jogadorAtual = TipoJogador.O;
        }
        public void RegistrarJogada(int linha, int coluna)
        {
            Linha = linha - 'a';
            Coluna = coluna - 1;
        }
    }
}
