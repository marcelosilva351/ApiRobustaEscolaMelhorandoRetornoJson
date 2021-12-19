using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.DTO_S.AlunoDTOS
{
    public class ReadAlunoListDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string SiglaTurma { get; set; }

    }
}
