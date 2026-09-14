namespace SolucaoJV.Domain.Entities
{
    class Jogador
    {
        public string Nome { get; set; }
        public TipoJogador Tipo { get; set; }

        public Jogador(string nome, TipoJogador tipo)
        {
            Nome = nome;
            Tipo = tipo;
        }
    }
}
