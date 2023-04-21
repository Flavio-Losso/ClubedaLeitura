using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.visual
{
    internal class Tela
    {
        public void Iniciar()
        {
            Console.Clear();
        }
        public void MostrarMensagem(String mensagem)
        {
            Console.WriteLine(mensagem);

            Console.ReadLine();
        }
    }
}
