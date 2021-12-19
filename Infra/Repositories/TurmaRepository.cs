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
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(Context context) : base(context)
        {
        }

        public async Task<List<Aluno>> AlunosDaTurma(int turmaId)
        {
            var includeTurmaAluno = await _context.Turmas.Include(x => x.Alunos).FirstOrDefaultAsync(x => x.Id == turmaId);
            var listaDeAlunosDaTurm = includeTurmaAluno.Alunos;
            if(listaDeAlunosDaTurm == null)
            {
                return null;
            }
            return listaDeAlunosDaTurm;            
        }
        public async Task<IEnumerable<Aluno>> AlunosListComNotas(int turmaId)
        {
            var alunosNotas = await _context.Alunos.Include(x => x.Notas).Include(x => x.Turma).ThenInclude(x => x.AnoEnsinoMedio).Where(x => x.TurmaId == turmaId).ToListAsync();
            if (alunosNotas == null)
            {
                return null;
            }
            return alunosNotas;
        }
    }
}
