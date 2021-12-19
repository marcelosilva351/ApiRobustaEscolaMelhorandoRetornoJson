using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.DTO_S.ProfessorDTOS
{
    public class ProfessorListTurmaDTO
    {
        public List<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
