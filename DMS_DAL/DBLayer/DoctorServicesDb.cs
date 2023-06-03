using System;
using DMS_BOL;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace DMS_DAL.DBLayer
{
    public class DoctorServicesDb
    {
        private dmswebapp_dentalDBEntities _context;

        public DoctorServicesDb()
        {
            _context = new dmswebapp_dentalDBEntities();
        }

        public bool InsertDoctorServices(tblDoctorService model)
        {
            try
            {
                model.DS_IsActive = true;
                model.DS_CreatedOn = DateTime.Now;
                model.DS_UpdatedOn = null;
                model.DS_UpdatedBy = null;
                model.DS_IsArchive = false;
                _context.tblDoctorServices.Add(model);
                Save();
                if (model.DS_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDoctorServices(tblDoctorService model)
        {
            try
            {
                model.DS_IsActive = true;
                model.DS_CreatedOn = GetDoctorServicesByID(model.DS_ID).DS_CreatedOn;
                model.DS_CreatedBy = GetDoctorServicesByID(model.DS_ID).DS_CreatedBy;
                model.DS_UpdatedOn = DateTime.Now;
                model.DS_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.DS_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblDoctorService GetDoctorServicesByID(int modelId)
        {
            return _context.tblDoctorServices.Find(modelId);
        }

        public IEnumerable<tblService> GetAllDoctorServices()
        {
            return _context.tblServices.ToList();
        }
        
        public IEnumerable<tblDoctorService> GetAllDoctorServicesByID(int modelId)
        {
            return _context.tblDoctorServices.Where(x => x.DS_DoctorID == modelId).ToList();
        }

        public bool InActiveDoctorServices(tblDoctorService model)
        {
            try
            {
                model = GetDoctorServicesByID(model.DS_ID);
                model.DS_IsActive = false;
                model.DS_UpdatedOn = DateTime.Now;
                model.DS_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.DS_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveDoctorServices(tblDoctorService model)
        {
            try
            {
                model = GetDoctorServicesByID(model.DS_ID);
                model.DS_IsActive = true;
                model.DS_UpdatedOn = DateTime.Now;
                model.DS_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.DS_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
