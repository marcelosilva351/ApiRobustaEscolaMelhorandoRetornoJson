using Escola.Domain.Entidades;
using Escola.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApiContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Aluno>> AlunosDaTurma(int idTurma)
        {
            var alunosTurma = await _context.Alunos.Include(x => x.Turma).ThenInclude(x => x.AnoEnsinoMedio).Where(x => x.TurmaId == idTurma).ToListAsync();
            if(alunosTurma == null)
            {
                return null;
            }
     
            return alunosTurma;

        }

        public async Task<IEnumerable<Turma>> ObterTurmasIncludeAnoEm()
        {
            IEnumerable<Turma> turmasIncludeAnoEm = await _context.Turmas.Include(x => x.AnoEnsinoMedio).ToListAsync();
            if(turmasIncludeAnoEm == null)
            {
                return null;
            }
            return turmasIncludeAnoEm;
        }

        public async Task<IEnumerable<Turma>> ProfessoresDaTurma(int idTurma)
        {
            IEnumerable<Turma> professoresTurma = _context.Turmas.Include(x => x.ProfessoresDaTurma).ThenInclude(x => x.Professor).Where(X => X.Id == idTurma);
        
             
            if(professoresTurma == null)
            {
                return null;
            }
            return professoresTurma;
                
        }
    }
}
