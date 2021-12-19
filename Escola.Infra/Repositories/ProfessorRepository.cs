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
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ApiContext context) : base(context)
        {
        }

        public  IEnumerable<Professor> TurmasQueProfessorDaAula(int idProfessor)
        {
            IEnumerable<Professor> professoresInclude = _context.Professores.Include(x => x.TurmasQueDaAula).ThenInclude(x => x.Turma).Where(x => x.Id == idProfessor);
            if(professoresInclude == null)
            {
                return null;
            }
            return  professoresInclude;
        }
    }
}
