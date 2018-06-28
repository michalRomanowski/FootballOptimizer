using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NeuralNet
{
    public interface INeuralNet : IRandomize, IGenetic<INeuralNet>, IClone, IDiscStorage
    {
        float[] Think(float[] input);
        void AdjustInputLayerSize(int newSize);
        void AdjustHiddenLayersSize(int newSize);
    }

    public interface IRandomize
    {
        void Randomize();
    }

    public interface IGenetic<T>
    {
        void Mutate(float chanceOfMutation, float maxAddeValue = 1.0f);
        T Crossover(T other);
    }

    public interface IClone
    {
        INeuralNet Clone();
    }

    public interface IDiscStorage
    {
        void Save(StreamWriter sw);
        void Load(StreamReader sr);

        void Save(string path);
        void Load(string path);
    }
}
