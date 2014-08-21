﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eTRIKSService.Models.Templates
{
    public class Domain
    {
        public string OID { get; set; }
        public string domainName { get; set; }
        public string domainClass { get; set; }
        public string description { get; set; }
        public string structure { get; set; }
        public Boolean repeating { get; set; }
    }

}