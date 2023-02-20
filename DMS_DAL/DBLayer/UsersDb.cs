using DMS_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DMS_DAL.DBLayer
{
    public class UsersDb
    {
        private dentalDBEntities _context;

        public UsersDb()
        {
            _context = new dentalDBEntities();
        }

        public bool InsertPatient(tblPatient model)
        {
            try
            {
                model.P_IsActive = true;
                model.P_CreatedOn = DateTime.Now;
                model.P_UpdatedOn = null;
                model.P_UpdatedBy = null;
                model.P_IsArchive= false;
                model.P_RoleID = 4;
                _context.tblPatients.Add(model);
                Save();
                if (model.P_ID > 0)
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
