using Escola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class Context: DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<ProfessorTurma> ProfessorTurma { get; set; }
        public DbSet<AnoEnsinoMedio> AnoEm { get; set; }
        public DbSet<Notas> Notas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EscolaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasOne(x => x.Turma).WithMany(x => x.Alunos).HasForeignKey(x => x.TurmaId);
            modelBuilder.Entity<Notas>().HasOne(X => X.Aluno).WithMany(x => x.Notas).HasForeignKey(x => x.AlunoId);
            modelBuilder.Entity<Turma>().HasOne(x => x.AnoEnsinoMedio).WithMany(x => x.TurmasDoAno).HasForeignKey(x => x.AnoEnsinoMedioId);
            modelBuilder.Entity<ProfessorTurma>().HasKey(x => new { x.ProfessorId,x.TurmaId });
            modelBuilder.Entity<ProfessorTurma>().HasOne(x => x.Professor).WithMany(x => x.TurmasQueDaAula).HasForeignKey(x => x.ProfessorId);
            modelBuilder.Entity<ProfessorTurma>().HasOne(x => x.Turma).WithMany(x => x.ProfessoresDaTurma).HasForeignKey(x => x.TurmaId);
            modelBuilder.Entity<Professor>().HasMany(x => x.TurmasQueDaAula).WithOne(x => x.Professor).HasForeignKey(x => x.ProfessorId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
