using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Models
{
    public class MyViewModel
    {
        public Matricula matricula { get; set; }
        public ICollection<CursoDisciplina> cursodisciplina { get; set; }
        public IEnumerable<Disciplina> disciplinas { get; set; }
        public IEnumerable<ICollection<ProfessorDisciplina>> professordisciplina { get; set; }
        public IEnumerable<Professor> professor { get; set; }

    }
}