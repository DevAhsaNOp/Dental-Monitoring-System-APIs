//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMS_BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDoctorService
    {
        public int DS_ID { get; set; }
        public Nullable<int> DS_DoctorID { get; set; }
        public Nullable<int> DS_ServicesID { get; set; }
        public Nullable<System.DateTime> DS_CreatedOn { get; set; }
        public Nullable<int> DS_CreatedBy { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        public virtual tblService tblService { get; set; }
    }
}
