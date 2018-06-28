using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NeuralNet;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace FootballOptimizer
{
    public abstract class Simple1v1Optimization : IOptimization
    {
        protected int populationSize;
        protected float chanceOfMutation;
        protected float maxAddedValue;
        protected string populationPath;
        protected int minutes;
        protected string neuralNetName;
        protected float replacementRate;
        protected int repetitions;
        protected bool randomPositions;
        protected string opponentTeam;
        protected bool immobilize;
        protected bool singleRandomPosition;
        protected bool showBest;

        protected List<INeuralNet> population;
        protected Dictionary<INeuralNet, float> fitness;

        public void Era()
        {
            Mutate(chanceOfMutation, maxAddedValue);

            SaveToDisc();
            
            CountFitness();

            population.Sort((x, y) => fitness[x].CompareTo(fitness[y]) * -1 );

            ShowResults();

            Replace();
        }

        protected void Init()
        {
            population = new List<INeuralNet>();
            fitness = new Dictionary<INeuralNet, float>();

            for (int i = 0; i < populationSize; i++)
            {
                var net = NeuralNetsProvider.GetRandomMultiLayerNeuralNet(1, 1, 1, 1);

                population.Add(net);
                fitness.Add(net, 0.0f);
            }
        }

        protected void Mutate(float chanceOfMutation, float maxAddedValue = 1.0f)
        {
            foreach (var net in population)
            {
                if (net != population[0])
                    net.Mutate(chanceOfMutation, maxAddedValue);
            }
        }

        protected void SaveToDisc()
        {
            PopulationStorage.SavePopulation(populationPath, neuralNetName, population);
        }

        protected void CountFitness()
        {
            foreach (var f in fitness.ToList())
                fitness[f.Key] = 0.0f;

            for (int i = 0; i < repetitions; i++)
            {
                var tasks = new List<Task>();

                if (randomPositions && !singleRandomPosition)
                    Common.GenerateRandomPositionsFile(Common.RANDOM_POSITIONS_PATH, 2, true);

                for (int j = 0; j < population.Count; j++)
                {
                    string jString = j.ToString();
                    Task task = new Task(() => CountFitness(jString));

                    tasks.Add(task);

                    task.Start();
                }

                Task.WaitAll(tasks.ToArray());

                for (int j = 0; j < population.Count; j++)
                {
                    using (StreamReader sr = new StreamReader(populationPath + "\\" + j + "\\" + "Fitness"))
                        fitness[population[j]] += float.Parse(sr.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);
                }
            }
        }
        
        protected void ShowResults()
        {
            for (int i = 0; i < population.Count; i++)
                Console.WriteLine("Fitness: " + fitness[population[i]]);

            Console.WriteLine("Best fitness: " + fitness[population[0]]);
            Console.WriteLine("Average fitness: " + (fitness.Sum(x => x.Value) / fitness.Count));
        }

        protected void Replace()
        {
            for(int i = 0; (float)i / populationSize < replacementRate; i++)
            {
                Replace(population[population.Count - 1 - i], population[0]);
            }
        }

        protected void Replace(INeuralNet destination, INeuralNet source)
        {
            int destinationIndex = population.IndexOf(destination);

            source.Save(populationPath + "\\" + destinationIndex + "\\" + neuralNetName);
            destination.Load(populationPath + "\\" + destinationIndex + "\\" + neuralNetName);

            fitness[destination] = fitness[source];
        }

        protected abstract void CountFitness(string index);
    }
}
