using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VideoShop.DataAccess;
using VideoShop.Models;

namespace Owasp.Data
{
    public class DbUtils
    {
        public static PatientList SafeFetchAzureData(string name)
        {
            PatientList patientList = new PatientList();

            var conn = new SqlConnection(
                "Server=tcp:shanetestsql.database.windows.net,1433;Initial Catalog=owasp;Persist Security Info=False;User ID=owasp;Password=hammer-abut-cathode-fodder3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            const string query = "SELECT * FROM Patients WHERE Name=@Criteria";
            using (var sqlCommand = new SqlCommand(query, conn))
            {
                sqlCommand.Parameters.Add("@Criteria", SqlDbType.NVarChar).Value = name;
                conn.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Patient p = new Patient();
                    p.PatientId = reader.GetInt32(0);
                    p.PatientName = reader.GetString(1);
                    p.Illness = reader.GetString(2);
                    p.IsTerminal = reader.GetBoolean(3);
                    patientList.Patients.Add(p);
                }
            }

            return patientList;
        }

        public static PatientList FetchAzureData(string name)
        {
            PatientList patientList = new PatientList();

            var conn = new SqlConnection(
                "Server=tcp:shanetestsql.database.windows.net,1433;Initial Catalog=owasp;Persist Security Info=False;User ID=owasp;Password=hammer-abut-cathode-fodder3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            string query = "SELECT * FROM Patients WHERE Name='" + name + "'";
            using (var sqlCommand = new SqlCommand(query, conn))
            {
                conn.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Patient p = new Patient();
                    p.PatientId = reader.GetInt32(0);
                    p.PatientName = reader.GetString(1);
                    p.Illness = reader.GetString(2);
                    p.IsTerminal = reader.GetBoolean(3);
                    patientList.Patients.Add(p);
                }

            }

            return patientList;
        }

        public static PatientList SafeFetchData(string name)
        { 
            PatientContext db = new PatientContext();
            PatientList patientList = new PatientList();

            patientList.Patients = db.Patients.Where(p => p.PatientName == name && (!p.IsSensitive)).ToList();
            return patientList;
        }


        

        public static PatientList FetchData(string name)
        {
            PatientContext db = new PatientContext();

            PatientList patientList = new PatientList();
            patientList.Searchname = name;

            string query = "SELECT * FROM Patient WHERE PatientName='" + name + "' and IsSensitive = 0" ;

            //db.Database.ExecuteSqlCommand(query);

            patientList.Patients = db.Patients
                        .SqlQuery(query)
                        .ToList<Patient>();
            return patientList;
        }
    }
}
