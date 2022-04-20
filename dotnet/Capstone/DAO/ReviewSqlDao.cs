using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.DAO.Interfaces;
using Capstone.Models;

namespace Capstone.DAO
{
    public class ReviewSqlDao : IReviewDao
    {
        private readonly string connectionString;

        public ReviewSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        private string reviewSqlGet = "SELECT * FROM reviews WHERE landmark_id = @landmarkId";
        private string reviewSqlAdd = "INSERT INTO reviews (landmark_id, review_description) VALUES (@landmarkId, @userReview)";

        public List<Review> GetReviews(int landmarkId)
        {
            List<Review> reviews = new List<Review>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(reviewSqlGet, conn);
                    cmd.Parameters.AddWithValue("@landmarkId", landmarkId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Review review = GetReviewFromReader(reader);
                        reviews.Add(review);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return reviews;
        }

        public Review AddReview(Review review)
        {
            Review addedReview = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(reviewSqlAdd, conn);
                cmd.Parameters.AddWithValue("@landmarkId", review.LandmarkId);
                cmd.Parameters.AddWithValue("@userReview", review.Description);
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    addedReview = review;
                }
                return addedReview;
            }
        }
        public Review GetReview(int reviewId)
        {
            Review review = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM reviews WHERE review_id = @reviewId", conn);
                    cmd.Parameters.AddWithValue("@review", reviewId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        review = GetReviewFromReader(reader);
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }
            return review;
        }

        private Review GetReviewFromReader(SqlDataReader reader)
        {
            Review r = new Review()
            {
                ReviewId = Convert.ToInt32(reader["review_id"]),
                LandmarkId = Convert.ToInt32(reader["landmark_id"]),
                Description = Convert.ToString(reader["review_description"]),
            };
            return r;
        }
    }
}
