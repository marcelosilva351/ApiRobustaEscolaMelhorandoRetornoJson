using Escola.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.DTO_S.AlunoDTOS
{
    public class ReadAlunoDTO
    {
        public int Id { get; set; }
        public Turma Turma { get; set; }
        public string Nome { get; set; }
        public List<Notas> Notas { get; set; } = new List<Notas>();

        public ReadAlunoDTO()
        {

        }
        public ReadAlunoDTO(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
