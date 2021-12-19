using Escola.Domain.Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Validator
{
    internal class TurmaValidator : AbstractValidator<Turma>
    {
        public TurmaValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Turma não pode ser nula").NotEmpty().WithMessage("Turma não pode ser vazia");
            RuleFor(x => x.AnoEnsinoMedioId).NotNull().WithMessage("Ano da turma não pode ser nula").NotEmpty().WithMessage("Ano da turma não pode ser vazio");
        }

    }
}
