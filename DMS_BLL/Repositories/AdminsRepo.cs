using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;

namespace DMS_BLL.Repositories
{
    public class AdminsRepo
    {
        private UsersDb dbObj;
        private AddressRepo addressRepo;
        private UsersRepo usersRepo;

        public AdminsRepo()
        {
            dbObj = new UsersDb();
            addressRepo = new AddressRepo();
            usersRepo = new UsersRepo();
        }

        public int InsertAdmin(ValidateAdmin model)
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
                                tblAdmin AdminObj = new tblAdmin()
                                {
                                    A_FirstName = model.UserFirstName,
                                    A_LastName = model.UserLastName,
                                    A_Email = model.UserEmail,
                                    A_AddressID = addressID,
                                    A_PhoneNumber = model.UserPhoneNumber,
                                    A_Password = EncDec.Encrypt(model.UserPassword),
                                    A_ProfileImage = model.UserProfileImage,
                                    A_Gender = model.Gender,
                                    A_OTP = null,
                                    A_Verified = true,
                                    A_CreatedBy = model.UserCreatedBy
                                };
                                var reas = dbObj.InsertAdmin(AdminObj);
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

        public int UpdateAdmin(ValidateAdmin model)
        {
            if (model != null)
            {
                if (!usersRepo.IsUpdatePhoneNumberExist(model.UserPhoneNumber, model.UserUpdatePhoneNumber))
                {
                    if (!usersRepo.IsUpdateEmailExist(model.UserEmail, model.UserUpdateEmail))
                    {
                        tblAddress AddrsObj = new tblAddress()
                        {
                            AddressID = GetAdminByID(model.UserID).A_AddressID.Value,
                            AddressCountry = 1,
                            AddressState = model.StateID,
                            AddressCity = model.CityID,
                            AddressZone = model.AreaID,
                            AddressComplete = (model.CompleteAddress == null) ? "" : model.CompleteAddress
                        };
                        var addressID = addressRepo.UpdateAddress(AddrsObj);
                        if (addressID > 0)
                        {
                            var AdminObj = GetAdminByID(model.UserID);
                            AdminObj.A_ID = model.UserID;
                            AdminObj.A_FirstName = model.UserFirstName;
                            AdminObj.A_LastName = model.UserLastName;
                            AdminObj.A_Email = model.UserEmail;
                            AdminObj.A_AddressID = addressID;
                            AdminObj.A_PhoneNumber = model.UserPhoneNumber;
                            AdminObj.A_Gender = model.Gender;
                            AdminObj.A_Password = EncDec.Encrypt(model.UserPassword);
                            AdminObj.A_ProfileImage = model.UserProfileImage;
                            AdminObj.A_OTP = model.UserOTP;
                            AdminObj.A_Verified = true;
                            AdminObj.A_UpdatedBy = model.UserUpdatedBy;
                            var reas = dbObj.UpdateAdmin(AdminObj);
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

        public bool InActiveAdmin(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblAdmin AdminObj = new tblAdmin()
                {
                    A_ID = model.UserID,
                    A_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.InActiveAdmin(AdminObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public bool ReActiveAdmin(ValidateUsersIA model)
        {
            if (model != null)
            {
                tblAdmin AdminObj = new tblAdmin()
                {
                    A_ID = model.UserID,
                    A_UpdatedBy = model.UserUpdatedBy
                };
                var reas = dbObj.ReActiveAdmin(AdminObj);
                if (reas)
                    return true;
                return false;
            }
            else
                return false;
        }

        public tblAdmin GetAdminByID(int modelId)
        {
            if (modelId > 0)
                return dbObj.GetAdminByID(modelId);
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
