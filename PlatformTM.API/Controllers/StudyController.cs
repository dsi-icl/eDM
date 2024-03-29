﻿using System;
using Microsoft.AspNetCore.Mvc;
using PlatformTM.Services.DTOs;
using PlatformTM.Services.Services;

namespace PlatformTM.API.Controllers
{
    [Route("studies")]
    public class StudyController : Controller
    {
         private readonly StudyService _studyService;

         public StudyController(StudyService studyService)
        {
            _studyService = studyService;
        }

        [HttpGet("{studyId}", Name = "GetstudyById")]
        public StudyDTO Getstudy(int studyId)
        {
            return _studyService.GetstudyId(studyId);
        }

        [HttpPost]
        public IActionResult Addstudy([FromBody] StudyDTO studyDTO)
        {
            var addedstudy = _studyService.Addstudy(studyDTO);

            if (addedstudy != null)
                return new CreatedAtActionResult("GET", "GetstudyById", new { studyId = addedstudy.Id }, studyDTO);

            return new BadRequestResult();
        }

        [HttpPut("{studyId}")]
        public IActionResult Updatestudy(int studyId, [FromBody] StudyDTO studyDTO)
        {
            try
            {
                _studyService.Updatestudy(studyDTO, studyId);
                return new CreatedAtActionResult("GET", "GetstudyById", new { studyId = studyDTO.Id }, studyDTO);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

    }
}
