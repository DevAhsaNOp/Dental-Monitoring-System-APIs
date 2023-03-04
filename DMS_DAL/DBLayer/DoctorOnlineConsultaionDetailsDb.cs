using System;
using DMS_BOL;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace DMS_DAL.DBLayer
{
    public class DoctorOnlineConsultaionDetailsDb
    {
        private dentalDBEntities _context;

        public DoctorOnlineConsultaionDetailsDb()
        {
            _context = new dentalDBEntities();
        }

        public bool InsertOnlineConsultaionDetails(tblOnlineConsultaionDetail model)
        {
            try
            {
                model.OCD_IsActive = true;
                model.OCD_CreatedOn = DateTime.Now;
                model.OCD_UpdatedOn = null;
                model.OCD_UpdatedBy = null;
                model.OCD_IsArchive = false;
                _context.tblOnlineConsultaionDetails.Add(model);
                Save();
                if (model.OCD_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateOnlineConsultaionDetails(tblOnlineConsultaionDetail model)
        {
            try
            {
                model.OCD_IsActive = true;
                model.OCD_CreatedOn = GetOnlineConsultaionDetailsByID(model.OCD_ID).OCD_CreatedOn;
                model.OCD_CreatedBy = GetOnlineConsultaionDetailsByID(model.OCD_ID).OCD_CreatedBy;
                model.OCD_UpdatedOn = DateTime.Now;
                model.OCD_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.OCD_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblOnlineConsultaionDetail GetOnlineConsultaionDetailsByID(int modelId)
        {
            return _context.tblOnlineConsultaionDetails.Find(modelId);
        }
        
        public IEnumerable<tblOnlineConsultaionDetail> GetDoctorAllOnlineConsultaionDetailsByID(int modelId)
        {
            return _context.tblOnlineConsultaionDetails.Where(x => x.OCD_DoctorID == modelId).ToList();
        }

        public bool InActiveOnlineConsultaionDetails(tblOnlineConsultaionDetail model)
        {
            try
            {
                model = GetOnlineConsultaionDetailsByID(model.OCD_ID);
                model.OCD_IsActive = false;
                model.OCD_UpdatedOn = DateTime.Now;
                model.OCD_IsArchive = true;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.OCD_ID > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ReActiveOnlineConsultaionDetails(tblOnlineConsultaionDetail model)
        {
            try
            {
                model = GetOnlineConsultaionDetailsByID(model.OCD_ID);
                model.OCD_IsActive = true;
                model.OCD_UpdatedOn = DateTime.Now;
                model.OCD_IsArchive = false;
                _context.Entry(model).State = EntityState.Modified;
                Save();
                if (model.OCD_ID > 0)
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
