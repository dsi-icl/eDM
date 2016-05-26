﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTRIKS.Commons.Service.DTOs
{
    public class AssayDTO
    {
        public int Id { get; set; }
        public string Platform { get; set; }
        public string Technology { get; set; }
        public string Type { get; set; }
        public string Design { get; set; }
        public string Name { get; set; }
        public Dictionary<string,DatasetDTO> Datasets { get; set; }
        public DatasetDTO SamplesDataset { get; set; }
        public DatasetDTO FeaturesDataset { get; set; }
        public DatasetDTO ObservationsDataset { get; set; }
        public int ProjectId { get; set; }
        public string ProjectAcc { get; set; }


        public AssayDTO()
        {
            Datasets = new Dictionary<string,DatasetDTO>();
        }
    }
}
