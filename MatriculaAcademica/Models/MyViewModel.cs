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
        public CursoDisciplina cursodisciplina { get; set; }
        public Disciplina disciplina { get; set; }
        public ProfessorDisciplina professordisciplina { get; set; }
        public Professor professor { get; set; }

    }
}