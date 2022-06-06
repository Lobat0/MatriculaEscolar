using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MatriculaAcademica.Models;

namespace MatriculaAcademica.Models
{
    public class ImpressaoVO
    {
        public Matricula matricula { get; set; }
        public ICollection<CursoDisciplina> cursodisciplina { get; set; }
        public IEnumerable<Disciplina> disciplinas { get; set; }
        public ICollection<ProfessorDisciplina> professordisciplina { get; set; }
        public IEnumerable<Professor> professores { get; set; }

    }
}