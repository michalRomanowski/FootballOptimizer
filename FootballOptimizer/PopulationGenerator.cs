namespace FootballOptimizer
{
    public static class PopulationGenerator
    {
        private const string PATH = @"C:\Users\Lenovo\Documents\Football\newPopulation";
        private const int POPULATION_SIZE = 24;

        private const int MOVING_WITH_BALL_INPUT_LAYER_SIZE = 6;
        private const int MOVING_WITH_BALL_OUTPUT_LAYER_SIZE = 8;
        private const int MOVING_WITH_BALL_NUMBER_OF_HIDDEN_LAYERS = 1;
        private const int MOVING_WITH_BALL_HIDDEN_LAYER_SIZE = 2;

        private const int MOVING_WITHOUT_BALL_INPUT_LAYER_SIZE = 6;
        private const int MOVING_WITHOUT_BALL_OUTPUT_LAYER_SIZE = 8;
        private const int MOVING_WITHOUT_BALL_NUMBER_OF_HIDDEN_LAYERS = 1;
        private const int MOVING_WITHOUT_BALL_HIDDEN_LAYER_SIZE = 2;

        private const int KICKING_BALL_INPUT_LAYER_SIZE = 6;
        private const int KICKING_BALL_OUTPUT_LAYER_SIZE = 8;
        private const int KICKING_BALL_NUMBER_OF_HIDDEN_LAYERS = 1;
        private const int KICKING_BALL_HIDDEN_LAYER_SIZE = 2;

        public static void GeneratePopulation()
        {
            for(int i = 0; i < POPULATION_SIZE; i++)
            {


            }
        }

    }
}
