using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Domain.Entidades
{
    public class Notas : EntidadeBase
    {
        public int Bimestre { get; set; }
        public double Nota { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public Notas(int bimestre, double nota, int alunoId)
        {
            Bimestre = bimestre;
            Nota = nota;
            AlunoId = alunoId;
        }






        public override bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
