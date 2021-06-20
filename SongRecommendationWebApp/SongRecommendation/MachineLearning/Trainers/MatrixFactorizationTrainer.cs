using Microsoft.ML;
using Microsoft.ML.Trainers.Recommender;
using SongRecommendation.MachineLearning.Common;
namespace SongRecommendation.MachineLearning.Trainers
{
    public sealed  class MatrixFactorizationTrainer : TrainerBase
    {
        public MatrixFactorizationTrainer(int numberOfIterations,
                      int approximationRank,
                      double learningRate) : base()
        {
            Name = $"Matrix Factorization {numberOfIterations}-{approximationRank}";

            _model = MlContext.Recommendation().Trainers.MatrixFactorization(
                                                      labelColumnName: "Label",
                                                      matrixColumnIndexColumnName: "UserIdEncoded",
                                                      matrixRowIndexColumnName: "SongIdEncoded",
                                                      approximationRank: approximationRank,
                                                      learningRate: learningRate,
                                                      numberOfIterations: numberOfIterations);
        }
    }
}
