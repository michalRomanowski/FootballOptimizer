using System;
using System.IO;
using System.Diagnostics;


namespace FootballOptimizer
{
    public class Simple2v2OptimizationMovingWithoutBall : Simple1v1Optimization, IOptimization
    {

        public Simple2v2OptimizationMovingWithoutBall()
        {
            populationSize = 24;
            chanceOfMutation = 0.01f;
            maxAddedValue = 0.25f;
            populationPath = @"C:\Users\Lenovo\Documents\Football\PopulationMovingAndKickingBall";
            minutes = 2;
            neuralNetName = Common.MOVING_WITH_BALL_NEURAL_NET_NAME;
            showBest = true;
            replacementRate = 0.25f;
            repetitions = 1;
            randomPositions = true;
            //opponentTeam = @"C:\Users\Lenovo\Documents\Football\OpponentTeam";
            //immobilize = true;
            //singleRandomPosition = true;

            Init();

            PopulationStorage.LoadPopulation(populationPath, neuralNetName, population);
        }

        protected override void CountFitness(string index)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo(Common.FOOTBALL_PATH);

            var args = ArgsGenerator.GenerateArgs(
                showBest && index == "0",
                ArgsGenerator.GAME_MODE_2v2_PLAY,
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
