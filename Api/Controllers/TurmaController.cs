using Microsoft.AspNetCore.Mvc;
using Service.DTOS.AlunoDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
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

        [HttpGet("AlunosDaTurma/{id}")]

        public async Task<ActionResult<List<ReadAlunoDTO>>> AlunosDaTurma(int id){
            var alunos = await _turmaService.AlunosDaTurma(id);
            if(alunos == null)
            {
                return NotFound();
            }
            return alunos;
    
        }
        
        [HttpGet("AlunosNotas/{idTurma}")]

        public async Task<ActionResult<List<AlunoNotasListDTO>>> AlunosNota(int idTurma)
        {
            var alunosNotas = await _turmaService.AlunosNota(idTurma);
            if (alunosNotas == null)
            {
                return NotFound();
            }
            return alunosNotas;
        }

    }
}