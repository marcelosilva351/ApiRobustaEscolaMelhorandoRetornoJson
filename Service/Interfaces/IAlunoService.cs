using Escola.Domain.Entidades;
using Infra.Repositories.Interfaces;
using Service.DTOS;
using Service.DTOS.AlunoDTO;
using Service.DTOS.NotaDTO;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAlunoService 
    {
        Task<List<ReadNotaListDTO>> NotasDoAluno(int id);

        Task<AlunoIncludeTurmaDTO> AlunoIncludeTurma(int id);

        Task<ReadAlunoNotaFinalDTO> NotaFinalAluno(int id);

    }
}
