using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Amigos
{
    internal class GuardaAmigo
    {
        private ArrayList listaAmigo;
        private int id = 0;

        public GuardaAmigo(ArrayList listaAmigo)
        {
            this.listaAmigo = listaAmigo;
        }

        public void Inserir(Pessoa amigo)
        {
            id++;

            amigo.Id = id;

            listaAmigo.Add(amigo);
        }

        public void Editar(int id, Pessoa amigoAtualizado)
        {
            Pessoa amigo = SelecionarPorId(id);

            amigo.Nome = amigoAtualizado.Nome;
            amigo.NomeDoResponsavel = amigoAtualizado.NomeDoResponsavel;
            amigo.Telefone = amigoAtualizado.Telefone;
            amigo.Endereco = amigoAtualizado.Endereco;
        }

        public void Excluir(int id)
        {
            Pessoa amigo = SelecionarPorId(id);

            listaAmigo.Remove(amigo);
        }

        public Pessoa SelecionarPorId(int id)
        {
            Pessoa amigoSelecionado = null;

            foreach (Pessoa c in listaAmigo)
            {
                if (c.Id == id)
                {
                    amigoSelecionado = c;
                    break;
                }
            }

            return amigoSelecionado;
        }

        public ArrayList SelecionarTodos()
        {
            return listaAmigo;
        }
    }
}
