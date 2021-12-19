using Escola.Domain.Entidades;
using Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Professor>> ProfessorIncludeTurma()
        {
            var professoresIncludeTurma = _context.Professores.Include(x => x.TurmasQueDaAula).ThenInclude(X => X.Turma).ThenInclude(x => x.AnoEnsinoMedio);
            if(professoresIncludeTurma == null)
            {
                return null;
            }
            return professoresIncludeTurma;
        }

        public async Task<IEnumerable<Turma>> TurmasQueProfessorDaAula(int id)
        {
            var turmas = _context.Turmas.Include(X => X.AnoEnsinoMedio).Include(x => x.ProfessoresDaTurma).ThenInclude(x => x.Professor).Where(x => x.Id == id);
            if(turmas == null)
            {
                return null;
            }
            return turmas;
        }
    }
}
