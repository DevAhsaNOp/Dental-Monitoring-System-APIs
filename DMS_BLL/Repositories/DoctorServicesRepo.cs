using System;
using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;
using System.Collections.Generic;

namespace DMS_BLL.Repositories
{
    public class DoctorServicesRepo
    {
        private DoctorServicesDb servicesRepo;

        public DoctorServicesRepo()
        {
            servicesRepo = new DoctorServicesDb();
        }

        public bool InsertDoctorServices(ValidateDoctorServices model)
        {
            try
            {
                if (model != null)
                {
                    bool reas = false;
                    foreach (var ServicesID in model.DS_ServicesID)
                    {
                        tblDoctorService doctorService = new tblDoctorService()
                        {
                            DS_DoctorID = model.DS_DoctorID,
                            DS_ServicesID = ServicesID,
                            DS_CreatedBy = model.DS_CreatedBy,
                        };
                        reas = servicesRepo.InsertDoctorServices(doctorService);
                    }
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

        public tblDoctorService GetDoctorServicesByID(int modelId)
        {
            if (modelId > 0)
                return servicesRepo.GetDoctorServicesByID(modelId);
            return null;
        }

        public IEnumerable<tblDoctorService> GetAllDoctorServicesByID(int modelId)
        {
            if (modelId > 0)
                return servicesRepo.GetAllDoctorServicesByID(modelId);
            return null;
        }

        public IEnumerable<tblService> GetAllDoctorServices()
        {
            return servicesRepo.GetAllDoctorServices();
        }

        public bool InActiveDoctorServices(ValidateDoctorServices model)
        {
            try
            {
                if (model != null)
                {
                    tblDoctorService doctorService = new tblDoctorService()
                    {
                        DS_ID = model.DS_ID,
                        DS_UpdatedBy = model.DS_UpdatedBy,
                    };
                    var reas = servicesRepo.InActiveDoctorServices(doctorService);
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

        public bool ReActiveDoctorServices(ValidateDoctorServices model)
        {
            try
            {
                if (model != null)
                {
                    tblDoctorService doctorService = new tblDoctorService()
                    {
                        DS_ID = model.DS_ID,
                        DS_UpdatedBy = model.DS_UpdatedBy,
                    };
                    var reas = servicesRepo.ReActiveDoctorServices(doctorService);
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
