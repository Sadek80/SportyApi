using AutoMapper;
using SportyApi.Models.Core;
using SportyApi.Models.Core.DTOs.TrainingProgramsDtos;
using SportyApi.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/programs")]
    [Authorize]
    [ApiController]
    public class TrainingProgramController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainingProgramController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrograms([FromQuery] BaseResourceParametersForSearchAndFilter parameters)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;


            var trainingPrograms = await _unitOfWork.TrainingProgramsRepository
                                                                    .GetAllTrainingProgramsAsync(parameters, uid);

            return Ok(_mapper.Map<IEnumerable<TrainingProgramDto>>(trainingPrograms));
        }

        [HttpGet("{programId}")]
        public async Task<IActionResult> GetProgramById(Guid programId)
        {
            if (programId == Guid.Empty)
                return BadRequest("Invalid Program!");

            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;


            var trainingProgram = await _unitOfWork.TrainingProgramsRepository
                .GetTrainingProgramByIdAsync(programId, uid);

            if (trainingProgram is null)
                return NotFound("Program not found!");

            return Ok(trainingProgram);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainingProgram([FromBody] TrainingProgramForCreationDto trainingProgram)
        {
            //throw new NotImplementedException();
            return Ok(trainingProgram);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GeyUserReservedTrainingPrograms()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var programs = await _unitOfWork.TrainingProgramsRepository.GeyUserReservedTrainingProgramsAsync(uid);

            if (programs is null)
                return BadRequest("Invalid User!");

            if (programs.Count() == 0)
                return BadRequest("There's no programs yet!");

            var history = _mapper.Map<List<TrainingProgramHistoryDto>>(programs);

            return Ok(history);

        }

        [HttpPost("{programId}/enroll")]
        public async Task<IActionResult> EnrollToProgram(Guid programId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (programId == Guid.Empty)
                return BadRequest("Invalid program!");

            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;

            var reservedProgram = await _unitOfWork.TrainingProgramsRepository.EnrollToTrainingProgramAsync(uid, programId);

            if (reservedProgram != "You have successfully enrolled.")
                return BadRequest(reservedProgram);

            await _unitOfWork.Save();

            return Ok(programId);
        }

    }
}
