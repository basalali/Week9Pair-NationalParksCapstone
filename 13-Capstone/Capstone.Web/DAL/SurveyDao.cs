using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDao : ISurveyDao
    {

        private readonly string connectionString;

        public SurveyDao(string connectionString)
        {

            this.connectionString = connectionString;
        }

        string sql_ParkCode = "SELECT * from park; ";

        string sql_SaveSurvey = "Insert into survey_result(parkCode, emailAddress, state, activityLevel) Values(@parkCode, @email, @state, @activitylevel); ";

        string sql_TopResult = "select Count (sr.parkCode) results, sr.parkCode, park.parkName from survey_result sr JOIN park ON park.parkCode = sr.parkCode Group by park.parkName, sr.parkCode HAVING Count(sr.parkCode) >= 1 order by Count (sr.parkCode) desc ; ";

        public IList<Survey> GetTopSurveys()
        {
            IList<Survey> surveys = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql_TopResult, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = new Survey();

                        survey.Results = Convert.ToString(reader["results"]);
                        survey.ParkCode = Convert.ToString(reader["parkCode"]);
                        survey.ParkName = Convert.ToString(reader["parkName"]);

                        surveys.Add(survey);

                    }

                }
            }


            catch (SqlException ex)
            {

                surveys = new List<Survey>();

            }
            return surveys;

        }

        public bool SaveNewSurvey(Survey post)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();


                    SqlCommand cmd = new SqlCommand(sql_SaveSurvey, conn);
                    cmd.Parameters.AddWithValue(@"parkCode", post.ParkCode);
                    cmd.Parameters.AddWithValue(@"email", post.Email);
                    cmd.Parameters.AddWithValue(@"state", post.State);
                    cmd.Parameters.AddWithValue(@"activitylevel", post.ActivityLevel);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        result = true;
                    }

                }

            }

            catch (SqlException ex)
            {

                throw ex;
            }

            return result;
        }

        public IDictionary<string, string> GetParkNames()
        {
            IDictionary<string, string> names = new Dictionary<string, string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = sql_ParkCode;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    names.Add(Convert.ToString(reader["parkCode"]), Convert.ToString(reader["parkName"]));
                }


            }

            return names;

        }

    }
}


