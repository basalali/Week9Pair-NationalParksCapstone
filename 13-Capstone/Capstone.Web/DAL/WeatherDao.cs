using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherDao : IWeatherDao
    {
        string connectionString;

        string sql_GetWeather = "SELECT * FROM park WHERE parkCode = @parkCode; ";


        public WeatherDao(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<Weather> GetWeather(string parkCode)
        {
            List<Weather> weather = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql_GetWeather;
                    cmd.Parameters.AddWithValue("@parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        weather.Add(new Weather
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"]),
                        });

                    }

                }


            }
            catch (SqlException ex)
            {

                weather = new List<Weather>();

            }

            return weather;
        }


    }
}
