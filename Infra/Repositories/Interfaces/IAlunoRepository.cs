using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno> 
    {
        Task<IEnumerable<Aluno>> AlunoIncludeNota(int id);

        Task<IEnumerable<Aluno>> AlunoIncludeTurma(int id);

        Task<double> NotaFinalAluno(int id);

    }
}
