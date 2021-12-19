using Escola.Domain.Entidades;
using Infra.Repositories.Interfaces;
using Service.DTOS;
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
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository) 
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<AlunoIncludeTurmaDTO> AlunoIncludeTurma(int id)
        {
            var AlunoIncludeTurma = await _alunoRepository.AlunoIncludeTurma(id);
            if(AlunoIncludeTurma == null)
            {
                return null;
            }
            var alunoIncludeTurmaDTO = AlunoIncludeTurma.Select(x => new AlunoIncludeTurmaDTO {
            Ano = x.Turma.AnoEnsinoMedio.Ano,
            Nome = x.Nome,
            SiglaTurma = x.Turma.Sigla
            }).FirstOrDefault();

            return alunoIncludeTurmaDTO;

        }


        public async Task<ReadAlunoNotaFinalDTO> NotaFinalAluno(int id)
        {
            var notaFinalAluno = await _alunoRepository.NotaFinalAluno(id);
            if(notaFinalAluno == -1)
            {
                return null;
            }
            var alunoNotaFinal = new ReadAlunoNotaFinalDTO();
            alunoNotaFinal.NotaFinal = notaFinalAluno;
            if(notaFinalAluno >= 24)
            {
                alunoNotaFinal.Aprovado = "Aprovado";
            }
            else
            {
                alunoNotaFinal.Aprovado = "Reprovado";
            }
            return alunoNotaFinal;
        }

        public async Task<List<ReadNotaListDTO>> NotasDoAluno(int id)
        {
            var alunoIncludeNota = await _alunoRepository.AlunoIncludeNota(id);
            if(alunoIncludeNota == null)
            {
                return null;
            }
            var aluno = alunoIncludeNota.Select(
                x => new Aluno
                {
                    Notas = x.Notas
                }
                ).First();

            if(aluno.Notas.Count == 0)
            {
                return null;
            }
            var notas = new List<ReadNotaListDTO>();
            
            foreach (var item in aluno.Notas)
            {
                var Readnota = new ReadNotaListDTO();
                Readnota.Bimestre = item.Bimestre;
                Readnota.Nota = item.Nota;
                notas.Add(Readnota);
            }

            return notas;

        }

     
            

         
       


            






        }
    }
