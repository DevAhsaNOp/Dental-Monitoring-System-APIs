using System.Collections.Generic;

namespace DMS_BOL.Validation_Classes
{
    public class ValidatePatient : ValidateUsersProfiles
    {
        public virtual ICollection<tblAppointment> tblAppointments { get; set; }
        public virtual ICollection<tblDiagnostic> tblDiagnostics { get; set; }
        public virtual ICollection<tblDoctorReview> tblDoctorReviews { get; set; }
    }
}
