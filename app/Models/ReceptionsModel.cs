using System;
using System.Collections;
using System.Collections.Generic;
using app.Models.DTO;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace app.Models
{
    public class ReceptionsModel : AppModel
    {
        private IConfiguration _configuration;

        public ReceptionsModel(IConfiguration configuration) : base(configuration)
        {
        }

        public void AppendReception(Reception reception)
        {
            string query = "INSERT INTO Receptions VALUES (" +
                           $"'{reception.Id}'," +
                           $"'{reception.Date}'," +
                           $"'{reception.DiagnosisId}'," +
                           $"'{reception.PatientId}'" +
                           ")";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public List<Reception> GetReceptions()
        {
            var receptions = new List<Reception>();
            string query = "SELECT * FROM Receptions";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                receptions.Add(new Reception(
                    reader.GetString(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    reader.GetString(3)
                ));
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return receptions;
        }

        public List<Reception> GetReceptionsByPatientId(string patientId)
        {
            var receptions = new List<Reception>();
            string query = $"SELECT * FROM Receptions WHERE patient_id = '{patientId}'";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                receptions.Add(new Reception(
                    reader.GetString(0),
                    reader.GetDateTime(1),
                    reader.GetString(2),
                    reader.GetString(3)
                ));
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return receptions;
        }
    }
}