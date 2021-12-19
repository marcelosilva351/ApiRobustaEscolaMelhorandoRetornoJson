using Escola.Domain.Entidades;
using Infra.Repositories.Interfaces;
using Service.DTOS.ProfessorDTO;
using Service.DTOS.TurmaDTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public async Task<List<ReadProfessorListDTO>> Professores()
        {
            var professoresRepository = await _professorRepository.ProfessorIncludeTurma();
            var professores = professoresRepository.Select(x => new Professor
            {
                Nome = x.Nome,
                Turmas = x.TurmasQueDaAula.Select(X => X.Turma).ToList()
                

            }).ToList();
            List<ReadProfessorListDTO> professoresReadDTo = new List<ReadProfessorListDTO>();
            foreach (var professor in professores)
            {
                var readTurmaDTO = new ReadTurmaListDTO();
                List<ReadTurmaListDTO> turmasReadDTO = new List<ReadTurmaListDTO>();
                foreach (var turma in professor.Turmas)
                {

                    readTurmaDTO.AnoTurma = turma.AnoEnsinoMedio.Ano;
                    readTurmaDTO.Id = turma.Id;
                    readTurmaDTO.Sigla = turma.Sigla;
                    turmasReadDTO.Add(readTurmaDTO);
                }
                ReadProfessorListDTO readProfessorDTO = new ReadProfessorListDTO();
                readProfessorDTO.Id = professor.Id;
                readProfessorDTO.Nome = professor.Nome;
                readProfessorDTO.TurmasQueDaAula.AddRange(turmasReadDTO);
                professoresReadDTo.Add(readProfessorDTO);
                
            }
            if(professoresReadDTo == null)
            {
                return null;
            }
            return professoresReadDTo;
           



        }

        public async Task<List<ReadTurmaListDTO>> TurmasQueProfessorDaAula(int id)
        {
            var turmasRepository = await _professorRepository.TurmasQueProfessorDaAula(id);
            var listaTurmaReadDTO = new List<ReadTurmaListDTO>();

            foreach (var item in turmasRepository)
            {
                var readTurma = new ReadTurmaListDTO();
                readTurma.AnoTurma = item.AnoEnsinoMedio.Ano;
                readTurma.Id = item.Id;
                readTurma.Sigla = item.Sigla;
                listaTurmaReadDTO.Add(readTurma);
            }
            if(listaTurmaReadDTO == null)
            {
                return null;
            }
            return listaTurmaReadDTO;

        }
    }
}
