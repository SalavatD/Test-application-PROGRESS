using System;
using System.Collections.Generic;
using System.Data;
using app.Models.DTO;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace app.Models
{
    public class PatientsModel : AppModel
    {
        public PatientsModel(IConfiguration configuration) : base(configuration)
        {
        }

        public void AppendPatient(Patient patient)
        {
            string query = "INSERT INTO Patients VALUES (" +
                           $"'{patient.Id}'," +
                           $"'{patient.Lastname}'," +
                           $"'{patient.Firstname}'," +
                           $"'{patient.Middlename}'," +
                           $"'{patient.Birthdate.ToShortDateString()}'," +
                           $"'{patient.Phone}'" +
                           ")";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public List<Patient> GetPatients()
        {
            var patients = new List<Patient>();
            string query = "SELECT * FROM Patients";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                patients.Add(new Patient(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    DateOnly.FromDateTime(reader.GetDateTime(4)),
                    reader.GetString(5)
                ));
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return patients;
        }

        public Patient GetPatientInfo(string patientId)
        {
            string query = $"SELECT * FROM Patients WHERE id = '{patientId}'";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            var patient = new Patient(
                reader.GetString(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                DateOnly.FromDateTime(reader.GetDateTime(4)),
                reader.GetString(5)
            );
            reader.Close();
            command.Dispose();
            connection.Close();
            return patient;
        }
    }
}