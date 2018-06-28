using System;

namespace Auxiliary
{
    public static class CRandom
    {
        public static readonly Random r = new Random(DateTime.Now.Millisecond);

        public static float NextFloat(float min = 0.0f, float max = 1.0f)
        {
            return ((float)CRandom.r.NextDouble() * (max - min) + min);
        }

        public static void Randmize(ref float[] valuesToRandomize)
        {
            for (int i = 0; i < valuesToRandomize.Length; i++)
            {
                valuesToRandomize[i] = CRandom.NextFloat(-1.0f, 1.0f);
            }
        }

        public static void Randmize(ref float[,] valuesToRandomize)
        {
            for (int i = 0; i < valuesToRandomize.GetLength(0); i++)
            {
                for (int j = 0; j < valuesToRandomize.GetLength(1); j++)
                {
                    valuesToRandomize[i, j] = CRandom.NextFloat(-1.0f, 1.0f);
                }
            }
        }
    }
}
