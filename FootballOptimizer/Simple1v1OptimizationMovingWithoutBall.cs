using System;
using System.IO;
using System.Diagnostics;

namespace FootballOptimizer
{
    public class Simple1v1OptimizationWithoutBall : Simple1v1Optimization, IOptimization
    {
        public Simple1v1OptimizationWithoutBall()
        {
            populationSize = 24;
            chanceOfMutation = 0.01f;
            maxAddedValue = 0.25f;
            populationPath = @"C:\Users\Lenovo\Documents\Football\PopulationMovingWithoutBall";
            minutes = 3;
            neuralNetName = Common.MOVING_WITHOUT_BALL_NEURAL_NET_NAME;
            showBest = false;
            replacementRate = 0.25f;
            repetitions = 3;
            randomPositions = true;
            opponentTeam = @"C:\Users\Lenovo\Documents\Football\OpponentTeam";

            Init();

            PopulationStorage.LoadPopulation(populationPath, neuralNetName, population);
        }

        protected override void CountFitness(string index)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo(Common.FOOTBALL_PATH);

            var args = ArgsGenerator.GenerateArgs(
                showBest && index == "0",
                ArgsGenerator.GAME_MODE_1v1_WITHOUT_BALL,
                Path.Combine(populationPath, index),
                opponentTeam,
                randomPositions ? Common.RANDOM_POSITIONS_PATH : null,
                minutes,
                immobilize);
            
            processInfo.Arguments = args.ToString();
            Process process = Process.Start(processInfo);
            process.WaitForExit();
        }
    }
}
