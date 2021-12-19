using Microsoft.AspNetCore.Mvc;
using Service.DTOS.ProfessorDTO;
using Service.DTOS.TurmaDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/professores")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("Professores")]

        public async Task<ActionResult<List<ReadProfessorListDTO>>> ObterProfessores()
        {
            var professores = await _professorService.Professores();
            if(professores == null)
            {
                return NotFound();
            }
            return professores;

        }

        [HttpGet("TurmasQueProfessorDaAula/{id}")]

        public async Task<ActionResult<List<ReadTurmaListDTO>>> TurmasProfessorDaAula(int id)
        {
            var turmas = await _professorService.TurmasQueProfessorDaAula(id);
            if (turmas == null)
            {
                return NotFound();
            }
            return turmas;

        }
    }
}
