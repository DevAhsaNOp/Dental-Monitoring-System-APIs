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
    
    public partial class tblService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblService()
        {
            this.tblDoctorServices = new HashSet<tblDoctorService>();
        }
    
        public int S_ID { get; set; }
        public string S_Name { get; set; }
        public string S_URL { get; set; }
        public Nullable<bool> S_IsActive { get; set; }
        public Nullable<bool> S_IsArchive { get; set; }
        public Nullable<System.DateTime> S_CreatedOn { get; set; }
        public Nullable<System.DateTime> S_UpdatedOn { get; set; }
        public Nullable<int> S_CreatedBy { get; set; }
        public Nullable<int> S_UpdatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDoctorService> tblDoctorServices { get; set; }
    }
}
