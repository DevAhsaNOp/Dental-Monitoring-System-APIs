using System;
using DMS_BOL;
using DMS_DAL.DBLayer;
using DMS_BOL.Validation_Classes;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Linq;

namespace DMS_BLL.Repositories
{
    public class PatientTestRepo
    {
        private PatientTestDb dbObj;

        public PatientTestRepo()
        {
            dbObj = new PatientTestDb();
        }

        public int InsertPatientTest(ValidatePatientTest model)
        {
            try
            {
                if (model != null)
                {
                    var patientTest = new tblPatientTest();
                    patientTest.PT_ID = model.PT_ID;
                    patientTest.PT_PatientID = model.PT_PatientID;
                    patientTest.PT_Images = model.PT_Images;
                    patientTest.PT_Pdf = model.PT_Pdf;
                    patientTest.PT_IdentifiedDiseases = model.PT_IdentifiedDiseases;
                    patientTest.PT_Remarks = model.PT_Remarks;
                    var patientTestId = dbObj.InsertPatientTest(patientTest);
                    if (patientTestId > 0)
                        return patientTestId;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdatePatientTest(ValidatePatientTest model)
        {
            try
            {
                if (model != null && model.PT_ID > 0)
                {
                    var patientTest = dbObj.GetPatientTestByID(model.PT_ID);
                    if (patientTest != null)
                    {
                        patientTest.PT_ID = model.PT_ID;
                        patientTest.PT_PatientID = model.PT_PatientID;
                        patientTest.PT_Datetime = model.PT_Datetime;
                        patientTest.PT_Images = model.PT_Images;
                        patientTest.PT_Pdf = model.PT_Pdf;
                        patientTest.PT_IdentifiedDiseases = model.PT_IdentifiedDiseases;
                        patientTest.PT_Remarks = model.PT_Remarks;
                        patientTest.PT_IsActive = model.PT_IsActive;
                        patientTest.PT_IsArchive = model.PT_IsArchive;
                        var patientTestId = dbObj.UpdatePatientTest(patientTest);
                        if (patientTestId > 0)
                            return patientTestId;
                        else
                            return 0;
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ValidatePatientTest GetPatientTestById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var patientTest = dbObj.GetPatientTestById(id);
                    if (patientTest != null)
                        return patientTest;
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
        
        public ValidatePatientTest GetPatientWantTestById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var patientTest = dbObj.GetPatientWantTestById(id);
                    if (patientTest != null)
                        return patientTest;
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
                var PatientTest = dbObj.GetPatientAllTest();
                if (PatientTest != null && PatientTest.Count() > 0)
                    return PatientTest;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
