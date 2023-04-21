using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.visual
{
    internal class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Clube da Leitura\n");

            Console.WriteLine("Digite 1 para cadastrar Caixas");
            Console.WriteLine("Digite 2 para cadastrar Amigos");
            Console.WriteLine("Digite 3 para cadastrar Revistas");
            Console.WriteLine("Digite 4 para cadastrar Empréstimos\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
