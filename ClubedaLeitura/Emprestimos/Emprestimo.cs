using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubedaLeitura.Amigos;
using ClubedaLeitura.Revistas;

namespace ClubedaLeitura.Emprestimos
{
    internal class Emprestimo
    {
        private int id;
        private DateTime dataEmprestimo;
        private DateTime dataDevolucao;
        private Revista revista;
        private Pessoa amigo;

        private bool estaAberto;

        public int Id { get => id; set => id = value; }
        public DateTime DataEmprestimo { get => dataEmprestimo; set => dataEmprestimo = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public bool EstaAberto { get => estaAberto; set => estaAberto = value; }
        internal Revista Revista { get => revista; set => revista = value; }
        internal Pessoa Amigo { get => amigo; set => amigo = value; }

        public Emprestimo(DateTime dataEmprestimo, Revista revista, Pessoa amiguinho) 
        {
            DataEmprestimo = dataEmprestimo;
            Revista = revista;
            Amigo = amiguinho;
            EstaAberto = true;
        }

        public void Fechar()
        {
            if(EstaAberto)
            {
                EstaAberto = false;
                DataDevolucao = DateTime.Now;
            }
        }
    }
}
