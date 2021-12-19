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
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Aluno>> AlunoIncludeNota(int id)
        {
            var alunoNota = _context.Alunos.Include(x => x.Notas).ToList().Where(x => x.Id == id);
            if(alunoNota == null)
            {
                return null;
            }
            return alunoNota;
        }

        public async Task<IEnumerable<Aluno>> AlunoIncludeTurma(int id)
        {
            var alunoTurma = _context.Alunos.Include(x => x.Turma).ThenInclude(x => x.AnoEnsinoMedio).Where(x => x.Id == id);
            if(alunoTurma == null)
            {
                return null;
            }
            return alunoTurma;
        }

   

        public async Task<double> NotaFinalAluno(int id)
        {
            var AlunoNotas = await _context.Alunos.Include(x => x.Notas).FirstOrDefaultAsync(x => x.Id == id);
            if(AlunoNotas == null)
            {
                return -1;
            }
            var notaFinal = AlunoNotas.CalcularNotaFinalAluno();
            return notaFinal;
                
        }
    }
}
