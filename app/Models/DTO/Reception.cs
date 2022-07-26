using System;
using System.Runtime.Serialization;

namespace app.Models.DTO
{
    [Serializable]
    public class Reception
    {
        public Reception()
        {
        }

        public Reception(string id, DateTime date, string diagnosisId, string patientId)
        {
            Id = id;
            Date = date;
            DiagnosisId = diagnosisId;
            PatientId = patientId;
        }

        public Reception(ReceptionHttp reception) : this(
            reception.Id,
            DateTime.Parse(reception.Date),
            reception.DiagnosisId,
            reception.PatientId
        )
        {
        }

        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string DiagnosisId { get; set; }
        
        public string PatientId { get; set; }
    }
}