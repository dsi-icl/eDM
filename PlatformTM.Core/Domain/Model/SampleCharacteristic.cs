﻿namespace PlatformTM.Core.Domain.Model
{
    public class SampleCharacteristic : Characteristic
    {
        //public string Method { get; set; }
        //public string Provider { get; set; }
        public Biosample Sample { get; set; }
        public int SampleId { get; set; }
    }
}
