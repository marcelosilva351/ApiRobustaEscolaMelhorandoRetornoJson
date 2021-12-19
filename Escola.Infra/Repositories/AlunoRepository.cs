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
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApiContext context) : base(context)
        {
        }

        public async Task adicionarNotaAluno(int idAluno, Notas nota)
        {
            var notaAdd = new Notas(nota.Bimestre, nota.Nota, idAluno);
            _context.Notas.Add(notaAdd);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Aluno>> ObterAlunosInclude()
        {
            IEnumerable<Aluno> AlunosInclude =await _context.Alunos.Include(x => x.Notas).Include(x => x.Turma).ThenInclude(x => x.AnoEnsinoMedio).ToListAsync();
            if(AlunosInclude != null)
            {
                return AlunosInclude;
            }
            return null;
        }

         

        public async Task<double> ObterNotaFinalAluno(int idAluno)
        {
            var AlunoId = await _context.Alunos.FirstOrDefaultAsync(x => x.Id == idAluno);
            if(AlunoId != null)
            {        
          
                return AlunoId.CalcularNotaFinalAluno();
            }
            return -1;
        }

        public async Task<Aluno> ObterNotasAluno(int idAluno)
        {
            var AlunoId = await _context.Alunos.Include(x => x.Notas).FirstOrDefaultAsync(x => x.Id == idAluno);
            if (AlunoId == null)
            {
                return null;
            }
            return AlunoId;
        }
    }
}
