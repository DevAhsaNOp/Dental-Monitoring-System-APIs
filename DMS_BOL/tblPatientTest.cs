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
    
    public partial class tblPatientTest
    {
        public int PT_ID { get; set; }
        public Nullable<int> PT_PatientID { get; set; }
        public Nullable<System.DateTime> PT_Datetime { get; set; }
        public string PT_Images { get; set; }
        public string PT_Pdf { get; set; }
        public string PT_IdentifiedDiseases { get; set; }
        public string PT_Remarks { get; set; }
        public Nullable<bool> PT_IsActive { get; set; }
        public Nullable<bool> PT_IsArchive { get; set; }
    
        public virtual tblPatient tblPatient { get; set; }
    }
}