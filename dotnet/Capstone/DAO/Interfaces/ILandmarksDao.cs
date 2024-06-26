﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
namespace Capstone.DAO.Interfaces
{
    public interface ILandmarksDao
    {
        Landmark GetLandmark(int landmarkId);
        List<Landmark> GetLandmarks();
        Landmark AddLandmark(Landmark landmark);
        bool UpdateLandmark(int itenAdd, int landmarkId);
    }
}
