using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubedaLeitura.Caixas
{
    internal class Caixa
    {
        private string cor, etiqueta;
        private int id;

        public string Cor { get { return cor; } set { cor = value; } }
        public string Etiqueta { get => etiqueta; set => etiqueta = value; }
        public int Id { get => id; set => id = value; }

        public Caixa(string c, string e) 
        {
            Cor = c;
            Etiqueta = e;
        }
    }
}
