using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Infra.Repositories.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterNotasAluno(int idAluno);

        Task<IEnumerable<Aluno>> ObterAlunosInclude();

        Task<double> ObterNotaFinalAluno(int idAluno);

        Task adicionarNotaAluno(int idAluno, Notas nota);


    }
}
