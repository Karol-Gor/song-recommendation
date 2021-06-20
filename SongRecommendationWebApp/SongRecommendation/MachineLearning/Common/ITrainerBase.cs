﻿using Microsoft.ML.Data;


namespace SongRecommendation.MachineLearning.Common
{

        public interface ITrainerBase
        {
            string Name { get; }
            void Fit(string trainingFileName);
            BinaryClassificationMetrics Evaluate();
            void Save();
        }
 
}
