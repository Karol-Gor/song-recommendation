﻿using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Trainers.Recommender;
using Microsoft.ML.Transforms;
using SongRecommendation.MachineLearning.DataModels;
using System;
using System.IO;

namespace SongRecommendation.MachineLearning.Common
{
    /// <summary>
    /// Base class for Trainers.
    /// This class exposes methods for training, evaluating and saving ML Models.
    /// </summary>
    public abstract class TrainerBase : ITrainerBase
    {
        public string Name { get; protected set; }

        protected static string ModelPath => Path.Combine(AppContext.BaseDirectory,
                             "recommender.mdl");

        protected readonly MLContext MlContext;

        protected DataOperationsCatalog.TrainTestData _dataSplit;
        protected ITrainerEstimator<MatrixFactorizationPredictionTransformer,
                                          MatrixFactorizationModelParameters> _model;
        protected ITransformer _trainedModel;

        protected TrainerBase()
        {
            MlContext = new MLContext(111);
        }

        /// <summary>
        /// Train model on defined data.
        /// </summary>
        /// <param name="trainingFileName"></param>
        public void Fit(string trainingFileName)
        {
            if (!File.Exists(trainingFileName))
            {
                throw new FileNotFoundException($"File {trainingFileName} doesn't exist.");
            }

            _dataSplit = LoadAndPrepareData(trainingFileName);
            var dataProcessPipeline = BuildDataProcessingPipeline();
            var trainingPipeline = dataProcessPipeline.Append(_model);

            _trainedModel = trainingPipeline.Fit(_dataSplit.TrainSet);
        }

        /// <summary>
        /// Evaluate trained model.
        /// </summary>
        /// <returns>RegressionMetrics object.</returns>
        public RegressionMetrics Evaluate()
        {
            var testSetTransform = _trainedModel.Transform(_dataSplit.TestSet);

            return MlContext.Regression.Evaluate(testSetTransform);
        }

        /// <summary>
        /// Save Model in the file.
        /// </summary>
        public void Save()
        {
            MlContext.Model.Save(_trainedModel, _dataSplit.TrainSet.Schema, ModelPath);
        }

        /// <summary>
        /// Feature engeneering and data pre-processing.
        /// </summary>
        /// <returns>Data Processing Pipeline.</returns>
        private EstimatorChain<ValueToKeyMappingTransformer> BuildDataProcessingPipeline()
        {
            var dataProcessPipeline = MlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "UserId",
                    outputColumnName: "UserIdEncoded")
                .Append(MlContext.Transforms.Conversion.MapValueToKey(
                    inputColumnName: "SongId",
                    outputColumnName: "SongIdEncoded"))
                .AppendCacheCheckpoint(MlContext);

            return dataProcessPipeline;
        }

        private DataOperationsCatalog.TrainTestData LoadAndPrepareData(string trainingFileName)
        {
            IDataView trainingDataView = MlContext.Data.LoadFromTextFile<SongRating>
                          (trainingFileName, hasHeader: true, separatorChar: ',');
            return MlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.1);
        }

        BinaryClassificationMetrics ITrainerBase.Evaluate()
        {
            throw new NotImplementedException();
        }
    }
}

