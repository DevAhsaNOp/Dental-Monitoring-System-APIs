using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;
using System;
using DMS_DAL.UserDefine;

namespace DMS_BLL.Repositories
{
    public class UsersRepo
    {
        private UsersDb dbObj;
        private AddressRepo addressRepo;

        public UsersRepo()
        {
            dbObj = new UsersDb();
            addressRepo = new AddressRepo();
        }

        public int InsertPatient(ValidatePatient model)
        {
            if (model != null)
            {
                if (!IsEmailExist(model.UserEmail))
                {
                    if (!IsPhoneNumberExist(model.UserPhoneNumber))
                    {
                        if (CheckOTP(model.UserEmail, model.UserOTP))
                        {
                            tblAddress AddrsObj = new tblAddress()
                            {
                                AddressCountry = 1,
                                AddressState = model.StateID,
                                AddressCity = model.CityID,
                                AddressZone = model.AreaID,
                                AddressComplete = (model.CompleteAddress == null) ? "" : model.CompleteAddress,
                            };
                            var addressID = addressRepo.InsertAddress(AddrsObj);
                            if (addressID > 0)
                            {
                                tblPatient PatientObj = new tblPatient()
                                {
                                    P_FirstName = model.UserFirstName,
                                    P_LastName = model.UserLastName,
                                    P_Email = model.UserEmail,
                                    P_AddressID = addressID,
                                    P_PhoneNumber = model.UserPhoneNumber,
                                    P_Gender = model.Gender,
                                    P_Password = EncDec.Encrypt(model.UserPassword),
                                    P_ProfileImage = model.UserProfileImage,
                                    P_OTP = null,
                                    P_Verified = true,
                                    P_CreatedBy = model.UserCreatedBy
                                };
                                var reas = dbObj.InsertPatient(PatientObj);
                                if (reas)
                                    return 1;
                                return 0;
                            }
                            else
                                return 0;
                        }
                        else
                            return -1;
                    }
                    else
                        return -3;
                }
                else
                    return -2;
            }
            else
                return 0;
        }

        public int UpdatePatient(ValidatePatient model)
        {
            if (model != null)
            {
                if (!IsUpdatePhoneNumberExist(model.UserPhoneNumber, model.UserUpdatePhoneNumber))
                {
                    if (!IsUpdateEmailExist(model.UserEmail, model.UserUpdateEmail))
                    {
                        tblAddress AddrsObj = new tblAddress()
                        {
                            AddressID = GetPatientByID(model.UserID).P_AddressID.Value,
                            AddressCountry = 1,
                            AddressState = model.StateID,
                            AddressCity = model.CityID,
                            AddressZone = model.AreaID,
                            AddressComplete = (model.CompleteAddress == null) ? "" : model.CompleteAddress
                        };
                        var addressID = addressRepo.UpdateAddress(AddrsObj);
                        if (addressID > 0)
                        {
                            var PatientObj = GetPatientByID(model.UserID);
                            PatientObj.P_ID = model.UserID;
                            PatientObj.P_FirstName = model.UserFirstName;
                            PatientObj.P_LastName = model.UserLastName;
                            PatientObj.P_Email = model.UserEmail;
                            PatientObj.P_AddressID = addressID;
                            PatientObj.P_PhoneNumber = model.UserPhoneNumber;
                            PatientObj.P_Gender = model.Gender;
                            PatientObj.P_Password = EncDec.Encrypt(model.UserPassword);
                            PatientObj.P_ProfileImage = model.UserProfileImage;
                            PatientObj.P_OTP = model.UserOTP;
                            PatientObj.P_Verified = true;
                            PatientObj.P_UpdatedBy = model.UserUpdatedBy;
                            var reas = dbObj.UpdatePatient(PatientObj);
                            if (reas)
                                return 1;
                            return 0;
                        }
                        else
                            return 0;
                    }
                    else
                        return -1;
                }
                else
                    return -2;
            }
            else
                return 0;
        }

        public bool InActivePatient(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblPatient PatientObj = new tblPatient()
                {
                    P_ID = model.UserID,
                    P_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.InActivePatient(PatientObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public bool ReActivePatient(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblPatient PatientObj = new tblPatient()
                {
                    P_ID = model.UserID,
                    P_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.ReActivePatient(PatientObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public tblPatient GetPatientByID(int modelId)
        {
            if (modelId > 0)
                return dbObj.GetPatientByID(modelId);
            else
                return null;
        }

        public ValidateUsersProfiles GetUserDetailById(int Id, string Role)
        {
            if (Id > 0 && Role.Length > 4)
                return dbObj.GetUserDetailById(Id, Role);
            else
                return null;
        }

        public ValidateUsersProfiles GetUserDetailById(int Id)
        {
            if (Id > 0)
                return dbObj.GetUserDetailById(Id);
            else
                return null;
        }

        public bool IsEmailExist(string Email)
        {
            if (!string.IsNullOrEmpty(Email) && Email.Length > 5)
            {
                var reas = GetUserDetailByEmail(Email);
                if (reas != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsPhoneNumberExist(string PhoneNumber)
        {
            if (!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.Length == 11)
            {
                var reas = dbObj.GetUserDetailsByPhoneNumber(PhoneNumber);
                if (reas != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsUpdateEmailExist(string Email, string CurrentEmail)
        {
            if (!string.IsNullOrEmpty(Email) && Email.Length > 5 && !string.IsNullOrEmpty(CurrentEmail) && CurrentEmail.Length > 5 && Email != CurrentEmail)
            {
                var reas = IsEmailExist(Email);
                if (reas)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsUpdatePhoneNumberExist(string PhoneNumber, string CurrentPhoneNumber)
        {
            if (!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.Length == 11 && !string.IsNullOrEmpty(CurrentPhoneNumber) && CurrentPhoneNumber.Length == 11 && PhoneNumber != CurrentPhoneNumber)
            {
                var reas = IsPhoneNumberExist(PhoneNumber);
                if (reas)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public UserViewDetail GetUserDetailByEmail(string emailtext)
        {
            if (!string.IsNullOrEmpty(emailtext) && emailtext.Length > 5)
            {
                return dbObj.GetUserDetailByEmail(emailtext);
            }
            else
                return null;
        }

        public UserViewDetail CheckLoginDetails(string emailtext, string password)
        {
            try
            {
                var reas = GetUserDetailByEmail(emailtext);
                if (reas != null)
                {
                    if (EncDec.Decrypt(reas.Password).Equals(password))
                    {
                        var entity = GetUserDetailByEmail(emailtext);
                        return entity;
                    }
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GenerateUserOTP(string emailtext)
        {
            if (!string.IsNullOrEmpty(emailtext) && emailtext.Length > 5)
            {
                var reas = dbObj.GenerateUserOTP(emailtext);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public bool CheckOTP(string emailtext, string OTP)
        {
            if (!string.IsNullOrEmpty(emailtext) && emailtext.Length > 5 && !string.IsNullOrEmpty(OTP) && OTP.Length > 5)
            {
                var reas = dbObj.CheckOTP(emailtext, OTP);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }
    }
}
