using System;
using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;
using System.Collections.Generic;

namespace DMS_BLL.Repositories
{
    public class DoctorOnlineConsultaionDetailsRepo
    {
        private DoctorOnlineConsultaionDetailsDb ocdRepo;

        public DoctorOnlineConsultaionDetailsRepo()
        {
            ocdRepo = new DoctorOnlineConsultaionDetailsDb();
        }

        public bool InsertOnlineConsultaionDetail(ValidateDoctorOnlineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    tblOnlineConsultaionDetail doctorService = new tblOnlineConsultaionDetail()
                    {
                        OCD_DoctorID = model.OCD_DoctorID,
                        OCD_Charges = model.OCD_Charges,
                        OCD_MondayStartTime = model.OCD_MondayStartTime,
                        OCD_MondayEndTime = model.OCD_MondayEndTime,
                        OCD_TuesdayStartTime = model.OCD_TuesdayStartTime,
                        OCD_TuesdayEndTime = model. OCD_TuesdayEndTime,
                        OCD_WednesdayStartTime = model.OCD_WednesdayStartTime,
                        OCD_WednesdayEndTime = model.OCD_WednesdayEndTime,
                        OCD_ThursdayStartTime = model.OCD_ThursdayStartTime,
                        OCD_ThursdayEndTime = model.OCD_ThursdayEndTime,
                        OCD_FridayStartTime = model.OCD_FridayStartTime,
                        OCD_FridayEndTime = model.OCD_FridayEndTime,
                        OCD_SaturdayStartTime = model. OCD_SaturdayStartTime,
                        OCD_SaturdayEndTime = model.OCD_SaturdayEndTime,
                        OCD_SundayStartTime = model.OCD_SundayStartTime,
                        OCD_SundayEndTime = model.OCD_SundayEndTime,                       
                        OCD_CreatedBy = model.OCD_CreatedBy,
                    };
                    var reas = ocdRepo.InsertOnlineConsultaionDetails(doctorService);
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

        public bool UpdateOnlineConsultaionDetail(ValidateDoctorOnlineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    var modelOCD = GetOnlineConsultaionDetailByID(model.OCD_ID);
                    modelOCD.OCD_DoctorID = model.OCD_DoctorID;
                    modelOCD.OCD_Charges = model.OCD_Charges;
                    modelOCD.OCD_MondayStartTime = model.OCD_MondayStartTime;
                    modelOCD.OCD_MondayEndTime = model.OCD_MondayEndTime;
                    modelOCD.OCD_TuesdayStartTime = model.OCD_TuesdayStartTime;
                    modelOCD.OCD_TuesdayEndTime = model.OCD_TuesdayEndTime;
                    modelOCD.OCD_WednesdayStartTime = model.OCD_WednesdayStartTime;
                    modelOCD.OCD_WednesdayEndTime = model.OCD_WednesdayEndTime;
                    modelOCD.OCD_ThursdayStartTime = model.OCD_ThursdayStartTime;
                    modelOCD.OCD_ThursdayEndTime = model.OCD_ThursdayEndTime;
                    modelOCD.OCD_FridayStartTime = model.OCD_FridayStartTime;
                    modelOCD.OCD_FridayEndTime = model.OCD_FridayEndTime;
                    modelOCD.OCD_SaturdayStartTime = model.OCD_SaturdayStartTime;
                    modelOCD.OCD_SaturdayEndTime = model.OCD_SaturdayEndTime;
                    modelOCD.OCD_SundayStartTime = model.OCD_SundayStartTime;
                    modelOCD.OCD_SundayEndTime = model.OCD_SundayEndTime;                       
                    modelOCD.OCD_UpdatedBy = model.OCD_UpdatedBy;
                    var reas = ocdRepo.UpdateOnlineConsultaionDetails(modelOCD);
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

        public tblOnlineConsultaionDetail GetOnlineConsultaionDetailByID(int modelId)
        {
            if (modelId > 0)
                return ocdRepo.GetOnlineConsultaionDetailsByID(modelId);
            return null;
        }

        public IEnumerable<tblOnlineConsultaionDetail> GetDoctorAllOnlineConsultaionDetailsByID(int modelId)
        {
            if (modelId > 0)
                return ocdRepo.GetDoctorAllOnlineConsultaionDetailsByID(modelId);
            return null;
        }

        public bool InActiveOnlineConsultaionDetail(ValidateDoctorOnlineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    tblOnlineConsultaionDetail doctorService = new tblOnlineConsultaionDetail()
                    {
                        OCD_ID = model.OCD_ID,
                        OCD_UpdatedBy = model.OCD_UpdatedBy,                        
                    };
                    var reas = ocdRepo.InActiveOnlineConsultaionDetails(doctorService);
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

        public bool ReActiveOnlineConsultaionDetail(ValidateDoctorOnlineConsultaionDetails model)
        {
            try
            {
                if (model != null)
                {
                    tblOnlineConsultaionDetail doctorService = new tblOnlineConsultaionDetail()
                    {
                        OCD_ID = model.OCD_ID,
                        OCD_UpdatedBy = model.OCD_UpdatedBy,
                    };
                    var reas = ocdRepo.ReActiveOnlineConsultaionDetails(doctorService);
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
