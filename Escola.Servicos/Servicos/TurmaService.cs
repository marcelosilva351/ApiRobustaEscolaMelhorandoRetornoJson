using Escola.Domain.Entidades;
using Escola.Infra.Repositories.Interfaces;
using Escola.Servicos.DTO_S.AlunoDTOS;
using Escola.Servicos.DTO_S.TurmaDTOS;
using Escola.Servicos.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.Servicos
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<List<ReadAlunoListDTO>> AlunosDaTurma(int idTurma)
        {
            var alunos = await _turmaRepository.AlunosDaTurma(idTurma);
            var alunosReadList = alunos.Select(x => new ReadAlunoListDTO {
                Nome = x.Nome,
                Ano = x.Turma.AnoEnsinoMedio.Ano,
                Id = x.Id,
                SiglaTurma = x.Turma.Sigla
            }).ToList();
            if(alunos == null)
            {
                return null;
            }
     
            return alunosReadList;
        }

        public async Task<List<ReadTurmaDTO>> ObterTurmasIncludeAnoEm()
        {
            var turmasInclude = await _turmaRepository.ObterTurmasIncludeAnoEm();
            var turmasRead = turmasInclude.Select(x => new ReadTurmaDTO { 
            AnoDoEnsinoMedio = x.AnoEnsinoMedio.Ano,
            Sigla = x.Sigla

            }).ToList();
            if(turmasRead == null)
            {
                return null;
            }
            foreach (var item in turmasRead)
            {
                item.AnoEnsinoMedio.TurmasDoAno = null;
            }
            return turmasRead;
        }

        public async Task<List<Professor>> ProfessoresDaTurma(int idTurma)
        {
            var lista = new List<Professor>();
            var professoresInclude = await _turmaRepository.ProfessoresDaTurma(idTurma);
            var listaprofessor = professoresInclude.Select(X => new ReadTurmaDTO
            { 
                ProfessoresDaTurma = X.ProfessoresDaTurma.Select(X => X.Professor).ToList()
            });

            foreach (var item in listaprofessor)
            {
                lista.AddRange(item.ProfessoresDaTurma);
            }
            foreach (var item in lista)
            {
                item.TurmasQueDaAula = null;
            }
            return lista;
           


        }
    }
}
