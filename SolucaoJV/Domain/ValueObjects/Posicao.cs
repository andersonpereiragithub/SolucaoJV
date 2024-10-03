using System;
using SolucaoJV.UI.Controllers;
using SolucaoJV.Domain.Services;
using System.Diagnostics;
using System.Threading;
using SolucaoJV.Domain.Entities;

namespace SolucaoJV.Domain.ValueObjects
{
    //Encapsulamento =>> Muitos atributos públicos nas classes(Linha, Coluna, Jogadas, etc.)
    //poderiam ser melhor encapsulados.
    // Sugestão: Torne esses atributos privados e use métodos para acessar ou modificar os
    // valores, aplicando as regras de negócio apropriadas.

    class Posicao
    {
        public int Linha { get; set; } //
        public int Coluna { get; set; }

        public bool JogadaValida(string str)
        {
            if ((str[0] == 'a' || str[0] == 'b' || str[0] == 'c') &&
                (str[1] == '1' || str[1] == '2' || str[1] == '3'))
                return true;
            else
                return false;
        }
    }
}

