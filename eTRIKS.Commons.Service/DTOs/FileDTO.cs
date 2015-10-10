﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTRIKS.Commons.Service.DTOs
{
    public class FileDTO
    {
        public string FileName { get; set; }
        public string dataType { get; set; }
        public List<string> tags { get; set; }
        public string dateAdded { get; set;}
        public string icon { get; set; }
        public bool selected { get; set; }
    }
}
