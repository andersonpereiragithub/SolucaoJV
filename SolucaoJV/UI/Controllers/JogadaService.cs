using System;
using SolucaoJV.Application.Interfaces;

namespace SolucaoJV.UI.Controllers
{
    class JogadaService : IJogadaService
    {
        private readonly IMensagemService _mensagemService;

        public JogadaService(IMensagemService mensagemService)
        {
            _mensagemService = mensagemService;
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

                if (JogadaValida(jogada))
                {
                    char linha = jogada[0];
                    int coluna = int.Parse(jogada[1].ToString());

                    return (ConverterLinha(linha), coluna - 1);
                }

                _mensagemService.ExibirJogadaInvalida();
            }
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
            return (str[0] == 'a' || str[0] == 'b' || str[0] == 'c') &&
                   (str[1] == '1' || str[1] == '2' || str[1] == '3');
        }
        public bool DesejaReiniciar()
        {
            string resposta = Console.ReadLine();

            if (resposta == null)
            {
                return false;
            }

            resposta = resposta.Trim().ToLower();

            return resposta == "s";
        }
    }
}
