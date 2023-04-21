using ClubedaLeitura.Caixas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Revistas
{
    internal class GuardaRevista
    {
        private ArrayList listaRevista;
        private int id = 0;

        public GuardaRevista(ArrayList listaRevista)
        {
            this.listaRevista = listaRevista;
        }

        public void Inserir(Revista revista)
        {
            id++;
            revista.Id = id;
            listaRevista.Add(revista);
        }

        public void Editar(int id,Revista rn)
        {
            Revista revistaEscolhida = SelecionarID(id);
            if (revistaEscolhida != null)
            {
                revistaEscolhida.Titulo = rn.Titulo;
                revistaEscolhida.Ano = rn.Ano;
                revistaEscolhida.Edicao = rn.Edicao;
                revistaEscolhida.Caixa = rn.Caixa;
            }
        }

        public Revista SelecionarID(int id)
        {
            Revista escolhida = null;

            foreach (Revista r in listaRevista)
            {
                if (r.Id == id)
                {
                    escolhida = r;
                    break;
                }
            }

            return escolhida;
        }

        public void Excluir(int id)
        {
            Revista revista = SelecionarID(id);

            listaRevista.Remove(revista);
        }

        public bool EstaCaixaTemRevista(Caixa caixa)
        {
            bool caixaTemRevista = false;

            foreach (Revista revista in listaRevista)
            {
                if (revista.Caixa.Id == caixa.Id)
                {
                    caixaTemRevista = true;
                    break;
                }
            }

            return caixaTemRevista;
        }

        public ArrayList SelecionarTodos()
        {
            return listaRevista;
        }
    }
}
