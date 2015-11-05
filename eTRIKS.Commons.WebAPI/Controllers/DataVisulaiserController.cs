﻿using eTRIKS.Commons.Core.Domain.Model;
using eTRIKS.Commons.Service.DTOs;
using eTRIKS.Commons.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace eTRIKS.Commons.WebAPI.Controllers
{
    [Authorize]
    public class DataVisulaiserController : ApiController
    {
        private DataService _dataService;

        public DataVisulaiserController(DataService dataService)
        {
            _dataService = dataService;
        }
        

        [HttpGet]
        [Route("api/visualise/clinicalTree/{projectAccession}")]
        public async Task<IEnumerable<ClinicalDataTreeDTO>> getClinicalTree(string projectAccession)
        {
            return await _dataService.getClinicalObsTree(projectAccession);
        }
    }
}
