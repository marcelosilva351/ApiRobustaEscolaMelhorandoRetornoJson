using Escola.Domain.Entidades;
using Escola.Servicos.DTO_S.AlunoDTOS;
using Escola.Servicos.DTO_S.NotaDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.Servicos
{
    public interface IAlunoService
    {
        Task Create(CreateAlunoDTO alunoDTO);
        Task TrocarAlunoDeTurma(int idAluno, int idTurma);
        Task Remove(int idAluno);

        Task<List<ReadAlunoListDTO>> ObterAlunosInclude();

        Task<List<ReadNotaListDTO>> ObterNotasDoAluno(int id);

        Task<ReadAlunoDTO> ObterAlunoId(int id);

        Task adicionarNotaAluno(int idAluno, Notas nota);

    }
}
