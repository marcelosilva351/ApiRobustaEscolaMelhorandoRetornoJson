using Microsoft.AspNetCore.Mvc;
using Service.DTOS;
using Service.DTOS.AlunoDTO;
using Service.DTOS.NotaDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("notasAluno/{id}")]

        public async Task<ActionResult<List<ReadNotaListDTO>>> NotasAluno(int id)
        {
            var notas = await _alunoService.NotasDoAluno(id);
            if(notas == null)
            {
                return NotFound();
            }
            return Ok(notas);
        }


        [HttpGet("AlunoTurma/{id}")]

        public async Task<ActionResult<AlunoIncludeTurmaDTO>> AlunoTurma(int id)
        {
            var alunoNota = await _alunoService.AlunoIncludeTurma(id);
            if(alunoNota == null)
            {
                return NotFound();

            }
            return alunoNota;
        }


        [HttpGet("NotaFinalAluno/{id}")]

        public async Task<ActionResult<ReadAlunoNotaFinalDTO>> NotafinalAluno(int id)
        {
            var alunoNotaFinal = await _alunoService.NotaFinalAluno(id);
            if(alunoNotaFinal == null)
            {
                return NotFound();
            }
            return alunoNotaFinal;
        }
  








    }
}
