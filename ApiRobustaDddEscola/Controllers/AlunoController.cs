using Escola.Domain.Entidades;
using Escola.Servicos.DTO_S.AlunoDTOS;
using Escola.Servicos.DTO_S.NotaDTOS;
using Escola.Servicos.Servicos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRobustaDddEscola.Controllers
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


        [HttpPost]
        public async Task<ActionResult> CadastrarAluno([FromBody]CreateAlunoDTO createAlunoDTO)
        {
            try
            {
                await _alunoService.Create(createAlunoDTO);
                return Created("Aluno criado", createAlunoDTO);
            }
            catch (Exception)
            {

                return StatusCode(500, "Banco de dados falhou");
            }
        } 

        [HttpGet("AlunoPorId/{id}")]

        public async Task<ActionResult<ReadAlunoDTO>> ObterAlunoId (int id)
        {
            var alunoId = await _alunoService.ObterAlunoId(id);
            if(alunoId == null)
            {
                return NotFound();
            }
            return Ok(alunoId);
        }

        [HttpGet("ObterAlunos")]

        public async Task<ActionResult<List<ReadAlunoListDTO>>> ObterAlunos()
        {
            var alunos = await _alunoService.ObterAlunosInclude();
            if (alunos == null)
            {
                return NotFound();
            }
            return alunos;
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeletarAluno(int id)
        {
            try
            {
                await _alunoService.Remove(id);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "banco de dados falhou");
            }
        }

        [HttpPost("id")]
        public async Task<ActionResult> AdicionarNotaAluno(int id,[FromBody] Notas nota)
        {
            try
            {
                await _alunoService.adicionarNotaAluno(id, nota);
                return Created("Nota criada", nota);
            }
            catch (Exception)
            {

                return StatusCode(500, "Banco falhou");
            }
        }

        [HttpGet("NotasAluno/{id}")]
      
        public async Task<ActionResult<List<ReadNotaListDTO>>> NotasAluno(int id)
        {
            var notas = await _alunoService.ObterNotasDoAluno(id);
            if(notas == null)
            {
                return NotFound();
            }
            return Ok(notas);
        }

    }
}
