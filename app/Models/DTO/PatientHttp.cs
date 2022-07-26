using System;

namespace app.Models.DTO
{
    public class PatientHttp
    {
        public string Id { get; set; }

        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Birthdate { get; set; }

        public string Phone { get; set; }
    }
}