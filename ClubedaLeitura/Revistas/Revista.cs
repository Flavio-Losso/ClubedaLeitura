using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClubedaLeitura.Caixas;

namespace ClubedaLeitura.Revistas
{
    internal class Revista
    {
        private int id;
        private string titulo;
        private string colecao;
        private int edicao;
        private int ano;
        private Caixa caixa;

        public string Colecao { get => colecao; set => colecao = value; }
        public int Edicao { get => edicao; set => edicao = value; }
        public int Ano { get => ano; set => ano = value; }
        public int Id { get => id; set => id = value; }
        internal Caixa Caixa { get => caixa; set => caixa = value; }
        public string Titulo { get => titulo; set => titulo = value; }

        public Revista(string colecao, int edicao, int ano, Caixa caixa, string titulo)
        {
            Colecao = colecao;
            Edicao = edicao;
            Ano = ano;
            Caixa = caixa;
            Titulo = titulo;
        }
    }
}
