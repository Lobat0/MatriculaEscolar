﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MatriculaAcademicadbEntities1 : DbContext
    {
        public MatriculaAcademicadbEntities1()
            : base("name=MatriculaAcademicadbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<CursoDisciplina> CursoDisciplina { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<ProfessorDisciplina> ProfessorDisciplina { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
