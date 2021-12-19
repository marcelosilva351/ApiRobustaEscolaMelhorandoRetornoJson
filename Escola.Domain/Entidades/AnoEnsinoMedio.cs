using System.Collections.Generic;

namespace Escola.Domain.Entidades
{
    public class AnoEnsinoMedio : EntidadeBase
    {
        public string Ano { get; private set; }
        public List<Turma> TurmasDoAno { get; set; } = new List<Turma>();
        public AnoEnsinoMedio()
        {

        }
        public AnoEnsinoMedio(string ano)
        {
            Ano = ano;
        }
        public override bool Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}