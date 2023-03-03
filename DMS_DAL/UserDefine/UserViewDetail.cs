using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS_DAL.UserDefine
{
    public class UserViewDetail
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string OTP { get; set; }

        public string Role { get; set; }
        
        public string Gender { get; set; }

        public string Image { get; set; }

        public bool Active { get; set; }

        public bool IsProfileCompleted { get; set; }

        public string PhoneNumber { get; set; }
        public string CRole { get; internal set; }
    }
}
