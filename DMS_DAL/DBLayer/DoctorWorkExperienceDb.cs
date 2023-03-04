using System;
using DMS_BOL;
using System.Data.Entity;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace DMS_DAL.DBLayer
{
    public class DoctorWorkExperienceDb
    {
        private dentalDBEntities _context;

        public DoctorWorkExperienceDb()
        {
            _context = new dentalDBEntities();
        }

        public bool InsertDoctorWorkExperiences(tblDoctorWorkExperience model)
        {
            try
            {
                model.WEX_IsActive = true;
                model.WEX_CreatedOn = DateTime.Now;
                model.WEX_UpdatedOn = null;
                model.WEX_UpdatedBy = null;
                model.WEX_IsArchive = false;
                _context.tblDoctorWorkExperiences.Add(model);
                Save();
                if (model.WEX_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateDoctorWorkExperiences(tblDoctorWorkExperience model)
        {
            try
            {
                model.WEX_IsActive = true;
                model.WEX_CreatedOn = GetDoctorWorkExperiencesByID(model.WEX_ID).WEX_CreatedOn;
                model.WEX_CreatedBy = GetDoctorWorkExperiencesByID(model.WEX_ID).WEX_CreatedBy;
                model.WEX_UpdatedOn = DateTime.Now;
                model.WEX_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.WEX_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<tblDoctorWorkExperience> GetDoctorAllWorkExperiencesByID(int modelId)
        {
            return _context.tblDoctorWorkExperiences.Where(x => x.WEX_DoctorID == modelId).ToList();
        }

        public tblDoctorWorkExperience GetDoctorWorkExperiencesByID(int modelId)
        {
            return _context.tblDoctorWorkExperiences.Find(modelId);
        }

        public bool InActiveDoctorWorkExperiences(tblDoctorWorkExperience model)
        {
            try
            {
                model = GetDoctorWorkExperiencesByID(model.WEX_ID);
                model.WEX_IsActive = false;
                model.WEX_UpdatedOn = DateTime.Now;
                model.WEX_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.WEX_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveDoctorWorkExperiences(tblDoctorWorkExperience model)
        {
            try
            {
                model = GetDoctorWorkExperiencesByID(model.WEX_ID);
                model.WEX_IsActive = true;
                model.WEX_UpdatedOn = DateTime.Now;
                model.WEX_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.WEX_ID > 0)
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
