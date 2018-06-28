using System;
using System.Text;

namespace FootballOptimizer
{
    public static class ArgsGenerator
    {
        private const string BATHMODE_ARG = "-batchmode";
        private const string NOGRAPHICS_ARG = "-nographics";
        private const string AWAY_TEAM_PATH_ARG = "-awayTeamPath";
        private const string HOME_TEAM_PATH_ARG = "-homeTeamPath";
        private const string MODE_ARG = "-mode";
        private const string POSITIONS_PATH_ARG = "-positionsPath";
        private const string MINUTES_ARG = "-minutes";
        private const string IMMOBILIZE_ARG = "-immobilize";

        public const string GAME_MODE_1v1_WITHOUT_BALL = "Simple1v1WithoutBall";
        public const string GAME_MODE_1v1_WITH_BALL = "Simple1v1MovingWithBall";
        public const string GAME_MODE_1v1_PLAY = "Simple1v1Play";
        public const string GAME_MODE_2v2_PLAY = "Simple2v2Play";

        public static string GenerateArgs(bool show, string mode, string awayTeamPath, string homeTeamPath, string positionsPath, int minutes, bool immobilize)
        {
            var args = new StringBuilder();

            if (!show)
            {
                AppendArg(args, BATHMODE_ARG);
                AppendArg(args, NOGRAPHICS_ARG);
            }

            AppendArg(args, AWAY_TEAM_PATH_ARG, awayTeamPath);
            AppendArg(args, HOME_TEAM_PATH_ARG, homeTeamPath);
            AppendArg(args, POSITIONS_PATH_ARG , positionsPath);
            AppendArg(args, MINUTES_ARG, minutes.ToString());
            AppendArg(args, MODE_ARG, mode);

            if (immobilize)
                AppendArg(args, IMMOBILIZE_ARG);

            return args.ToString();
        }

        private static void AppendArg(StringBuilder args, string argName)
        {
            args.Append(argName);
            args.Append(" ");
        }

        private static void AppendArg(StringBuilder args, string argName, string value)
        {
            if (string.IsNullOrEmpty(value))
                return;

            args.Append(argName);
            args.Append(" ");
            args.Append(value);
            args.Append(" ");
        }
    }
}
