using Escola.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entidades
{
    public class Turma : EntidadeBase
    {

        public string Sigla { get; private set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public int AnoEnsinoMedioId { get; private set; }
        public AnoEnsinoMedio AnoEnsinoMedio { get; set; }
        public List<ProfessorTurma> ProfessoresDaTurma { get; set; } = new List<ProfessorTurma>();

        public Turma()
        {

        }
        public Turma(string sigla, int anoEnsinoMedioId)
        {
            Sigla = sigla;
            AnoEnsinoMedioId = anoEnsinoMedioId;
        }

        public void TrocarTurmaDeAno(int idAnoEnsinoMedio)
        {
                this.AnoEnsinoMedioId = idAnoEnsinoMedio;
        }

        public override bool Validar()
        {
            var validator = new TurmaValidator();
            var Validation = validator.Validate(this);
            if (!Validation.IsValid)
            {
                foreach (var item in Validation.Errors)
                {
                    _erros.Add(item.ErrorMessage);
                }
                foreach (var item in _erros)
                {
                    throw new InvalidOperationException($"Existem campos incorretor: {item}");
                }

            }
            return true;
        }
    }

}
