using DMS_BOL.Validation_Classes;
using DMS_BOL;
using DMS_DAL.DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS_BLL.Repositories
{
    public class DoctorsRepo
    {
        private UsersDb dbObj;
        private AddressRepo addressRepo;
        private UsersRepo usersRepo;

        public DoctorsRepo()
        {
            dbObj = new UsersDb();
            addressRepo = new AddressRepo();
            usersRepo = new UsersRepo();
        }

        public int InsertDoctor(ValidateDoctor model)
        {
            if (model != null)
            {
                if (!usersRepo.IsEmailExist(model.UserEmail))
                {
                    if (!usersRepo.IsPhoneNumberExist(model.UserPhoneNumber))
                    {
                        if (usersRepo.CheckOTP(model.UserEmail, model.UserOTP))
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
                                tblDoctor DoctorObj = new tblDoctor()
                                {
                                    D_FirstName = model.UserFirstName,
                                    D_LastName = model.UserLastName,
                                    D_Email = model.UserEmail,
                                    D_AddressID = addressID,
                                    D_PhoneNumber = model.UserPhoneNumber,
                                    D_Password = EncDec.Encrypt(model.UserPassword),
                                    D_ProfileImage = model.UserProfileImage,
                                    D_OTP = null,
                                    D_Verified = true,
                                    D_CreatedBy = model.UserCreatedBy,
                                    D_YearsOfExperience = model.DoctorYearsOfExperience,
                                    D_Specialization = model.DoctorSpecialization,
                                    D_WorkPhoneNumber = model.DoctorWorkPhoneNumber,
                                    D_AwardsAndAchievements = model.DoctorAwardsAndAchievements,
                                    D_AboutMe = model.DoctorAboutMe,
                                    D_SatisfactionRate = model.DoctorSatisfactionRate,
                                    D_ResponseTime = model.DoctorResponseTime
                                };
                                var reas = dbObj.InsertDoctor(DoctorObj);
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

        public int UpdateDoctor(ValidateDoctor model)
        {
            if (model != null)
            {
                if (!usersRepo.IsPhoneNumberExist(model.UserPhoneNumber) && model.UserUpdatePhoneNumber != model.UserPhoneNumber)
                {
                    if (!usersRepo.IsEmailExist(model.UserEmail) && model.UserUpdateEmail != model.UserEmail)
                    {
                        tblAddress AddrsObj = new tblAddress()
                        {
                            AddressID = GetDoctorByID(model.UserID).D_AddressID.Value,
                            AddressCountry = 1,
                            AddressState = model.StateID,
                            AddressCity = model.CityID,
                            AddressZone = model.AreaID,
                            AddressComplete = (model.CompleteAddress == null) ? "" : model.CompleteAddress
                        };
                        var addressID = addressRepo.UpdateAddress(AddrsObj);
                        if (addressID > 0)
                        {
                            var DoctorObj = GetDoctorByID(model.UserID);
                            DoctorObj.D_ID = model.UserID;
                            DoctorObj.D_FirstName = model.UserFirstName;
                            DoctorObj.D_LastName = model.UserLastName;
                            DoctorObj.D_Email = model.UserEmail;
                            DoctorObj.D_AddressID = addressID;
                            DoctorObj.D_PhoneNumber = model.UserPhoneNumber;
                            DoctorObj.D_Password = EncDec.Encrypt(model.UserPassword);
                            DoctorObj.D_ProfileImage = model.UserProfileImage;
                            DoctorObj.D_AboutMe = model.DoctorAboutMe;
                            DoctorObj.D_AwardsAndAchievements = model.DoctorAwardsAndAchievements;
                            DoctorObj.D_ResponseTime = model.DoctorResponseTime;
                            DoctorObj.D_SatisfactionRate = model.DoctorSatisfactionRate;
                            DoctorObj.D_Specialization = model.DoctorSpecialization;
                            DoctorObj.D_WorkPhoneNumber = model.DoctorWorkPhoneNumber;
                            DoctorObj.D_OTP = model.UserOTP;
                            DoctorObj.D_Verified = true;
                            DoctorObj.D_UpdatedBy = model.UserUpdatedBy;
                            var reas = dbObj.UpdateDoctor(DoctorObj);
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

        public bool InActiveDoctor(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblDoctor DoctorObj = new tblDoctor()
                {
                    D_ID = model.UserID,
                    D_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.InActiveDoctor(DoctorObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public bool ReActiveDoctor(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblDoctor DoctorObj = new tblDoctor()
                {
                    D_ID = model.UserID,
                    D_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.ReActiveDoctor(DoctorObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public tblDoctor GetDoctorByID(int modelId)
        {
            if (modelId > 0)
                return dbObj.GetDoctorByID(modelId);
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
    }
}
