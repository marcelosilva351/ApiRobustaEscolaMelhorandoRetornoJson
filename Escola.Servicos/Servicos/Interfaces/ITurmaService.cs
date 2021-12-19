using Escola.Domain.Entidades;
using Escola.Servicos.DTO_S.AlunoDTOS;
using Escola.Servicos.DTO_S.TurmaDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.Servicos.Interfaces
{
    public interface ITurmaService
    {
        Task<List<ReadAlunoListDTO>> AlunosDaTurma(int idTurma);

        Task<List<ReadTurmaDTO>> ObterTurmasIncludeAnoEm();

        Task<List<Professor>> ProfessoresDaTurma(int idTurma);
    }
}
