using Escola.Domain.Entidades;
using Escola.Servicos.DTO_S.AlunoDTOS;
using Escola.Servicos.DTO_S.TurmaDTOS;
using Escola.Servicos.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRobustaDddEscola.Controllers
{
    [ApiController]
    [Route("v1/turmas")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpGet("Alunos/{id}")]

        public async Task<ActionResult<List<ReadAlunoListDTO>>> alunosDaTurma(int id)
        {
            var alunos = await _turmaService.AlunosDaTurma(id);
            if(alunos == null)
            {
                return NotFound();
            }

            return Ok(alunos);



        }

        [HttpGet("IncludeTurmasAnoEm")]

        public async Task<List<ReadTurmaDTO>> ObterTurmaIncludeAnoEM()
        {
           var turmas = await _turmaService.ObterTurmasIncludeAnoEm();
            var turmasRead = new List<ReadTurmaDTO>();
            foreach (var item in turmas)
            {
                turmasRead.Add(item);
            }
            return turmasRead;
        }

        [HttpGet("ProfessoresTurma/{id}")]

        public async Task<ActionResult<List<Professor>>> ProfessoresTurma(int id)
        {
           var professores = await _turmaService.ProfessoresDaTurma(id);
            return Ok(professores);

        }



    }
}
