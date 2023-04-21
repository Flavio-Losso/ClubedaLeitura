using ClubedaLeitura.Amigos;
using ClubedaLeitura.Revistas;
using ClubedaLeitura.visual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Emprestimos
{
    internal class TelaEmprestimo : Tela
    {
        private GuardaEmprestimo guardaEmprestimo;

        private TelaRevista telaRevista;
        private GuardaRevista guardaRevista;

        private GuardaAmigo guardaAmigo;
        private TelaAmigo telaAmigo;

        public TelaEmprestimo(
            GuardaEmprestimo repositorioEmprestimo,
            TelaRevista telaRevista,
            GuardaRevista repositorioRevista,
            TelaAmigo telaAmigo,
            GuardaAmigo repositorioAmigo)
        {
            this.guardaEmprestimo = repositorioEmprestimo;
            this.telaRevista = telaRevista;
            this.guardaRevista = repositorioRevista;
            this.telaAmigo = telaAmigo;
            this.guardaAmigo = repositorioAmigo;
        }

        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Emprestimos \n");

            Console.WriteLine("Digite 1 para Abrir Novo Emprestimo");
            Console.WriteLine("Digite 2 para Visualizar Emprestimos");
            Console.WriteLine("Digite 3 para Visualizar Emprestimos no Mês");
            Console.WriteLine("Digite 4 para Visualizar Emprestimos em Aberto no Dia");
            Console.WriteLine("Digite 5 para Fechar Emprestimos");
            Console.WriteLine("Digite 6 para Editar Emprestimos");
            Console.WriteLine("Digite 7 para Excluir Emprestimos");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void AbrirNovoEmprestimo()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Abrindo um novo emprestimo...");

            Emprestimo emprestimo = ObterEmprestimo();

            guardaEmprestimo.Inserir(emprestimo);

            MostrarMensagem("Empréstimo aberto com sucesso!");
        }

        public void FecharEmprestimo()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Fechando um empréstimo...");

            //Visulizar os emprestimos que estão abertos

            ArrayList emprestimosEmAberto = guardaEmprestimo.SelecionarEmprestimosEmAberto();

            if (emprestimosEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado");
                return;
            }

            MostrarTabela(emprestimosEmAberto);

            //Escolher um emprestimo

            Console.Write("Digite o id do Empréstimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimo = guardaEmprestimo.SelecionarID(id);

            //Fechar o emprestimo
            emprestimo.Fechar();

            MostrarMensagem("Empréstimo fechado com sucesso!");
        }

        public void EditarEmprestimos()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Editando um empréstimo já cadastrado...");

            VisualizarEmprestimos(false);

            Console.WriteLine();

            Console.Write("Digite o id do empréstimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimoAtualizado = ObterEmprestimo();

            guardaEmprestimo.Editar(id, emprestimoAtualizado);

            MostrarMensagem("Empréstimo editado com sucesso!");
        }

        public void ExcluirEmprestimos()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Excluindo um empréstimo já cadastrado...");

            VisualizarEmprestimos(false);

            Console.WriteLine();

            Console.Write("Digite o id do empréstimo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            guardaEmprestimo.Excluir(id);

            MostrarMensagem("Empréstimo excluído com sucesso!");
        }

        public void VisualizarEmprestimos(bool mostrarCabecalho)
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Visualizando empréstimos já cadastrados...");

            ArrayList emprestimos = guardaEmprestimo.SelecionarTodos();

            if (emprestimos.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado");
                return;
            }

            MostrarTabela(emprestimos);
        }

        public void VisualizarEmprestimosEmAbertoNoDia()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Visualizando empréstimos em aberto no dia...");

            Console.Write("Digite a data: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            ArrayList emprestimosEmAberto = guardaEmprestimo.SelecionarEmprestimosEmAbertoNoDia(data);

            if (emprestimosEmAberto.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado");
                return;
            }

            MostrarTabela(emprestimosEmAberto);
        }

        public void VisualizarEmprestimosNoMes()
        {
            Iniciar();
            Console.WriteLine("Cadastro de Empréstimos", "Visualizando empréstimos no mês...");

            Console.Write("Digite o número o Mês e o Ano: ");

            string[] mesEhAno = Console.ReadLine().Split("/");

            int mes = Convert.ToInt32(mesEhAno[0]);
            int ano = Convert.ToInt32(mesEhAno[1]);

            ArrayList emprestimosDoMes = guardaEmprestimo.SelecionarEmprestimosDoMes(mes, ano);

            if (emprestimosDoMes.Count == 0)
            {
                MostrarMensagem("Nenhuma empréstimo cadastrado");
                return;
            }

            MostrarTabela(emprestimosDoMes);
        }

        private void MostrarTabela(ArrayList emprestimos)
        {
            Console.WriteLine();

            Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20} | {4, -10}", "Id", "Revista", "Amigo", "Data do Empréstimo", "Status");

            Console.WriteLine("---------------------------------------------------------------------------------------------");

            foreach (Emprestimo emprestimo in emprestimos)
            {
                string status = emprestimo.EstaAberto ? "Aberto" : "Fechado";

                Console.WriteLine("{0, -10} | {1, -40} | {2, -20} | {3, -20} | {4, -10}",
                    emprestimo.Id, emprestimo.Revista.Titulo, emprestimo.Amigo.Nome, emprestimo.DataEmprestimo, status);
            }
        }

        private Emprestimo ObterEmprestimo()
        {
            //Visualizar as revistas
            telaRevista.VisualizarRevistas(false);

            //escolher uma revista
            Console.Write("Digite o id da revista: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Revista revista = guardaRevista.SelecionarID(idRevista);

            //Visulizar os amigos

            telaAmigo.VisualizarAmigos(false);

            //escolher um amigo
            Console.Write("Digite o id do amigo: ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            Pessoa amigo = guardaAmigo.SelecionarPorId(idEmprestimo);

            //escolher uma data
            Console.Write("Digite a data: ");
            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

            Emprestimo emprestimo = new Emprestimo(dataEmprestimo, revista, amigo);

            return emprestimo;
        }
    }
}
