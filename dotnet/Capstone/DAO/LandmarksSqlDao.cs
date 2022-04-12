using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;


namespace Capstone.DAO
{
    public class LandmarksSqlDao : ILandmarksDao
    {
        private readonly string connectionString;

        public LandmarksSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        private Landmark GetLandmarkFromReader(SqlDataReader reader)
        {
            Landmark l = new Landmark()
            {
                LandmarkId = Convert.ToInt32(reader["landmark_id"]),
                LandmarkName = Convert.ToString(reader["landmark_name"]),
                Zipcode = Convert.ToInt32(reader["zipcode"]),
                Description = Convert.ToString(reader["description"]),

            };

            return l;
        }
        public List<Landmark> GetLandmarks()
        {
            List<Landmark> landmarks = new List<Landmark>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM landmarks", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Landmark landmark = GetLandmarkFromReader(reader);
                        landmarks.Add(landmark);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return landmarks;


        }
        public Landmark GetLandmark(int landmarkId)
        {
            Landmark landmark = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT landmark_id, landmark_name, zipcode, description FROM landmarks WHERE landmark_id = @landmarkId", conn);
                    cmd.Parameters.AddWithValue("@landmarkId", landmarkId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        landmark = GetLandmarkFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return landmark;
        }


        public Landmark AddLandmark(Landmark landmark)
        {
            Landmark addedlandmark = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO landmarks (landmark_name, zipcode, description) VALUES (@landmark_name, @zipcode, @description)", conn);
                cmd.Parameters.AddWithValue("@landmark_name", landmark.LandmarkName);
                cmd.Parameters.AddWithValue("@zipcode", landmark.Zipcode);
                cmd.Parameters.AddWithValue("@description", landmark.Description);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    addedlandmark = landmark;
                }

                return addedlandmark;
            }
        }
    }
}


