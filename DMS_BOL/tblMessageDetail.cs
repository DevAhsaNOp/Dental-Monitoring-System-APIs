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
    
    public partial class tblMessageDetail
    {
        public int MD_ID { get; set; }
        public int MD_MessageID { get; set; }
        public string MD_Message { get; set; }
        public Nullable<System.DateTime> MD_Datetime { get; set; }
        public Nullable<bool> MD_IsRead { get; set; }
        public Nullable<bool> MD_IsDelivered { get; set; }
    
        public virtual tblMessage tblMessage { get; set; }
    }
}
