﻿using eTRIKS.Commons.Core.Domain.Model.Base;
using eTRIKS.Commons.Core.Domain.Model.ControlledTerminology;

namespace eTRIKS.Commons.Core.Domain.Model.Templates
{
    public class DomainTemplateVariable : Identifiable<string>
    {
        //public string OID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }
        public string Label { get; set; }
        public string DomainId { get; set; }
        public string RoleId { get; set; }
        public string UsageId { get; set; }

        public string VariableType { get; set; }
        public CVterm Role { get; set; }
        public CVterm Usage { get; set; }
        public DomainTemplate Domain { get; set; }
    }
}