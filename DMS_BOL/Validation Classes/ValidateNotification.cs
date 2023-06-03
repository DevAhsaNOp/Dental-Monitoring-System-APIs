using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS_BOL.Validation_Classes
{
    public class ValidateNotification
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AdURL { get; set; }
        public string DoctorID { get; set; }
        public bool? IsRead { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public string PhoneNumber { get; set; }
        public string FromUserName { get; set; }
        public bool IsNoti { get; set; }
        public bool IsAnno { get; set; }
        public bool IsAccpeted { get; set; }
        public bool IsApproved{ get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string IsUserAppnt { get; set; }
        public tblDoctor DoctorInfo { get; set; }
        public int NotificationID { get; set; }
    }
}
