using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
namespace Capstone.DAO.Interfaces
{
    public interface ILandmarksDao
    {
        Landmark GetLandmark(string landmarkName);
        List<Landmark> GetLandmarks();

    }
}
