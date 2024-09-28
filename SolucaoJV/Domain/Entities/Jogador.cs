using System;
using System.Collections.Generic;
using System.Text;

namespace SolucaoJV.Domain.Entities
{
    class Jogador
    {
        public string Name { get; set; }
        public TipoJogador Tipo { get; set; }

        public Jogador(string name, TipoJogador tipo)
        {
            Name = name;
            Tipo = tipo;
        }

        public void CondicaoDeVitoria() { 

        }

    }
}
