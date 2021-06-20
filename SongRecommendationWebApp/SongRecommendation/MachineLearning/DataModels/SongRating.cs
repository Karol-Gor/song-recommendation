using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace SongRecommendation.MachineLearning.DataModels
{
    public class SongRating
    {
        [LoadColumn(1)]
        public int UserId;

        [LoadColumn(2)]
        public int SongId;

        [LoadColumn(3)]
        public float Label;
    }
}
