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
    
    public partial class tblAppointmentDetail
    {
        public int APD_ID { get; set; }
        public Nullable<int> APD_AppointmentID { get; set; }
        public Nullable<int> APD_PatientID { get; set; }
        public Nullable<int> APD_DoctorID { get; set; }
        public string APD_Email { get; set; }
        public string APD_PhoneNumber { get; set; }
        public string APD_Purpose { get; set; }
        public Nullable<System.DateTime> APD_Date { get; set; }
        public Nullable<int> APD_CreatedBy { get; set; }
        public Nullable<System.DateTime> APD_CreatedOn { get; set; }
        public Nullable<int> APD_UpdatedBy { get; set; }
        public Nullable<System.DateTime> APD_UpdatedOn { get; set; }
    
        public virtual tblAppointment tblAppointment { get; set; }
    }
}