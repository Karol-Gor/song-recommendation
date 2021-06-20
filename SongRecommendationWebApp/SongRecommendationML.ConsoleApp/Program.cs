// This file was auto-generated by ML.NET Model Builder. 

using System;
using SongRecommendationML.Model;

namespace SongRecommendationML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                UserId = 1F,
                SongId = 372F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Rate with predicted Rate from sample data...\n\n");
            Console.WriteLine($"UserId: {sampleData.UserId}");
            Console.WriteLine($"SongId: {sampleData.SongId}");
            Console.WriteLine($"\n\nPredicted Rate: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
