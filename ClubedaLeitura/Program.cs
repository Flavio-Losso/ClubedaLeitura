using System.Collections;
using ClubedaLeitura.Amigos;
using ClubedaLeitura.Caixas;
using ClubedaLeitura.Emprestimos;
using ClubedaLeitura.Revistas;
using ClubedaLeitura.visual;

namespace ClubedaLeitura
{
    internal class Program
    {
        private static List<Emprestimo> emprestado = new List<Emprestimo>();
        static void Main(string[] args)
        {
            GuardaAmigo repositorioAmigo = new GuardaAmigo(new ArrayList());
            GuardaCaixa repoCaixa = new GuardaCaixa(new ArrayList());
            GuardaRevista repositorioRevista = new GuardaRevista(new ArrayList());
            GuardaEmprestimo repositorioEmprestimo = new GuardaEmprestimo(new ArrayList());

            //PopularRepositorios(repositorioAmigo, repoCaixa, repositorioRevista, repositorioEmprestimo);

            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
            TelaCaixa telaCaixa = new TelaCaixa(repositorioRevista, repoCaixa);
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repoCaixa, telaCaixa);
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo
                (repositorioEmprestimo, telaRevista, repositorioRevista, telaAmigo, repositorioAmigo);
            while (true)
            {
                TelaPrincipal telaPrincipal = new TelaPrincipal();

                string opcao = telaPrincipal.ApresentarMenu();

                if (opcao == "s") break;
                switch (opcao)
                {
                    case "1":
                        string opcaoCaixa = telaCaixa.ApresentarMenu();

                        if (opcaoCaixa == "1")
                        {
                            telaCaixa.InserirNovaCaixa();
                        }
                        else if (opcaoCaixa == "2")
                        {
                            telaCaixa.VisualizarCaixas(true);
                            Console.ReadLine();
                        }
                        else if (opcaoCaixa == "3")
                        {
                            telaCaixa.EditarCaixas();
                        }
                        else if (opcaoCaixa == "4")
                        {
                            telaCaixa.ExcluirCaixas();
                        }

                        break;
                    case "2":
                        string opcaoAmigo = telaAmigo.ApresentarMenu();

                        if (opcaoAmigo == "1")
                        {
                            telaAmigo.InserirNovoAmigo();
                        }
                        else if (opcaoAmigo == "2")
                        {
                            telaAmigo.VisualizarAmigos(true);
                            Console.ReadLine();
                        }
                        else if (opcaoAmigo == "3")
                        {
                            telaAmigo.EditarAmigos();
                        }
                        else if (opcaoAmigo == "4")
                        {
                            telaAmigo.ExcluirAmigos();
                        }

                        break;
                    case "3":
                        string opcaoRevista = telaRevista.ApresentarMenu();

                        if (opcaoRevista == "1")
                        {
                            telaRevista.InserirNovaRevista();
                        }
                        else if (opcaoRevista == "2")
                        {
                            telaRevista.VisualizarRevistas(true);
                            Console.ReadLine();
                        }
                        else if (opcaoRevista == "3")
                        {
                            telaRevista.EditarRevistas();
                        }
                        else if (opcaoRevista == "4")
                        {
                            telaRevista.ExcluirRevistas();
                        }

                        break;
                    case "4":
                        string opcaoEmprestimo = telaEmprestimo.ApresentarMenu();

                        if (opcaoEmprestimo == "1")
                        {
                            telaEmprestimo.AbrirNovoEmprestimo();
                        }
                        else if (opcaoEmprestimo == "2")
                        {
                            telaEmprestimo.VisualizarEmprestimos(true);
                            Console.ReadLine();
                        }
                        else if (opcaoEmprestimo == "3")
                        {
                            telaEmprestimo.VisualizarEmprestimosNoMes();
                            Console.ReadLine();
                        }
                        else if (opcaoEmprestimo == "4")
                        {
                            telaEmprestimo.VisualizarEmprestimosEmAbertoNoDia();
                            Console.ReadLine();
                        }
                        else if (opcaoEmprestimo == "5")
                        {
                            telaEmprestimo.FecharEmprestimo();
                        }
                        else if (opcaoEmprestimo == "6")
                        {
                            telaEmprestimo.EditarEmprestimos();
                        }
                        else if (opcaoEmprestimo == "7")
                        {
                            telaEmprestimo.ExcluirEmprestimos();
                        }


                        break;
                }
            }
        }
    }
}