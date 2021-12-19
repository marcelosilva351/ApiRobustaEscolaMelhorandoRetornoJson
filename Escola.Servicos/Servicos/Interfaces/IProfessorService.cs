using Escola.Servicos.DTO_S.TurmaDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.Servicos.Interfaces
{
    public interface IProfessorService
    {
        public Task<List<ReadTurmaDTO>> TurmasQueProfessorDaAula(int professorId);
    }
}
