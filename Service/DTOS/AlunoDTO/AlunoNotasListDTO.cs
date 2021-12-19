using Service.DTOS.NotaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOS.AlunoDTO
{
    public class AlunoNotasListDTO
    {
        public string Nome { get; set; }
        public string SiglaTurma { get; set; }
        public string Ano { get; set; }
        public string Bimestre { get; set; }
        public List<ReadNotaListDTO> Notas { get; set; } = new List<ReadNotaListDTO>();
    }
}
