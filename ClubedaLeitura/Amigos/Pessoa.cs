using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Amigos
{
    internal class Pessoa
    {
        private int id;
        private string nome;
        private string nomeDoResponsavel;
        private string telefone;
        private string endereco;
        private string? nomeResponsavel;

        public string Nome { get => nome; set => nome = value; }
        public string NomeDoResponsavel { get => nomeDoResponsavel; set => nomeDoResponsavel = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public int Id { get => id; set => id = value; }

        public Pessoa(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            Nome = nome;
            NomeDoResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
