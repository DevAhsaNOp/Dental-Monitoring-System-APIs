using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;

namespace DMS_BLL.Repositories
{
    public class SuperAdminsRepo
    {
        private UsersDb dbObj;
        private AddressRepo addressRepo;
        private UsersRepo usersRepo;

        public SuperAdminsRepo()
        {
            dbObj = new UsersDb();
            addressRepo = new AddressRepo();
            usersRepo = new UsersRepo();
        }

        public int InsertSuperAdmin(ValidateSuperAdmin model)
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
                                tblSuperAdmin SuperAdminObj = new tblSuperAdmin()
                                {
                                    SA_FirstName = model.UserFirstName,
                                    SA_LastName = model.UserLastName,
                                    SA_Email = model.UserEmail,
                                    SA_AddressID = addressID,
                                    SA_PhoneNumber = model.UserPhoneNumber,
                                    SA_Gender = model.Gender,
                                    SA_Password = EncDec.Encrypt(model.UserPassword),
                                    SA_ProfileImage = model.UserProfileImage,
                                    SA_OTP = null,
                                    SA_Verified = true,
                                    SA_CreatedBy = model.UserCreatedBy
                                };
                                var reas = dbObj.InsertSuperAdmin(SuperAdminObj);
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

        public int UpdateSuperAdmin(ValidateSuperAdmin model)
        {
            if (model != null)
            {
                if (!usersRepo.IsUpdatePhoneNumberExist(model.UserPhoneNumber, model.UserUpdatePhoneNumber))
                {
                    if (!usersRepo.IsUpdateEmailExist(model.UserEmail, model.UserUpdateEmail))
                    {
                        tblAddress AddrsObj = new tblAddress()
                        {
                            AddressID = GetSuperAdminByID(model.UserID).SA_AddressID.Value,
                            AddressCountry = 1,
                            AddressState = model.StateID,
                            AddressCity = model.CityID,
                            AddressZone = model.AreaID,
                            AddressComplete = (model.CompleteAddress == null) ? "" : model.CompleteAddress
                        };
                        var addressID = addressRepo.UpdateAddress(AddrsObj);
                        if (addressID > 0)
                        {
                            var SuperAdminObj = GetSuperAdminByID(model.UserID);
                            SuperAdminObj.SA_ID = model.UserID;
                            SuperAdminObj.SA_FirstName = model.UserFirstName;
                            SuperAdminObj.SA_LastName = model.UserLastName;
                            SuperAdminObj.SA_Email = model.UserEmail;
                            SuperAdminObj.SA_AddressID = addressID;
                            SuperAdminObj.SA_PhoneNumber = model.UserPhoneNumber;
                            SuperAdminObj.SA_Gender = model.Gender;
                            SuperAdminObj.SA_Password = EncDec.Encrypt(model.UserPassword);
                            SuperAdminObj.SA_ProfileImage = model.UserProfileImage;
                            SuperAdminObj.SA_OTP = model.UserOTP;
                            SuperAdminObj.SA_Verified = true;
                            SuperAdminObj.SA_UpdatedBy = model.UserUpdatedBy;
                            var reas = dbObj.UpdateSuperAdmin(SuperAdminObj);
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

        public bool InActiveSuperAdmin(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblSuperAdmin SuperAdminObj = new tblSuperAdmin()
                {
                    SA_ID = model.UserID,
                    SA_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.InActiveSuperAdmin(SuperAdminObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public bool ReActiveSuperAdmin(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblSuperAdmin SuperAdminObj = new tblSuperAdmin()
                {
                    SA_ID = model.UserID,
                    SA_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.ReActiveSuperAdmin(SuperAdminObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public tblSuperAdmin GetSuperAdminByID(int modelId)
        {
            if (modelId > 0)
                return dbObj.GetSuperAdminByID(modelId);
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
