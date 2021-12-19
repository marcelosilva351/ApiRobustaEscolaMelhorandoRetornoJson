using Service.DTOS.TurmaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOS.ProfessorDTO
{
    public class ReadProfessorListDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ReadTurmaListDTO> TurmasQueDaAula { get; set; } = new List<ReadTurmaListDTO>();
    }
}
