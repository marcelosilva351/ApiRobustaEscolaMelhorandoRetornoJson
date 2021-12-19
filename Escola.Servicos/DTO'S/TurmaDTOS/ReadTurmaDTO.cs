using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.DTO_S.TurmaDTOS
{
    public class ReadTurmaDTO
    {
        public string Sigla { get;  set; }
        public string AnoDoEnsinoMedio { get; set; }

        public ReadTurmaDTO()
        {

        }

        public ReadTurmaDTO(string sigla, string anoDoEnsinoMedio)
        {
            Sigla = sigla;
            AnoDoEnsinoMedio = anoDoEnsinoMedio;
        }
    }
}
