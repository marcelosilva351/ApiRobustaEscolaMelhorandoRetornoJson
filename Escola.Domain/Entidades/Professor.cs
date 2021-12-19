using System.Collections.Generic;

namespace Escola.Domain.Entidades
{
    public class Professor  : EntidadeUserBase
    {
        public string Nome { get; set; }
        public List<ProfessorTurma> TurmasQueDaAula { get; set; } = new List<ProfessorTurma>();

        public List<Turma> Turmas = new List<Turma>();
        public Professor()
        {

        }


        public override bool Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}