using Service.DTOS.ProfessorDTO;
using Service.DTOS.TurmaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IProfessorService 
    {
        Task<List<ReadTurmaListDTO>> TurmasQueProfessorDaAula(int id);
        Task<List<ReadProfessorListDTO>> Professores();
    }
}
