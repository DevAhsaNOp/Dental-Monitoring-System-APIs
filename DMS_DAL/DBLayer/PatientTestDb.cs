using System;
using DMS_BOL;
using System.Linq;
using DMS_BOL.Validation_Classes;
using System.Collections.Generic;
using System.Security.Principal;
using CloudinaryDotNet;

namespace DMS_DAL.DBLayer
{
    public class PatientTestDb
    {
        private dmswebapp_dentalDBEntities _context;
        private AddressDb _db;
        public PatientTestDb()
        {
            _context = new dmswebapp_dentalDBEntities();
            _db = new AddressDb();
        }

        public int InsertPatientTest(tblPatientTest model)
        {
            try
            {
                if (model != null)
                {
                    model.PT_IsActive = true;
                    model.PT_IsArchive = false;
                    model.PT_Datetime = DateTime.Now;
                    _context.tblPatientTests.Add(model);
                    Save();
                    return model.PT_ID;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePatientTest(tblPatientTest model)
        {
            try
            {
                if (model != null)
                {
                    _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    Save();
                    return model.PT_ID;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ValidatePatientTest GetPatientWantTestById(int PatientId)
        {
            try
            {
                if (PatientId > 0)
                {
                    var PatientTest = _context.tblPatientTests.Where(x => x.PT_PatientID == PatientId).Select(a => new ValidatePatientTest()
                    {
                        PT_ID = a.PT_ID,
                        PT_Datetime = a.PT_Datetime,
                        PT_Images = a.PT_Images,
                        PT_IsActive = a.PT_IsActive,
                        PT_PatientID = a.PT_PatientID,
                        PT_IsArchive = a.PT_IsArchive,
                        tblPatient = a.tblPatient,
                    }).OrderByDescending(x => x.PT_Datetime).FirstOrDefault();
                    if (PatientTest != null)
                    {
                        var cloudinary = new Cloudinary(new Account("dg5esqkeb", "654286619656251", "7-JkBR5t_EU8lN3ArIdvsZ1txCw"));
                        var assetFolderResult = cloudinary.Search().Expression("folder:" + PatientTest.PT_Images).SortBy("public_id", "desc").Execute();
                        if (assetFolderResult.StatusCode == System.Net.HttpStatusCode.OK && assetFolderResult.TotalCount > 0)
                        {
                            var reasImages = assetFolderResult.Resources.Select(x => x.SecureUrl);
                            PatientTest.PatientAddress = _db.GetAddressById(PatientTest.tblPatient.P_AddressID.Value);
                            PatientTest.Images = reasImages.ToList();
                            return PatientTest;
                        }
                        else
                            return null;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tblPatientTest GetPatientTestByID(int ID)
        {
            if (ID > 0)
                return _context.tblPatientTests.Find(ID);
            else
                return null;
        }

        public ValidatePatientTest GetPatientTestById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var PatientTest = _context.tblPatientTests.Where(x => x.PT_ID == id).Select(a => new ValidatePatientTest()
                    {
                        PT_ID = a.PT_ID,
                        PT_PatientID = a.PT_PatientID,
                        PT_Datetime = a.PT_Datetime,
                        PT_Images = a.PT_Images,
                        PT_IdentifiedDiseases = a.PT_IdentifiedDiseases,
                        PT_Pdf = a.PT_Pdf,
                        PT_Remarks = a.PT_Remarks,
                        PT_IsActive = a.PT_IsActive,
                        PT_IsArchive = a.PT_IsArchive,
                        tblPatient = a.tblPatient
                    }).FirstOrDefault();
                    if (PatientTest != null)
                        return PatientTest;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ValidatePatientTest> GetPatientAllTest()
        {
            try
            {
                var PatientTest = _context.tblPatientTests.Select(a => new ValidatePatientTest()
                {
                    PT_ID = a.PT_ID,
                    PT_PatientID = a.PT_PatientID,
                    PT_Datetime = a.PT_Datetime,
                    PT_Images = a.PT_Images,
                    PT_IdentifiedDiseases = a.PT_IdentifiedDiseases,
                    PT_Pdf = a.PT_Pdf,
                    PT_Remarks = a.PT_Remarks,
                    PT_IsActive = a.PT_IsActive,
                    PT_IsArchive = a.PT_IsArchive,
                    tblPatient = a.tblPatient
                }).ToList();
                if (PatientTest != null && PatientTest.Count > 0)
                    return PatientTest;
                else
                    return null;
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
