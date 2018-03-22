﻿using eTRIKS.Commons.Core.Domain.Model.Base;
using eTRIKS.Commons.Core.Domain.Model.ControlledTerminology;

namespace eTRIKS.Commons.Core.Domain.Model
{
    public class CharacteristicFeature : Identifiable<int>
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string DataType { get; set; }
        public string Domain { get; set; }

        public CVterm ControlledTerm { get; set; }
        public string CVtermId { get; set; }
       

        
        public Activity Activity { get; set; }
        public int? ActivityId { get; set; }

        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}