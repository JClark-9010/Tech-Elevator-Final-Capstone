using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.Interfaces
{
    public interface IReviewDao
    {
        List<Review> GetReviews(int landmarkId);
        Review GetReview(int reviewId);
        Review AddReview(Review review);
    }
}
