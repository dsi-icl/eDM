//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eTRIKSService.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Domain_Dataset_Template_TAB
    {
        public Domain_Dataset_Template_TAB()
        {
            this.Domain_Variable_Template_TAB = new HashSet<Domain_Variable_Template_TAB>();
        }
    
        public string OID { get; set; }
        public string domainName { get; set; }
        public string @class { get; set; }
        public string description { get; set; }
        public string structure { get; set; }
        public Nullable<bool> repeating { get; set; }
    
        public virtual ICollection<Domain_Variable_Template_TAB> Domain_Variable_Template_TAB { get; set; }
    }
}