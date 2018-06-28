using System;
using System.IO;

namespace Auxiliary
{
    public static class CStreamHelper
    {
        public static void Save(StreamWriter sw, float[,] values)
        {
            sw.WriteLine(values.GetLength(0));
            sw.WriteLine(values.GetLength(1));

            for (int i = 0; i < values.GetLength(0); i++)
            {
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    sw.WriteLine(values[i, j]);
                }
            }
        }

        public static void Save(StreamWriter sw, float[] values)
        {
            sw.WriteLine(values.GetLength(0));

            for (int i = 0; i < values.GetLength(0); i++)
            {
                sw.WriteLine(values[i]);
            }
        }

        public static void Save(StreamWriter sw, float[][] values)
        {
            sw.WriteLine(values.GetLength(0));

            for (int i = 0; i < values.Length; i++)
            {
                Save(sw, values[i]);
            }
        }

        public static float[,] Load2DimFloatArray(StreamReader sr)
        {
            int length0 = Convert.ToInt32(sr.ReadLine());
            int length1 = Convert.ToInt32(sr.ReadLine());

            var wages = new float[length0, length1];

            for (int i = 0; i < wages.GetLength(0); i++)
            {
                for (int j = 0; j < wages.GetLength(1); j++)
                {
                    wages[i, j] = (float)decimal.Parse(sr.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
                }
            }

            return wages;
        }

        public static float[][] Load2DimFloatJaggedArray(StreamReader sr)
        {
            int length = Convert.ToInt32(sr.ReadLine());

            var values = new float[length][];

            for (int i = 0; i < length; i++)
            {
                values[i] = CStreamHelper.Load1DimFloatArray(sr);
            }

            return values;
        }

        public static float[] Load1DimFloatArray(StreamReader sr)
        {
            int length = Convert.ToInt32(sr.ReadLine());

            var values = new float[length];

            for (int i = 0; i < length; i++)
            {
                values[i] = (float)decimal.Parse(sr.ReadLine().Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            }

            return values;
        }
    }
}
