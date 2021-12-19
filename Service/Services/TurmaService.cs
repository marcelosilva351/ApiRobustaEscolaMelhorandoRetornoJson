using Escola.Domain.Entidades;
using Infra.Repositories.Interfaces;
using Service.DTOS.AlunoDTO;
using Service.DTOS.NotaDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<List<ReadAlunoDTO>> AlunosDaTurma(int idTurma)
        {
            var alunos = await _turmaRepository.AlunosDaTurma(idTurma);
            if (alunos == null)
            {
                return null;
            }
            var alunosReadDTO = new List<ReadAlunoDTO>();
            foreach (var item in alunos)
            {
                var alunoRead = new ReadAlunoDTO();
                alunoRead.Nome = item.Nome;
                alunosReadDTO.Add(alunoRead);
            }
            return alunosReadDTO;
        }

        public async Task<List<AlunoNotasListDTO>> AlunosNota(int idTurma)
        {

            var alunos = await _turmaRepository.AlunosListComNotas(idTurma);
            var notasList = new List<Notas>();
            var alunosSelect = alunos.Select(x => new Aluno
            {
                Nome = x.Nome,
                Turma = x.Turma,
                Notas = x.Notas.ToList(),
            }).ToList();

            var listaAlunoListaNotaDTO = new List<AlunoNotasListDTO>();

            foreach (var aluno in alunosSelect)
            {
                var alunoNotasListDTO = new AlunoNotasListDTO();
                alunoNotasListDTO.Ano = aluno.Turma.AnoEnsinoMedio.Ano;
                alunoNotasListDTO.Nome = aluno.Nome;
                alunoNotasListDTO.SiglaTurma = aluno.Turma.Sigla;
                var readNotaListDTO = new ReadNotaListDTO();
                foreach (var nota in aluno.Notas)
                {
                    readNotaListDTO.Bimestre = nota.Bimestre;
                    readNotaListDTO.Nota = nota.Nota;
                    alunoNotasListDTO.Notas.Add(readNotaListDTO);
                }
                listaAlunoListaNotaDTO.Add(alunoNotasListDTO);
            }
            if (listaAlunoListaNotaDTO == null) {
                return null;

            }
            
            return listaAlunoListaNotaDTO;



        }

    }
}
