using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matricula.Models
{
    public class Artigo
    {
        public string titulo { get; set; }
        public string img { get; set; }
        public string conteudo { get; set; }
        public bool isPrincipal { get; set; }

        public Artigo(string titulo, string img, string conteudo, bool isPrincipal)
        {
            this.titulo = titulo;
            this.img = img;
            this.conteudo = conteudo;
            this.isPrincipal = isPrincipal;
        }
    }
}