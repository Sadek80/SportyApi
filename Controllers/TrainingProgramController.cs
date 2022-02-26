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
            //throw new NotImplementedException();
            return Ok(parameters);
        }

        [HttpGet("{programId}")]
        public async Task<IActionResult> GetProgramById(Guid programId)
        {
            //throw new NotImplementedException();
            return Ok(programId);
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
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            return Ok(new { uid });
        }

        [HttpPost("{programId}/enroll")]
        public async Task<IActionResult> EnrollToProgram(Guid programId)
        {
            //throw new NotImplementedException();
            var uid = User.Claims.FirstOrDefault(u => u.Type == "uid").Value;
            return Ok(new { id = uid, Pid = programId });
        }

    }
}
