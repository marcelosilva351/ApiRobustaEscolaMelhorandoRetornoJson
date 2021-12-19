using Escola.Domain.Entidades;
using Escola.Infra.Repositories.Interfaces;
using Escola.Servicos.DTO_S.AlunoDTOS;
using Escola.Servicos.DTO_S.NotaDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.Servicos.Servicos
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task Create(CreateAlunoDTO createAlunoDTO)
        {
            var aluno = new Aluno(createAlunoDTO.TurmaId, createAlunoDTO.Nome);
            try
            {
                await _alunoRepository.Create(aluno);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ReadAlunoDTO> ObterAlunoId(int id)
        {
            var alunoPorId = await _alunoRepository.GetById(id);
            if(alunoPorId == null)
            {
                return null;
            }
            var readAlunoDTO = new ReadAlunoDTO(id, alunoPorId.Nome);
            readAlunoDTO.Turma = null;
            return readAlunoDTO;
        }

        public async Task<List<ReadAlunoListDTO>> ObterAlunosInclude()
        {
            var alunosInclude = await _alunoRepository.ObterAlunosInclude();
            if (alunosInclude != null)
            {
                var readAlunos = alunosInclude.Select(x => new ReadAlunoListDTO()
                {
             
                    Id = x.Id,
                    Nome = x.Nome,
                    Ano = x.Turma.AnoEnsinoMedio.Ano,
                    SiglaTurma = x.Turma.Sigla,


                }).ToList();
               
                return readAlunos;
            }
            return null;
            }

        public async Task<List<ReadNotaListDTO>> ObterNotasDoAluno(int id)
        {
            var Aluno = await _alunoRepository.ObterNotasAluno(id);
            List<ReadNotaListDTO> notasDoAluno = new List<ReadNotaListDTO>();
            if(Aluno == null)
            {
                return null;
            }
            foreach (var item in Aluno.Notas)
            {
                var ReadNotaListDTO = new ReadNotaListDTO();
                ReadNotaListDTO.Bimestre = item.Bimestre;
                ReadNotaListDTO.Nota = item.Nota;
                notasDoAluno.Add(ReadNotaListDTO);
            }
            return notasDoAluno;

        }

        public async Task adicionarNotaAluno(int idAluno, Notas nota)
        {
            try
            {
                await _alunoRepository.adicionarNotaAluno(idAluno, nota);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remove(int idAluno)
        {
            var alunoRemove = await _alunoRepository.GetById(idAluno);
            if(alunoRemove != null)
            {
                await _alunoRepository.Delete(alunoRemove);
            

            }
            return;
            
        }

        public async Task TrocarAlunoDeTurma(int idAluno, int idTurma)
        {
            var alunoUpdate = await _alunoRepository.GetById(idAluno);
            if(alunoUpdate != null)
            {
                alunoUpdate.TurmaId = idTurma;
                await _alunoRepository.Update(alunoUpdate);


            }
            return;
        }
    }
}
