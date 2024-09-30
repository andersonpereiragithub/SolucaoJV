﻿using System;
using SolucaoJV.UI.Controllers;
using SolucaoJV.Domain.Services;
using System.Diagnostics;
using System.Threading;

namespace SolucaoJV.Domain.ValueObjects
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        
        public void LerJogada()
        {
            try
            {
                string jogada = Console.ReadLine();

                if (JogadaValida(jogada))
                {
                    char linha = jogada[0];
                    int coluna = int.Parse(jogada[1] + "");
                    //RegistrarJogada(linha, coluna);
                }
                else
                {
                    JogadaInvalida();
                }
            }
            catch
            {
                JogadaInvalida();
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
            int t = 3;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            for (int i = 0; i < 3; i++)
            {
                PosicaoCursorMsg($"Jogada Inválida...({t})");
                Thread.Sleep(1000);
                t--;
            }

            LimpaMsg();
        }

        private void LimpaMsg()
        {
            PosicaoCursorMsg("                           ");
            PosicaoCursorMsg("");
        }

        private void PosicaoCursorMsg(string msg)
        {
            Console.SetCursorPosition(17, 15);
            Console.Write(msg);
            Thread.Sleep(1000);
        }
    }
}

