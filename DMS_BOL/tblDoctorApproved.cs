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
    
    public partial class tblDoctorApproved
    {
        public int N_ID { get; set; }
        public Nullable<int> N_DoctorID { get; set; }
        public Nullable<bool> N_IsApproved { get; set; }
        public Nullable<bool> N_IsArchive { get; set; }
        public Nullable<bool> N_IsRead { get; set; }
        public System.DateTime N_CreateadOn { get; set; }
        public bool N_CreatedBy { get; set; }
        public Nullable<System.DateTime> N_UpdatedOn { get; set; }
        public Nullable<bool> N_UpdatedBy { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
    }
}