using System;

namespace app.Models.DTO
{
    [Serializable]
    public class Patient
    {
        public Patient()
        {
        }

        public Patient(string id, string lastname, string firstname, string middlename, DateOnly birthdate, string phone)
        {
            Id = id;
            Lastname = lastname;
            Firstname = firstname;
            Middlename = middlename;
            Birthdate = birthdate;
            Phone = phone;
        }

        public Patient(PatientHttp patient) : this(
            patient.Id,
            patient.Lastname,
            patient.Firstname,
            patient.Middlename,
            DateOnly.Parse(patient.Birthdate),
            patient.Phone
        )
        {
        }
        
        public string Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public DateOnly Birthdate { get; set; }

        public string Phone { get; set; }
    }
}