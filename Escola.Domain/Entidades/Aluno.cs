using System.Collections.Generic;

namespace Escola.Domain.Entidades
{
    public class Aluno : EntidadeUserBase
    {
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public string Nome { get; set; }
        public List<Notas> Notas { get; set; } = new List<Notas>();

        public Aluno(int turmaId, string nome)
        {
            TurmaId = turmaId;
            Nome = nome;
            Role = "Aluno";
        }
        public Aluno()
        {
        }


        public double CalcularNotaFinalAluno()
        {
            var notaFinal = 0.0;
            foreach (var item in Notas)
            {
                notaFinal += item.Nota;
            }
            if(notaFinal != 0)
            {
                return notaFinal;
            }
            return 0;
        }



        public override bool Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}