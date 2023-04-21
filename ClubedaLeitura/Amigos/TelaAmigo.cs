using ClubedaLeitura.visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Amigos
{
    internal class TelaAmigo : Tela
    {
        GuardaAmigo guardaAmigo;

        public TelaAmigo(GuardaAmigo guardaAmigo)
        {
            this.guardaAmigo = guardaAmigo;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos \n");
            Console.WriteLine("Digite 1 para Inserir Amigo");
            Console.WriteLine("Digite 2 para Visualizar Amigos");
            Console.WriteLine("Digite 3 para Editar Amigos");
            Console.WriteLine("Digite 4 para Excluir Amigos");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void EditarAmigos()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Amigos");
            Console.WriteLine("Editando um amigo\r\n");
            VisualizarAmigos(false);

            Console.WriteLine();

            Console.Write("Digite o id do Amigo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Pessoa amigoAtualizado = ObterAmigo();

            guardaAmigo.Editar(id, amigoAtualizado);

            MostrarMensagem("Amigo editado com sucesso!");
        }

        public void ExcluirAmigos()
        {
            Iniciar();

            Console.WriteLine("Cadastro de Amigos");
            Console.WriteLine("Excluindo um amigo já cadastrado\r\n");

            Console.Write("Digite o id do Amigo: ");

            int id = Convert.ToInt32(Console.ReadLine());

            guardaAmigo.Excluir(id);

            Console.WriteLine("Amigo excluído com sucesso!");

            Console.ReadLine();
        }

        public void InserirNovoAmigo()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Amigos");
            Console.WriteLine("Inserindo Novo amigo\r\n");
            Pessoa amigo = ObterAmigo();

            guardaAmigo.Inserir(amigo);

            MostrarMensagem("Amigo inserido com sucesso!");
        }

        private Pessoa ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Pessoa amigo = new Pessoa(nome, nomeResponsavel, telefone, endereco);

            return amigo;
        }

        public void VisualizarAmigos(bool v)
        {
            Console.WriteLine("Cadastro de Amigos", "Visualizando amigos já cadastrados...");

            ArrayList amigos = guardaAmigo.SelecionarTodos();

            if (amigos.Count == 0)
            {
                MostrarMensagem("Nenhuma amigo cadastrado");
                return;
            }

            MostrarTabela(amigos);
        }

        private void MostrarTabela(ArrayList amigos)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Nome", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------");

            foreach (Pessoa amigo in amigos)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", amigo.Id, amigo.Nome, amigo.Telefone);
            }
        }
    }
}
