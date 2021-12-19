﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escola.Infra.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20211214123856_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Escola.Domain.Entidades.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.AnoEnsinoMedio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ano")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnoEnsinoMedios");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Notas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("Bimestre")
                        .HasColumnType("int");

                    b.Property<double>("Nota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.ProfessorTurma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("TurmaId");

                    b.ToTable("ProfessoresTurmas");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Turma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AnoEnsinoMedioId")
                        .HasColumnType("int");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnoEnsinoMedioId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Aluno", b =>
                {
                    b.HasOne("Escola.Domain.Entidades.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Notas", b =>
                {
                    b.HasOne("Escola.Domain.Entidades.Aluno", "Aluno")
                        .WithMany("Notas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.ProfessorTurma", b =>
                {
                    b.HasOne("Escola.Domain.Entidades.Professor", "Professor")
                        .WithMany("TurmasQueDaAula")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escola.Domain.Entidades.Turma", "Turma")
                        .WithMany("ProfessoresDaTurma")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Turma", b =>
                {
                    b.HasOne("Escola.Domain.Entidades.AnoEnsinoMedio", "AnoEnsinoMedio")
                        .WithMany("TurmasDoAno")
                        .HasForeignKey("AnoEnsinoMedioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnoEnsinoMedio");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Aluno", b =>
                {
                    b.Navigation("Notas");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.AnoEnsinoMedio", b =>
                {
                    b.Navigation("TurmasDoAno");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Professor", b =>
                {
                    b.Navigation("TurmasQueDaAula");
                });

            modelBuilder.Entity("Escola.Domain.Entidades.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("ProfessoresDaTurma");
                });
#pragma warning restore 612, 618
        }
    }
}
