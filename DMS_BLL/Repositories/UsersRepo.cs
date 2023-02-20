using DMS_BOL;
using JRCar.BLL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;

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

        public bool InsertPatient(ValidatePatient model)
        {
            if (model != null)
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
                        P_Password = EncDec.Encrypt(model.UserPassword),
                        P_ProfileImage= model.UserProfileImage,
                        P_OTP = model.UserOTP,
                        P_Verified= model.UserVerified,
                        P_CreatedBy= model.UserCreatedBy                        
                    };
                    var reas = dbObj.InsertPatient(PatientObj);
                    if (reas)
                        return true;
                    return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
