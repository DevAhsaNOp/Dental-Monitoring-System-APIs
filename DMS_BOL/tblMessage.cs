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
    
    public partial class tblMessage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMessage()
        {
            this.tblMessageDetails = new HashSet<tblMessageDetail>();
        }
    
        public int M_ID { get; set; }
        public Nullable<int> FromUserID { get; set; }
        public Nullable<int> ToDoctorID { get; set; }
        public Nullable<int> FromDoctorID { get; set; }
        public Nullable<int> ToUserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMessageDetail> tblMessageDetails { get; set; }
    }
}
