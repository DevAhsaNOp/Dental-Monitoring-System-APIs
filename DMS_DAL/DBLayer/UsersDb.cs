using System;
using DMS_BOL;
using System.Net;
using System.Linq;
using System.Net.Mail;
using DMS_DAL.UserDefine;
using System.Data.Entity;
using DMS_BOL.Validation_Classes;
using static System.Net.WebRequestMethods;

namespace DMS_DAL.DBLayer
{
    public class UsersDb
    {
        private dentalDBEntities _context;

        public UsersDb()
        {
            _context = new dentalDBEntities();
        }

        #region Operations_On_Patients_Table

        public bool InsertPatient(tblPatient model)
        {
            try
            {
                model.P_IsActive = true;
                model.P_CreatedOn = DateTime.Now;
                model.P_UpdatedOn = null;
                model.P_UpdatedBy = null;
                model.P_IsArchive = false;
                model.P_RoleID = 4;
                _context.tblPatients.Add(model);
                Save();
                if (model.P_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdatePatient(tblPatient model)
        {
            try
            {
                model.P_IsActive = true;
                model.P_CreatedBy = GetPatientByID(model.P_ID).P_CreatedBy;
                model.P_CreatedOn = GetPatientByID(model.P_ID).P_CreatedOn;
                model.P_UpdatedOn = DateTime.Now;
                model.P_RoleID = 4;
                model.P_IsArchive = false;
                model.P_Verified = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.P_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertOTP(tblOTP model)
        {
            try
            {
                model.OT_IsActive = true;
                model.OT_CreatedOn = DateTime.Now;
                model.OT_UpdatedOn = null;
                model.OT_IsArchive = false;
                _context.tblOTPs.Add(model);
                Save();
                if (model.OT_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateOTP(string Email)
        {
            try
            {
                var model = _context.tblOTPs.Where(x => x.OT_UsersEmail == Email).FirstOrDefault();
                model.OT_IsActive = false;
                model.OT_IsArchive = true;
                model.OT_UpdatedOn= DateTime.Now;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.OT_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblOTP GetOTPByID(int modelId)
        {
            return _context.tblOTPs.Find(modelId);
        }


        public tblPatient GetPatientByID(int modelId)
        {
            return _context.tblPatients.Find(modelId);
        }

        public bool InActivePatient(tblPatient model)
        {
            try
            {
                model = GetPatientByID(model.P_ID);
                model.P_IsActive = false;
                model.P_UpdatedOn = DateTime.Now;
                model.P_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.P_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActivePatient(tblPatient model)
        {
            try
            {
                model = GetPatientByID(model.P_ID);
                model.P_IsActive = true;
                model.P_UpdatedOn = DateTime.Now;
                model.P_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.P_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Operations_On_Admins_Table

        public bool InsertAdmin(tblAdmin model)
        {
            try
            {
                model.A_IsActive = true;
                model.A_CreatedOn = DateTime.Now;
                model.A_UpdatedOn = null;
                model.A_UpdatedBy = null;
                model.A_IsArchive = false;
                model.A_RoleID = 2;
                _context.tblAdmins.Add(model);
                Save();
                if (model.A_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAdmin(tblAdmin model)
        {
            try
            {
                model.A_IsActive = true;
                model.A_CreatedOn = GetAdminByID(model.A_ID).A_CreatedOn;
                model.A_CreatedBy = GetAdminByID(model.A_ID).A_CreatedBy;
                model.A_UpdatedOn = DateTime.Now;
                model.A_RoleID = 2;
                model.A_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.A_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblAdmin GetAdminByID(int modelId)
        {
            return _context.tblAdmins.Find(modelId);
        }

        public bool InActiveAdmin(tblAdmin model)
        {
            try
            {
                model = GetAdminByID(model.A_ID);
                model.A_IsActive = false;
                model.A_UpdatedOn = DateTime.Now;
                model.A_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.A_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveAdmin(tblAdmin model)
        {
            try
            {
                model = GetAdminByID(model.A_ID);
                model.A_IsActive = true;
                model.A_UpdatedOn = DateTime.Now;
                model.A_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.A_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Operations_On_SuperAdmins_Table

        public bool InsertSuperAdmin(tblSuperAdmin model)
        {
            try
            {
                model.SA_IsActive = true;
                model.SA_CreatedOn = DateTime.Now;
                model.SA_UpdatedOn = null;
                model.SA_UpdatedBy = null;
                model.SA_IsArchive = false;
                model.SA_RoleID = 1;
                _context.tblSuperAdmins.Add(model);
                Save();
                if (model.SA_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateSuperAdmin(tblSuperAdmin model)
        {
            try
            {
                model.SA_IsActive = true;
                model.SA_CreatedOn = GetSuperAdminByID(model.SA_ID).SA_CreatedOn;
                model.SA_CreatedBy = GetSuperAdminByID(model.SA_ID).SA_CreatedBy;
                model.SA_UpdatedOn = DateTime.Now;
                model.SA_RoleID = 1;
                model.SA_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.SA_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblSuperAdmin GetSuperAdminByID(int modelId)
        {
            return _context.tblSuperAdmins.Find(modelId);
        }

        public bool InActiveSuperAdmin(tblSuperAdmin model)
        {
            try
            {
                model = GetSuperAdminByID(model.SA_ID);
                model.SA_IsActive = false;
                model.SA_UpdatedOn = DateTime.Now;
                model.SA_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.SA_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveSuperAdmin(tblSuperAdmin model)
        {
            try
            {
                model = GetSuperAdminByID(model.SA_ID);
                model.SA_IsActive = true;
                model.SA_UpdatedOn = DateTime.Now;
                model.SA_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.SA_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Operations_On_Doctors_Table

        public bool InsertDoctor(tblDoctor model)
        {
            try
            {
                model.D_IsActive = true;
                model.D_CreatedOn = DateTime.Now;
                model.D_UpdatedOn = null;
                model.D_UpdatedBy = null;
                model.D_IsArchive = false;
                model.D_RoleID = 3;
                model.D_IsProfileCompleted = false;
                _context.tblDoctors.Add(model);
                Save();
                if (model.D_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDoctor(tblDoctor model)
        {
            try
            {
                model.D_IsActive = true;
                model.D_CreatedOn = GetDoctorByID(model.D_ID).D_CreatedOn;
                model.D_CreatedBy = GetDoctorByID(model.D_ID).D_CreatedBy;
                model.D_UpdatedOn = DateTime.Now;
                model.D_RoleID = 3;
                model.D_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.D_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblDoctor GetDoctorByID(int modelId)
        {
            return _context.tblDoctors.Find(modelId);
        }

        public bool InActiveDoctor(tblDoctor model)
        {
            try
            {
                model = GetDoctorByID(model.D_ID);
                model.D_IsActive = false;
                model.D_UpdatedOn = DateTime.Now;
                model.D_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.D_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveDoctor(tblDoctor model)
        {
            try
            {
                model = GetDoctorByID(model.D_ID);
                model.D_IsActive = true;
                model.D_UpdatedOn = DateTime.Now;
                model.D_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.D_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public void Save()
        {
            _context.SaveChanges();
        }

        #region Generate_OTP_Send_To_Email

        public void SendEmail(string otp, string emailtext)
        {
            var email = "ahnkhan804@gmail.com";
            using (MailMessage mm = new MailMessage(email, emailtext))
            {
                mm.Subject = "Password Reset OTP";
                mm.Body = "<p>Your <b>OTP:" + otp + "</b><br/>Don't share it with anyone!</p>";
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    mm.IsBodyHtml = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(email, "vcwonsjwxtsbyajf");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }
            }
        }

        public bool GenerateUserOTP(string emailtext)
        {
            if (!string.IsNullOrEmpty(emailtext) && emailtext.Length > 5)
            {
                var otp = OTPGenerator.GenerateRandomOTP();
                var reasOTP = _context.tblOTPs.Where(x => x.OT_UsersEmail == emailtext && x.OT_IsActive == true).FirstOrDefault();
                if (reasOTP != null)
                {
                    otp = reasOTP.OT_OTP;
                    SendEmail(otp, emailtext);
                    return true;
                }
                else
                {
                    tblOTP oTP = new tblOTP() 
                    {
                        OT_OTP = otp,
                        OT_UsersEmail = emailtext                    
                    };
                    var reas = InsertOTP(oTP);
                    if (reas)
                    {
                        SendEmail(otp, emailtext);
                        return true;
                    }
                    return false;
                }
            }
            else
                return false;
        }

        public bool CheckOTP(string emailtext, string OTP)
        {
            var reas = _context.tblOTPs.Where(x => x.OT_UsersEmail == emailtext && x.OT_OTP == OTP && x.OT_IsActive == true).FirstOrDefault();
            if (reas != null)
            {
                var reas1 = UpdateOTP(emailtext);
                if (reas1)
                    return true;
                return false;
            }
            else
                return false;
        }

        #endregion

        #region Get_Users_Details

        public UserViewDetail GetUserDetailByEmail(string emailtext)
        {
            var superAdmin = _context.tblSuperAdmins.Where(x => x.SA_Email == emailtext).Select(s => new UserViewDetail()
            {
                ID = s.SA_ID,
                Name = s.SA_FirstName,
                Email = s.SA_Email,
                Image = s.SA_ProfileImage,
                Password = s.SA_Password,
                OTP = s.SA_OTP,
                Role = s.tblRole.RoleName,
                Active = s.SA_IsActive.Value,
                PhoneNumber = s.SA_PhoneNumber,
                Gender = s.SA_Gender,
                IsProfileCompleted = true
            }).FirstOrDefault();

            var admin = _context.tblAdmins.Where(x => x.A_Email == emailtext).Select(s => new UserViewDetail()
            {
                ID = s.A_ID,
                Name = s.A_FirstName,
                Email = s.A_Email,
                Image = s.A_ProfileImage,
                Password = s.A_Password,
                OTP = s.A_OTP,
                Role = s.tblRole.RoleName,
                Active = s.A_IsActive.Value,
                PhoneNumber = s.A_PhoneNumber,
                Gender = s.A_Gender,
                IsProfileCompleted = true
            }).FirstOrDefault();

            var doctor = _context.tblDoctors.Where(x => x.D_Email == emailtext).Select(s => new UserViewDetail()
            {
                ID = s.D_ID,
                Name = s.D_FirstName,
                Email = s.D_Email,
                Image = s.D_ProfileImage,
                Password = s.D_Password,
                OTP = s.D_OTP,
                Role = s.tblRole.RoleName,
                Active = s.D_IsActive.Value,
                PhoneNumber = s.D_PhoneNumber,
                Gender = s.D_Gender,
                IsProfileCompleted = s.D_IsProfileCompleted == null ? false : s.D_IsProfileCompleted.Value,
            }).FirstOrDefault();

            var patients = _context.tblPatients.Where(x => x.P_Email == emailtext).Select(s => new UserViewDetail()
            {
                ID = s.P_ID,
                Name = s.P_FirstName,
                Email = s.P_Email,
                Image = s.P_ProfileImage,
                Password = s.P_Password,
                OTP = s.P_OTP,
                Role = s.tblRole.RoleName,
                Active = s.P_IsActive.Value,
                PhoneNumber = s.P_PhoneNumber,
                Gender = s.P_Gender,
                IsProfileCompleted = true
            }).FirstOrDefault();

            if (superAdmin != null)
            {
                return superAdmin;
            }
            else if (admin != null)
            {
                return admin;
            }
            else if (patients != null)
            {
                return patients;
            }
            else if (doctor != null)
            {
                return doctor;
            }
            else
                return null;
        }

        public ValidateUsersProfiles GetUserDetailById(int Id, string Role)
        {
            var patients = _context.tblPatients.Where(x => x.P_ID == Id && x.tblRole.RoleName.ToLower().Contains(Role.ToLower())).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.P_ID,
                UserFirstName = s.P_FirstName,
                UserLastName = s.P_LastName,
                UserEmail = s.P_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.P_PhoneNumber,
                UserProfileImage = s.P_ProfileImage,
                UserPassword = s.P_Password,
                tblRole = s.tblRole,
                UserIsActive = s.P_IsActive.Value,
                UserVerified = s.P_Verified.Value,
                UserOTP = s.P_OTP,
                UserIsArchive = s.P_IsArchive.Value,
                UserUpdatedBy = s.P_UpdatedBy.Value,
                UserUpdatedOn = s.P_UpdatedOn.Value,
                UserCreatedBy = s.P_CreatedBy.Value,
                UserCreatedOn = s.P_CreatedOn.Value,
                Gender = s.P_Gender,
                IsProfileCompleted = true,
            }).FirstOrDefault();

            var admin = _context.tblAdmins.Where(x => x.A_ID == Id && x.tblRole.RoleName.ToLower().Contains(Role.ToLower())).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.A_ID,
                UserFirstName = s.A_FirstName,
                UserLastName = s.A_LastName,
                UserEmail = s.A_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.A_PhoneNumber,
                UserProfileImage = s.A_ProfileImage,
                UserPassword = s.A_Password,
                tblRole = s.tblRole,
                UserIsActive = s.A_IsActive.Value,
                UserVerified = s.A_Verified.Value,
                UserOTP = s.A_OTP,
                UserIsArchive = s.A_IsArchive.Value,
                UserUpdatedBy = s.A_UpdatedBy.Value,
                UserUpdatedOn = s.A_UpdatedOn.Value,
                UserCreatedBy = s.A_CreatedBy.Value,
                UserCreatedOn = s.A_CreatedOn.Value,
                Gender = s.A_Gender,
                IsProfileCompleted = true,
            }).FirstOrDefault();

            var superAdmin = _context.tblSuperAdmins.Where(x => x.SA_ID == Id && x.tblRole.RoleName.ToLower().Contains(Role.ToLower())).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.SA_ID,
                UserFirstName = s.SA_FirstName,
                UserLastName = s.SA_LastName,
                UserEmail = s.SA_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.SA_PhoneNumber,
                UserProfileImage = s.SA_ProfileImage,
                UserPassword = s.SA_Password,
                tblRole = s.tblRole,
                UserIsActive = s.SA_IsActive.Value,
                UserVerified = s.SA_Verified.Value,
                UserOTP = s.SA_OTP,
                UserIsArchive = s.SA_IsArchive.Value,
                UserUpdatedBy = s.SA_UpdatedBy.Value,
                UserUpdatedOn = s.SA_UpdatedOn.Value,
                UserCreatedBy = s.SA_CreatedBy.Value,
                UserCreatedOn = s.SA_CreatedOn.Value,
                Gender = s.SA_Gender,
                IsProfileCompleted = true,
            }).FirstOrDefault();

            var doctor = _context.tblDoctors.Where(x => x.D_ID == Id && x.tblRole.RoleName.ToLower().Contains(Role.ToLower())).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.D_ID,
                UserFirstName = s.D_FirstName,
                UserLastName = s.D_LastName,
                UserEmail = s.D_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.D_PhoneNumber,
                UserProfileImage = s.D_ProfileImage,
                UserPassword = s.D_Password,
                tblRole = s.tblRole,
                UserIsActive = s.D_IsActive.Value,
                UserVerified = s.D_Verified.Value,
                UserOTP = s.D_OTP,
                UserIsArchive = s.D_IsArchive.Value,
                UserUpdatedBy = s.D_UpdatedBy.Value,
                UserUpdatedOn = s.D_UpdatedOn.Value,
                UserCreatedBy = s.D_CreatedBy.Value,
                UserCreatedOn = s.D_CreatedOn.Value,
                Gender = s.D_Gender,
                IsProfileCompleted = s.D_IsProfileCompleted == null ? false : s.D_IsProfileCompleted.Value,
            }).FirstOrDefault();

            if (superAdmin != null)
            {
                return superAdmin;
            }
            else if (admin != null)
            {
                return admin;
            }
            else if (patients != null)
            {
                return patients;
            }
            else if (doctor != null)
            {
                return doctor;
            }
            else
                return null;
        }

        public ValidateUsersProfiles GetUserDetailById(int Id)
        {
            var patients = _context.tblPatients.Where(x => x.P_ID == Id).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.P_ID,
                UserFirstName = s.P_FirstName,
                UserLastName = s.P_LastName,
                UserEmail = s.P_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.P_PhoneNumber,
                UserProfileImage = s.P_ProfileImage,
                UserPassword = s.P_Password,
                tblRole = s.tblRole,
                UserIsActive = s.P_IsActive.Value,
                UserVerified = s.P_Verified.Value,
                UserOTP = s.P_OTP,
                UserIsArchive = s.P_IsArchive.Value,
                UserUpdatedBy = s.P_UpdatedBy.Value,
                UserUpdatedOn = s.P_UpdatedOn.Value,
                UserCreatedBy = s.P_CreatedBy.Value,
                UserCreatedOn = s.P_CreatedOn.Value,
                Gender = s.P_Gender,
                IsProfileCompleted = true,
            }).FirstOrDefault();

            var admin = _context.tblAdmins.Where(x => x.A_ID == Id).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.A_ID,
                UserFirstName = s.A_FirstName,
                UserLastName = s.A_LastName,
                UserEmail = s.A_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.A_PhoneNumber,
                UserProfileImage = s.A_ProfileImage,
                UserPassword = s.A_Password,
                tblRole = s.tblRole,
                UserIsActive = s.A_IsActive.Value,
                UserVerified = s.A_Verified.Value,
                UserOTP = s.A_OTP,
                UserIsArchive = s.A_IsArchive.Value,
                UserUpdatedBy = s.A_UpdatedBy.Value,
                UserUpdatedOn = s.A_UpdatedOn.Value,
                UserCreatedBy = s.A_CreatedBy.Value,
                UserCreatedOn = s.A_CreatedOn.Value,
                Gender = s.A_Gender,
                IsProfileCompleted = true,
            }).FirstOrDefault();

            var superAdmin = _context.tblSuperAdmins.Where(x => x.SA_ID == Id).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.SA_ID,
                UserFirstName = s.SA_FirstName,
                UserLastName = s.SA_LastName,
                UserEmail = s.SA_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.SA_PhoneNumber,
                UserProfileImage = s.SA_ProfileImage,
                UserPassword = s.SA_Password,
                tblRole = s.tblRole,
                UserIsActive = s.SA_IsActive.Value,
                UserVerified = s.SA_Verified.Value,
                UserOTP = s.SA_OTP,
                UserIsArchive = s.SA_IsArchive.Value,
                UserUpdatedBy = s.SA_UpdatedBy.Value,
                UserUpdatedOn = s.SA_UpdatedOn.Value,
                UserCreatedBy = s.SA_CreatedBy.Value,
                UserCreatedOn = s.SA_CreatedOn.Value,
                Gender = s.SA_Gender,
                IsProfileCompleted = true,
            }).FirstOrDefault();

            var doctor = _context.tblDoctors.Where(x => x.D_ID == Id).Select(s => new ValidateUsersProfiles()
            {
                UserID = s.D_ID,
                UserFirstName = s.D_FirstName,
                UserLastName = s.D_LastName,
                UserEmail = s.D_Email,
                tblAddress = s.tblAddress,
                UserPhoneNumber = s.D_PhoneNumber,
                UserProfileImage = s.D_ProfileImage,
                UserPassword = s.D_Password,
                tblRole = s.tblRole,
                UserIsActive = s.D_IsActive.Value,
                UserVerified = s.D_Verified.Value,
                UserOTP = s.D_OTP,
                UserIsArchive = s.D_IsArchive.Value,
                UserUpdatedBy = s.D_UpdatedBy.Value,
                UserUpdatedOn = s.D_UpdatedOn.Value,
                UserCreatedBy = s.D_CreatedBy.Value,
                UserCreatedOn = s.D_CreatedOn.Value,
                Gender = s.D_Gender,
                IsProfileCompleted = s.D_IsProfileCompleted == null ? false : s.D_IsProfileCompleted.Value,
            }).FirstOrDefault();

            if (superAdmin != null)
            {
                return superAdmin;
            }
            else if (admin != null)
            {
                return admin;
            }
            else if (patients != null)
            {
                return patients;
            }
            else if (doctor != null)
            {
                return doctor;
            }
            else
                return null;
        }

        public UserViewDetail GetUserDetailsByPhoneNumber(string phone)
        {
            var user = _context.tblPatients.Where(x => x.P_PhoneNumber == phone).Select(s => new UserViewDetail()
            {
                PhoneNumber = s.P_PhoneNumber
            }).FirstOrDefault();

            var admin = _context.tblAdmins.Where(x => x.A_PhoneNumber == phone).Select(s => new UserViewDetail()
            {
                PhoneNumber = s.A_PhoneNumber
            }).FirstOrDefault();

            var doctor = _context.tblDoctors.Where(x => x.D_PhoneNumber == phone).Select(s => new UserViewDetail()
            {
                PhoneNumber = s.D_PhoneNumber,
            }).FirstOrDefault();

            var superAdmin = _context.tblSuperAdmins.Where(x => x.SA_PhoneNumber == phone).Select(s => new UserViewDetail()
            {
                PhoneNumber = s.SA_PhoneNumber
            }).FirstOrDefault();

            if (user != null)
            {
                return user;
            }
            else if (admin != null)
            {
                return admin;
            }
            else if (superAdmin != null)
            {
                return superAdmin;
            }
            else if (doctor != null)
            {
                return doctor;
            }
            else
                return null;
        }

        #endregion
    }
}
