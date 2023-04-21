using ClubedaLeitura.Revistas;
using ClubedaLeitura.visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Caixas
{
    internal class TelaCaixa : Tela
    {
        public GuardaRevista guardaRevista;
        public GuardaCaixa guardaCaixa;

        public TelaCaixa(GuardaRevista repoRevista, GuardaCaixa repoCaixa)
        {
            this.guardaRevista = repoRevista;
            this.guardaCaixa = repoCaixa;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixa\n");

            Console.WriteLine("1 para Inserir Caixa");
            Console.WriteLine("2 para Visualizar Caixa");
            Console.WriteLine("3 para Editar Caixa");
            Console.WriteLine("4 para Excluir Caixa");
            Console.WriteLine("s para Sair");

            string op = Console.ReadLine();

            return op;
        }

        public void InserirNovaCaixa()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Caixas", "Inserindo uma nova caixa...");

            Caixa caixa = ObterCaixa();

            guardaCaixa.Inserir(caixa);

            MostrarMensagem("Caixa inserida com sucesso!");
        }

        public void VisualizarCaixas(bool mostrarCabecalho)
        {
            Iniciar();
            Console.WriteLine("Cadastro de Caixas", "Visualizando caixas já cadastradas...");

            ArrayList caixas = guardaCaixa.SelecionarTodos();

            if (caixas.Count == 0)
            {
                MostrarMensagem("Nenhuma caixa cadastrada");
                return;
            }

            MostrarTabela(caixas);

        }

        public void EditarCaixas()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Caixas", "Editando uma caixa já cadastrada...");

            VisualizarCaixas(false);

            Console.WriteLine();

            Console.Write("Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixaAtualizada = ObterCaixa();

            guardaCaixa.Editar(id, caixaAtualizada);

            MostrarMensagem("Caixa editada com sucesso!");
        }

        public void ExcluirCaixas()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Caixas", "Excluindo uma caixa já cadastrada...");

            VisualizarCaixas(false);

            Console.WriteLine();

            Console.Write("Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = guardaCaixa.SelecionarID(id);

            bool caixaTemRevista = guardaRevista.EstaCaixaTemRevista(caixa);

            if (caixaTemRevista)
            {
                MostrarMensagem("Esta caixa tem revista");
                return;
            }

            guardaCaixa.Excluir(id);

            MostrarMensagem("Caixa excluída com sucesso!");
        }

        private void MostrarTabela(ArrayList caixas)
        {
            Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", "Id", "Etiqueta", "Cor");

            Console.WriteLine("---------------------------------------------------------");

            foreach (Caixa caixa in caixas)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20}", caixa.Id, caixa.Etiqueta, caixa.Cor);
            }
        }

        private Caixa ObterCaixa()
        {
            Console.Write("Digite a cor: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta: ");
            string etiqueta = Console.ReadLine();

            Caixa caixa = new Caixa(cor, etiqueta);

            return caixa;
        }
    }
}
