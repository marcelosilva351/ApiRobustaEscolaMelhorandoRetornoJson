using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entidades
{
    public class ProfessorTurma : EntidadeBase
    {
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }

        public ProfessorTurma(int professorId, int turmaId)
        {
            ProfessorId = professorId;
            TurmaId = turmaId;
        }

        public ProfessorTurma()
        {

        }

        public override bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
