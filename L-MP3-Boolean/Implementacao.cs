using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_MP3_Boolean
{
    public class Implementacao
    {
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public Boolean Vendido { get; set; }



        public Implementacao(string categoria, string titulo, string autor)
        {
            Categoria = categoria;
            Titulo = titulo;
            Autor = autor;
            Vendido = false;
        }


    }
}
