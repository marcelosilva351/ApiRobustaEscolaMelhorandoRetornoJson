using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {

        Task<List<Aluno>> AlunosDaTurma(int turmaId);

        Task<IEnumerable<Aluno>> AlunosListComNotas(int turmaId);






    }
}
