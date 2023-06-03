using System;
using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;
using System.Collections.Generic;

namespace DMS_BLL.Repositories
{
    public class DoctorOfflineConsultaionDetailsRepo
    {
        private DoctorOfflineConsultaionDetailsDb ofcdRepo;

        public DoctorOfflineConsultaionDetailsRepo()
        {
            ofcdRepo = new DoctorOfflineConsultaionDetailsDb();
        }

        public bool InsertOfflineConsultaionDetail(ValidateDoctorOfflineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    tblOfflineConsultaionDetail doctorService = new tblOfflineConsultaionDetail()
                    {
                        OFCD_DoctorID = model.OFCD_DoctorID,
                        OFCD_Charges = model.OFCD_Charges.Value,
                        OFCD_MondayStartTime = model.OFCD_MondayStartTime,
                        OFCD_MondayEndTime = model.OFCD_MondayEndTime,
                        OFCD_TuesdayStartTime = model.OFCD_TuesdayStartTime,
                        OFCD_TuesdayEndTime = model.OFCD_TuesdayEndTime,
                        OFCD_WednesdayStartTime = model.OFCD_WednesdayStartTime,
                        OFCD_WednesdayEndTime = model.OFCD_WednesdayEndTime,
                        OFCD_ThursdayStartTime = model.OFCD_ThursdayStartTime,
                        OFCD_ThursdayEndTime = model.OFCD_ThursdayEndTime,
                        OFCD_FridayStartTime = model.OFCD_FridayStartTime,
                        OFCD_FridayEndTime = model.OFCD_FridayEndTime,
                        OFCD_SaturdayStartTime = model.OFCD_SaturdayStartTime,
                        OFCD_SaturdayEndTime = model.OFCD_SaturdayEndTime,
                        OFCD_SundayStartTime = model.OFCD_SundayStartTime,
                        OFCD_SundayEndTime = model.OFCD_SundayEndTime,
                        OFCD_CreatedBy = model.OFCD_CreatedBy,
                    };
                    var reas = ofcdRepo.InsertOfflineConsultaionDetails(doctorService);
                    if (reas)
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateOfflineConsultaionDetail(ValidateDoctorOfflineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    var modelOCD = GetOfflineConsultaionDetailByID(model.OFCD_ID);
                    modelOCD.OFCD_DoctorID = model.OFCD_DoctorID;
                    modelOCD.OFCD_Charges = model.OFCD_Charges.Value;
                    modelOCD.OFCD_MondayStartTime = model.OFCD_MondayStartTime;
                    modelOCD.OFCD_MondayEndTime = model.OFCD_MondayEndTime;
                    modelOCD.OFCD_TuesdayStartTime = model.OFCD_TuesdayStartTime;
                    modelOCD.OFCD_TuesdayEndTime = model.OFCD_TuesdayEndTime;
                    modelOCD.OFCD_WednesdayStartTime = model.OFCD_WednesdayStartTime;
                    modelOCD.OFCD_WednesdayEndTime = model.OFCD_WednesdayEndTime;
                    modelOCD.OFCD_ThursdayStartTime = model.OFCD_ThursdayStartTime;
                    modelOCD.OFCD_ThursdayEndTime = model.OFCD_ThursdayEndTime;
                    modelOCD.OFCD_FridayStartTime = model.OFCD_FridayStartTime;
                    modelOCD.OFCD_FridayEndTime = model.OFCD_FridayEndTime;
                    modelOCD.OFCD_SaturdayStartTime = model.OFCD_SaturdayStartTime;
                    modelOCD.OFCD_SaturdayEndTime = model.OFCD_SaturdayEndTime;
                    modelOCD.OFCD_SundayStartTime = model.OFCD_SundayStartTime;
                    modelOCD.OFCD_SundayEndTime = model.OFCD_SundayEndTime;
                    modelOCD.OFCD_UpdatedBy = model.OFCD_UpdatedBy;
                    var reas = ofcdRepo.UpdateOfflineConsultaionDetails(modelOCD);
                    if (reas)
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblOfflineConsultaionDetail GetOfflineConsultaionDetailByID(int modelId)
        {
            if (modelId > 0)
                return ofcdRepo.GetOfflineConsultaionDetailsByID(modelId);
            return null;
        }

        public IEnumerable<tblOfflineConsultaionDetail> GetDoctorAllOfflineConsultaionDetailsByID(int modelId)
        {
            if (modelId > 0)
                return ofcdRepo.GetDoctorAllOfflineConsultaionDetailsByID(modelId);
            return null;
        }

        public bool InActiveOfflineConsultaionDetail(ValidateDoctorOfflineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    tblOfflineConsultaionDetail doctorService = new tblOfflineConsultaionDetail()
                    {
                        OFCD_ID = model.OFCD_ID,
                        OFCD_UpdatedBy = model.OFCD_UpdatedBy,
                    };
                    var reas = ofcdRepo.InActiveOfflineConsultaionDetails(doctorService);
                    if (reas)
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveOfflineConsultaionDetail(ValidateDoctorOfflineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    tblOfflineConsultaionDetail doctorService = new tblOfflineConsultaionDetail()
                    {
                        OFCD_ID = model.OFCD_ID,
                        OFCD_UpdatedBy = model.OFCD_UpdatedBy,
                    };
                    var reas = ofcdRepo.ReActiveOfflineConsultaionDetails(doctorService);
                    if (reas)
                        return true;
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
