using ClubedaLeitura.Caixas;
using ClubedaLeitura.visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Revistas
{
    internal class TelaRevista : Tela
    {
        public GuardaRevista guardaRevista;
        public GuardaCaixa guardaCaixa;
        public TelaCaixa telaCaixa;

        public TelaRevista(GuardaRevista repoRevista, GuardaCaixa repoCaixa, TelaCaixa telaCaixa)
        {
            this.guardaRevista = repoRevista;
            this.guardaCaixa = repoCaixa;
            this.telaCaixa = telaCaixa;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de revistas\n");

            Console.WriteLine("1 para Inserir revista");
            Console.WriteLine("2 para Visualizar revista");
            Console.WriteLine("3 para Editar revista");
            Console.WriteLine("4 para Excluir revista");
            Console.WriteLine("s para Sair");

            string op = Console.ReadLine();

            return op;
        }

        public void InserirNovaRevista()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Revistas", "Inserindo uma nova revista...");

            Revista revista = ObterRevista();

            guardaRevista.Inserir(revista);

            MostrarMensagem("Revista inserida com sucesso!");
        }

        private Revista ObterRevista()
        {
            telaCaixa.VisualizarCaixas(false);

            Console.Write("Digite o id da caixa: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());
            Caixa caixa = guardaCaixa.SelecionarID(idCaixa);

            Console.Write("Digite o título: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a coleção: ");
            string colecao = Console.ReadLine();

            Console.Write("Digite o ano: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a edição: ");
            int edicao = Convert.ToInt32(Console.ReadLine());

            Revista revista = new Revista(colecao, edicao, ano, caixa,titulo);

            return revista;
        }

        public void VisualizarRevistas(bool mostrarCabecalho)
        {
            Iniciar();
            Console.WriteLine("Cadastro de Revistas", "Visualizando revistas já cadastradas...");

            ArrayList revistas = guardaRevista.SelecionarTodos();

            if (revistas.Count == 0)
            {
                MostrarMensagem("Nenhuma revista cadastrada");
                return;
            }

            MostrarTabela(revistas);
        }

        private void MostrarTabela(ArrayList revistas)
        {
            Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", "Id", "Título", "Cor da Caixa");

            Console.WriteLine("---------------------------------------------------------");

            foreach (Revista revista in revistas)
            {
                Console.WriteLine("{0, -10} | {1, -40} | {2, -20}", revista.Id, revista.Titulo, revista.Caixa.Cor);
            }
        }

        public void EditarRevistas()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Revistas", "Editando uma revista já cadastrada...");

            VisualizarRevistas(false);

            Console.WriteLine();

            Console.Write("Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Revista revistaAtualizada = ObterRevista();

            guardaRevista.Editar(id, revistaAtualizada);

            MostrarMensagem("Revista editada com sucesso!");
        }

        public void ExcluirRevistas()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Revistas", "Excluindo uma revista já cadastrada...");

            VisualizarRevistas(false);

            Console.WriteLine();

            Console.Write("Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());

            guardaRevista.Excluir(id);

            MostrarMensagem("Revista excluída com sucesso!");
        }
    }
}
