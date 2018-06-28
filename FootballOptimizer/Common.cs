using System;
using System.IO;

namespace FootballOptimizer
{
    public static class Common
    {
        public const string FOOTBALL_PATH = @"C:\Users\Lenovo\Documents\Football\Football.exe";
        public const string RANDOM_POSITIONS_PATH = @"C:\Users\Lenovo\Documents\Football\RandomPositions";

        public static Random R = new Random((int)DateTime.Now.Ticks);
        
        public const string MOVING_WITHOUT_BALL_NEURAL_NET_NAME = "MovingNeuralNet";
        public const string MOVING_WITH_BALL_NEURAL_NET_NAME = "MovingWithBallNeuralNet";
        public const string KICKING_BALL_NEURAL_NET_NAME = "KickingBallNeuralNet";

        public static void GenerateRandomPositionsFile(string path, int numberOfPlayers, bool includeBall)
        {
            using (var sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    WriteRandomPosition(sw);
                    WriteRandomPosition(sw);

                    sw.WriteLine(R.Next(360));
                }

                if (includeBall)
                {
                    WriteRandomPosition(sw);
                    WriteRandomPosition(sw);
                }
            }
        }
        
        private static void WriteRandomPosition(StreamWriter sw)
        {
            float rand = (float)R.NextDouble();
            rand -= 0.5f;
            rand *= 4;
            sw.WriteLine(rand);
        }
    }
}
