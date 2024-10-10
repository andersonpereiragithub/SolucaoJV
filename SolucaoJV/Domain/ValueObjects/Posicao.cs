using System;
using SolucaoJV.UI.Controllers;
using SolucaoJV.Domain.Services;
using System.Diagnostics;
using System.Threading;
using SolucaoJV.Domain.Entities;

namespace SolucaoJV.Domain.ValueObjects
{
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

