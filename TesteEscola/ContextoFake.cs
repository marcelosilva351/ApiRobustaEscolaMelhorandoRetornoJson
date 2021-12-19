using Escola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteEscola
{
    public class ContextoFake : DbContext
    {
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<ProfessorTurma> ProfessoresTurmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Notas> Notas { get; set; }
        public DbSet<AnoEnsinoMedio> AnoEnsinoMedios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Turma>().HasMany(x => x.ProfessoresDaTurma).WithOne(x => x.Turma).HasForeignKey(x => x.TurmaId);
            modelBuilder.Entity<Professor>().HasMany(x => x.TurmasQueDaAula).WithOne(x => x.Professor).HasForeignKey(x => x.ProfessorId);
            modelBuilder.Entity<Aluno>().HasOne(x => x.Turma).WithMany(x => x.Alunos).HasForeignKey(x => x.TurmaId);
            modelBuilder.Entity<AnoEnsinoMedio>().HasMany(x => x.TurmasDoAno).WithOne(x => x.AnoEnsinoMedio).HasForeignKey(x => x.AnoEnsinoMedioId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FakeEscolaBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }



    }
}
