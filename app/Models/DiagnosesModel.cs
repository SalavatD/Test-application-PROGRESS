using System.Collections.Generic;
using app.Models.DTO;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace app.Models
{
    public class DiagnosesModel : AppModel
    {
        public DiagnosesModel(IConfiguration configuration) : base(configuration)
        {
        }

        public List<Diagnosis> GetDiagnoses()
        {
            var diagnoses = new List<Diagnosis>();
            string query = "SELECT * FROM Diagnoses";
            NpgsqlConnection connection = new(Configuration.GetConnectionString("AppDbPg"));
            connection.Open();
            NpgsqlCommand command = new(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                diagnoses.Add(new Diagnosis(
                    reader.GetString(0),
                    reader.GetString(1)
                ));
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return diagnoses;
        }
    }
}