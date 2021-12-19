using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories.Interfaces
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<Professor> TurmasQueProfessorDaAula(int idProfessor);
    }
}
