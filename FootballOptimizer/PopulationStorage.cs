using NeuralNet;
using System.Collections.Generic;

namespace FootballOptimizer
{
    public static class PopulationStorage
    {        
        public static void LoadPopulation(string populationPath, string neuralNetName, IList<INeuralNet> neuralNetPopulation)
        {
            for (int i = 0; i < neuralNetPopulation.Count; i++)
            {
                neuralNetPopulation[i].Load(populationPath + "\\" +  i.ToString() + "\\" + neuralNetName);
            }
        }

        public static void SavePopulation(string populationPath, string neuralNetName, IList<INeuralNet> neuralNetPopulation)
        {
            for (int i = 0; i < neuralNetPopulation.Count; i++)
            {
                neuralNetPopulation[i].Save(populationPath + "\\" + i.ToString() + "\\" + neuralNetName);
            }
        }
    }
}
