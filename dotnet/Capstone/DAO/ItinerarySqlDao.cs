using System;
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

        public string sqlEditItinerary = "UPDATE itineraries SET itinerary_name = @name, starting_address = @address, locations = @locations WHERE id = @id";

        public string sqlGetItineraryDetails = "SELECT * FROM landmarks JOIN itineraries_landmarks_user ON itineraries_landmarks_user.landmark_id = landmarks.landmark_id WHERE itineraries_landmarks_user.user_id = @userId";

        public string sqlAddLandmarkToItinerary = "INSERT INTO itineraries_landmarks_user (itinerary_id, landmark_id, user_id) VALUES (@itineraryId, @landmarkId, @userId)";

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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool EditItinerary(Itinerary itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlEditItinerary, conn);
                    cmd.Parameters.AddWithValue("@id", itinerary.ItineraryId);
                    cmd.Parameters.AddWithValue("@name", itinerary.ItineraryName);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<ItineraryDetails> GetItineraryDetails(int userId)
        {
            List<ItineraryDetails> i = new List<ItineraryDetails>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetItineraryDetails, conn);
                cmd.Parameters.AddWithValue("@userId", userId);


                SqlDataReader reader = cmd.ExecuteReader();

                ItineraryDetails details = new ItineraryDetails();
                while (reader.Read())
                {
                    details.LandmarkId = Convert.ToInt32(reader["landmark_id"]);
                    details.LandmarkName = Convert.ToString(reader["landmark_name"]);
                    details.LandmarkLat = Convert.ToString(reader["landmark_lat"]);
                    details.LandmarkLng = Convert.ToString(reader["landmark_lng"]);
                    details.Description = Convert.ToString(reader["description"]);
                    details.LandmarkImage = Convert.ToString(reader["landmark_image"]);
                    details.ItineraryId = Convert.ToInt32(reader["itinerary_id"]);
                    details.LandmarkIdDetail = Convert.ToInt32(reader["landmark_id"]);
                    details.UserId = Convert.ToInt32(reader["user_id"]);
                    i.Add(details);
                }
            }
            return i;
        }

        public bool AddLandmarkToItinerary(int itineraryId, int landmarkId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlAddLandmarkToItinerary, conn);
                    cmd.Parameters.AddWithValue("@itineraryId", itineraryId);
                    cmd.Parameters.AddWithValue("@landmarkId", landmarkId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
