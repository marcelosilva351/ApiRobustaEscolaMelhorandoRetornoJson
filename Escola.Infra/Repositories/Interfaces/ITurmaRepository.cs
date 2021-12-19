using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<IEnumerable<Aluno>> AlunosDaTurma(int idTurma);
        Task<IEnumerable<Turma>> ProfessoresDaTurma(int idTurma);
        Task<IEnumerable<Turma>> ObterTurmasIncludeAnoEm();

    }
}
