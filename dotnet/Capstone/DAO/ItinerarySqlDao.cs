﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ItinerarySqlDao : IItineraryDAO
    {
        private readonly string connectionString;

        public ItinerarySqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public string sqlGetItineraries = "SELECT * FROM itineraries WHERE user_id = @userId";//tie this to token

        public string sqlAddItinerary = "INSERT INTO itineraries (user_id, itinerary_name) VALUES (@userId, @itineraryName)";

        public string sqlDeleteItinerary = "DELETE FROM itineraries WHERE itinerary_id = @itineraryId";

        public string sqlDeleteLandmarkFromItinerary = "DELETE FROM itineraries_landmarks_user WHERE landmark_id = @landmarkId AND itinerary_id = @itineraryId";

        public string sqlGetItineraryDetails = "SELECT landmark_name, landmark_lat, landmark_lng, description, landmark_image, itineraries_landmarks_user.itinerary_id," +
                                               " itineraries_landmarks_user.landmark_id, itineraries_landmarks_user.user_id FROM landmarks JOIN itineraries_landmarks_user" +
                                               " ON itineraries_landmarks_user.landmark_id = landmarks.landmark_id WHERE itineraries_landmarks_user.itinerary_id = @itineraryId";

        public string sqlAddLandmarkToItinerary = "INSERT INTO itineraries_landmarks_user (itinerary_id, landmark_id, user_id) VALUES (@itineraryId, @landmarkId, @userId)";

        public string sqlGetItinerary = "SELECT * FROM itinerary WHERE itinerary_id = @itineraryId";


        public List<Itinerary> RetrieveItineraries(int userId)
        {
            List<Itinerary> list = new List<Itinerary>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetItineraries, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Itinerary itinerary = new Itinerary();
                    itinerary.ItineraryId = Convert.ToInt32(reader["itinerary_id"]);
                    itinerary.UserId = Convert.ToInt32(reader["user_id"]);
                    itinerary.ItineraryName = Convert.ToString(reader["itinerary_name"]);

                    list.Add(itinerary);
                }
            }
            return list;
        }

        public bool AddItinerary(Itinerary itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddItinerary, conn);
                    cmd.Parameters.AddWithValue("@userId", itinerary.UserId);
                    cmd.Parameters.AddWithValue("@itineraryName", itinerary.ItineraryName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteItinerary(int itineraryId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteItinerary, conn);
                    cmd.Parameters.AddWithValue("@itineraryId", itineraryId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteLandmarkFromItinerary(ItineraryDetails i)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteLandmarkFromItinerary, conn);
                    cmd.Parameters.AddWithValue("@landmarkId", i.LandmarkId);
                    cmd.Parameters.AddWithValue("@itineraryId", i.ItineraryId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<ItineraryDetails> GetItineraryDetails(int itineraryId)
        {
            List<ItineraryDetails> i = new List<ItineraryDetails>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetItineraryDetails, conn);
                cmd.Parameters.AddWithValue("@itineraryId", itineraryId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ItineraryDetails details = new ItineraryDetails();
                    details.LandmarkName = Convert.ToString(reader["landmark_name"]);
                    details.LandmarkLat = Convert.ToString(reader["landmark_lat"]);
                    details.LandmarkLng = Convert.ToString(reader["landmark_lng"]);
                    details.Description = Convert.ToString(reader["description"]);
                    details.LandmarkImage = Convert.ToString(reader["landmark_image"]);
                    details.ItineraryId = Convert.ToInt32(reader["itinerary_id"]);
                    details.LandmarkId = Convert.ToInt32(reader["landmark_id"]);
                    details.UserId = Convert.ToInt32(reader["user_id"]);
                    i.Add(details);
                }
            }
            return i;
        }

        public Itinerary GetItinerary(int itineraryId)
        {
            Itinerary itinerary = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM itineraries WHERE itinerary_id = @itineraryId", conn);
                    cmd.Parameters.AddWithValue("@landmarkId", itineraryId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        itinerary = GetItineraryFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return itinerary;
        }

        public bool AddLandmarkToItinerary(ItineraryDetails i)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddLandmarkToItinerary, conn);
                    cmd.Parameters.AddWithValue("@itineraryId", i.ItineraryId);
                    cmd.Parameters.AddWithValue("@landmarkId", i.LandmarkId);
                    cmd.Parameters.AddWithValue("@userId", i.UserId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private Itinerary GetItineraryFromReader(SqlDataReader reader)
        {
            Itinerary i = new Itinerary()
            {
                ItineraryId = Convert.ToInt32(reader["itinerary_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                ItineraryName = Convert.ToString(reader["itinerary_name"]),
            };

            return i;
        }

        public List <Itinerary> GetItineraries()
        {
            List <Itinerary> itineraries = new List<Itinerary>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM itineraries", conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Itinerary itinerary = GetItineraryFromReader(reader);
                        itineraries.Add(itinerary);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return itineraries;
        }


    }
}
