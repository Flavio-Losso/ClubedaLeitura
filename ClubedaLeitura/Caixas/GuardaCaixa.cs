using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Caixas
{
    internal class GuardaCaixa
    {
        private ArrayList listaCaixa;
        private int id = 0;

        public GuardaCaixa(ArrayList a)
        {
            listaCaixa = a;
        }

        public void Inserir(Caixa caixa)
        {
            id++;

            caixa.Id = id;

            listaCaixa.Add(caixa);
        }

        public ArrayList SelecionarTodos()
        {
            return listaCaixa;
        }

        public void Editar(int id,Caixa ca)
        {
            Caixa caixaEscolhida = SelecionarID(id);

            if(caixaEscolhida != null)
            {
                caixaEscolhida.Cor = ca.Cor;
                caixaEscolhida.Etiqueta = ca.Etiqueta;
            }
        }

        public Caixa SelecionarID(int id)
        {
            Caixa escolhida = null;

            foreach (Caixa c in listaCaixa)
            {
                if (c.Id == id)
                {
                    escolhida = c;
                    break;
                }
            }

            return escolhida;
        }

        public void Excluir(int id)
        {
            Caixa escolhida = SelecionarID(id);
            listaCaixa.Remove(escolhida);
        }
    }
}
