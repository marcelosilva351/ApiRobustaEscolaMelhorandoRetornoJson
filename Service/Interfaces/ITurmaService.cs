using Service.DTOS.AlunoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITurmaService
    {
        Task<List<ReadAlunoDTO>> AlunosDaTurma(int idTurma);
        Task<List<AlunoNotasListDTO>> AlunosNota(int idTurma);

    }
}
