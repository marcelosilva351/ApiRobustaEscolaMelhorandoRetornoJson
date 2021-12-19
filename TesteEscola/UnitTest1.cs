using Escola.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteEscola
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CriarAnosEnsinoMedio()
        {
           //using (var contexto = new ContextoFake()){


           //     var primeiroAno = new AnoEnsinoMedio("Primeiro");
           //     var segundoAno = new AnoEnsinoMedio("Segundo");
           //     var TeceiroAno = new AnoEnsinoMedio("Terceiro");

           //     contexto.AnoEnsinoMedios.Add(primeiroAno);
           //     contexto.AnoEnsinoMedios.Add(segundoAno);
           //     contexto.AnoEnsinoMedios.Add(TeceiroAno);
           //     contexto.SaveChanges();

           //     Assert.AreEqual(1, primeiroAno.Id);
           // }
        }

        [TestMethod]
        public  void AddTurmasPrimeiroAno() { 
        //
        //    using(var contexto = new ContextoFake())
        //    {
        //        var turmaA = new Turma("A", 1);
        //        var turmaB = new Turma("b", 1);
        //        var turmac = new Turma("c", 1);

        //        contexto.Turmas.Add(turmaA);
        //        contexto.Turmas.Add(turmaB);
        //        contexto.Turmas.Add(turmac);
        //        contexto.SaveChanges();

        //        var primeiroAno = contexto.AnoEnsinoMedios.Include(x => x.TurmasDoAno).FirstOrDefaultAsync(x => x.Id == 1).Result;
        //        Assert.IsTrue(primeiroAno.TurmasDoAno.Count > 2);

        //    }
        }

        [TestMethod]
        public void CriarAlunos() { 
                                 
       
            //using (var contexto = new ContextoFake())
            //{


            //    var Aluno1 = new Aluno(1,"Marcelo");
            //    var Aluno2 = new Aluno(1, "Matheus");
            //    var Aluno3 = new Aluno(1, "Carlos");

            //    contexto.Alunos.Add(Aluno1);
            //    contexto.Alunos.Add(Aluno2 );
            //    contexto.Alunos.Add(Aluno3);
            //    contexto.SaveChanges();

            //    Assert.AreEqual(1, Aluno1.Id);
            //}
        }


        [TestMethod]

        public void ConferirAlunosturmaA()
        {
            //using (var contexto = new ContextoFake())
            //{

            //    var turmaA = contexto.Turmas.Include(x => x.Alunos).FirstOrDefaultAsync(x => x.Id == 1).Result;

            //    Assert.IsTrue(turmaA.Alunos.Count > 2);




            //}
        }

        [TestMethod]
        public void AdicionarProfesorATurma()
        {
            using(var contexto = new ContextoFake())
            {
           
                var professorTurma = new ProfessorTurma(1, 1);
                contexto.ProfessoresTurmas.Add(professorTurma);
                contexto.SaveChanges();
                var turmaAPrimeiroAno = contexto.Turmas.Include(x => x.ProfessoresDaTurma).ThenInclude(x => x.Professor).FirstOrDefaultAsync(x => x.Id == 1).Result;

                Assert.AreEqual(1, turmaAPrimeiroAno.ProfessoresDaTurma.Count);

            }
        }




    }
    }

