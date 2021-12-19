using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<IEnumerable<Professor>> ProfessorIncludeTurma();

        Task<IEnumerable<Turma>> TurmasQueProfessorDaAula(int id);
    }
}
