using ClubedaLeitura.Caixas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Emprestimos
{
    internal class GuardaEmprestimo
    {
        private ArrayList listaemprestimo;
        private int id = 0;

        public GuardaEmprestimo(ArrayList listaemprestimo)
        {
            this.listaemprestimo = listaemprestimo;
        }

        public void Inserir(Emprestimo emprestimo)
        {
            id++;
            emprestimo.Id = id;
            listaemprestimo.Add(emprestimo);
        }

        public ArrayList SelecionarTodos()
        {
            return listaemprestimo;
        }

        public void Editar(int id, Emprestimo emprestado)
        {
            Emprestimo emprestimoSelecionado = SelecionarID(id);

            if (emprestimoSelecionado != null)
            {
                emprestimoSelecionado.Amigo = emprestado.Amigo;
                emprestimoSelecionado.Revista = emprestado.Revista;
                emprestimoSelecionado.DataEmprestimo = emprestado.DataEmprestimo;
                emprestimoSelecionado.DataDevolucao = emprestado.DataDevolucao;
            }
        }

        public Emprestimo SelecionarID(int id)
        {
            Emprestimo escolhido = null;

            foreach (Emprestimo e in listaemprestimo)
            {
                if (e.Id == id)
                {
                    escolhido = e;
                    break;
                }
            }

            return escolhido;
        }

        public void Excluir(int id)
        {
            Emprestimo escolhido = SelecionarID(id);
            listaemprestimo.Remove(escolhido);
        }

        public ArrayList SelecionarEmprestimosEmAberto()
        {
            ArrayList emprestimoEmAberto = new ArrayList();

            foreach (Emprestimo e in listaemprestimo)
            {
                if (e.EstaAberto)
                    emprestimoEmAberto.Add(e);
            }

            return emprestimoEmAberto;
        }

        public ArrayList SelecionarEmprestimosEmAbertoNoDia(DateTime data)
        {
            ArrayList emprestimoEmAberto = new ArrayList();

            foreach (Emprestimo e in listaemprestimo)
            {
                if (e.EstaAberto && e.DataEmprestimo.Date == data.Date)
                    emprestimoEmAberto.Add(e);
            }

            return emprestimoEmAberto;
        }

        public ArrayList SelecionarEmprestimosDoMes(int mes, int ano)
        {
            ArrayList emprestimosDoMes = new ArrayList();

            foreach (Emprestimo e in listaemprestimo)
            {
                if (e.DataEmprestimo.Month == mes && e.DataEmprestimo.Year == ano)
                    emprestimosDoMes.Add(e);
            }

            return emprestimosDoMes;
        }
    }
}
