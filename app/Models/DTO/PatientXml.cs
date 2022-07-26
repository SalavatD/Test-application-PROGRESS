using System;
using System.Collections.Generic;

namespace app.Models.DTO
{
    [Serializable]
    public class PatientXml
    {
        public PatientXml()
        {
        }

        public PatientXml(Patient patient, List<Reception> receptions)
        {
            this.Patient = patient;
            this.Receptions = receptions;
        }

        public Patient Patient { get; set; }
        public List<Reception> Receptions { get; set; }
    }
}