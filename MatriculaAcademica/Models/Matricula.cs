//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatriculaAcademica.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Matricula
    {
        public int id_matricula { get; set; }
        public System.DateTime data_matricula { get; set; }
        public int id_curso { get; set; }
        public int id_aluno { get; set; }
        public int id_usuario { get; set; }
    
        public virtual Aluno Aluno { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
