using Auxiliary;
using System;

namespace NeuralNet
{
    static class CrossoverHelper
    {
        public static float[] Crossover(float[] parentA, float[] parentB)
        {
            if (parentA.Length != parentB.Length)
            {
                throw new ApplicationException("Corssover of two tables with different sizes is not allowed.");
            }

            var child = new float[parentA.Length];

            for (int i = 0; i < child.Length; i++)
            {
                if (CRandom.NextFloat() < 0.5f)
                {
                    child[i] = parentA[i];
                }
                else
                {
                    child[i] = parentB[i];
                }
            }

            return child;
        }

        public static float[,] Crossover(float[,] parentA, float[,] parentB)
        {
            if (parentA.Length != parentB.Length)
            {
                throw new ApplicationException("Corssover of two tables with different sizes is not allowed.");
            }

            var child = new float[parentA.GetLength(0), parentA.GetLength(1)];

            for (int i = 0; i < child.GetLength(0); i++)
            {
                for (int j = 0; j < child.GetLength(1); j++)
                {
                    if (CRandom.NextFloat() < 0.5f)
                    {
                        child[i, j] = parentA[i, j];
                    }
                    else
                    {
                        child[i, j] = parentB[i, j];
                    }
                }
            }

            return child;
        }
    }
}
