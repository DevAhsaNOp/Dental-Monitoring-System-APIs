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
    
    public partial class tblDoctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDoctor()
        {
            this.tblAppointments = new HashSet<tblAppointment>();
            this.tblDiagnostics = new HashSet<tblDiagnostic>();
            this.tblDoctorWorkExperiences = new HashSet<tblDoctorWorkExperience>();
            this.tblOfflineConsultaionDetails = new HashSet<tblOfflineConsultaionDetail>();
            this.tblOnlineConsultaionDetails = new HashSet<tblOnlineConsultaionDetail>();
        }
    
        public int D_ID { get; set; }
        public string D_FirstName { get; set; }
        public string D_LastName { get; set; }
        public string D_PhoneNumber { get; set; }
        public Nullable<int> D_AddressID { get; set; }
        public Nullable<int> D_RoleID { get; set; }
        public string D_ProfileImage { get; set; }
        public string D_Email { get; set; }
        public string D_Password { get; set; }
        public string D_YearsOfExperience { get; set; }
        public string D_Specialization { get; set; }
        public string D_OfferedServices { get; set; }
        public string D_WorkPhoneNumber { get; set; }
        public string D_AwardsAndAchievements { get; set; }
        public string D_AboutMe { get; set; }
        public Nullable<int> D_CreatedBy { get; set; }
        public Nullable<System.DateTime> D_CreatedOn { get; set; }
        public Nullable<int> D_UpdatedBy { get; set; }
        public Nullable<System.DateTime> D_UpdatedOn { get; set; }
        public Nullable<bool> D_IsActive { get; set; }
        public Nullable<bool> D_IsArchive { get; set; }
        public string D_OTP { get; set; }
        public Nullable<bool> D_Verified { get; set; }
        public Nullable<int> D_SatisfactionRate { get; set; }
        public Nullable<int> D_ResponseTime { get; set; }
    
        public virtual tblAddress tblAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDiagnostic> tblDiagnostics { get; set; }
        public virtual tblRole tblRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDoctorWorkExperience> tblDoctorWorkExperiences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOfflineConsultaionDetail> tblOfflineConsultaionDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOnlineConsultaionDetail> tblOnlineConsultaionDetails { get; set; }
    }
}
