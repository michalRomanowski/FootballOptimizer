using Auxiliary;
using System;
using System.IO;

namespace NeuralNet
{
    class OneLayerNeuralNet : INeuralNet
    {
        private float[,] wages;
        private float[] biasesInOutputLayer;

        public OneLayerNeuralNet(int inputLayerSize, int outputLayerSize)
        {
            this.wages = new float[inputLayerSize, outputLayerSize];
            this.biasesInOutputLayer = new float[outputLayerSize];
        }

        public OneLayerNeuralNet(OneLayerNeuralNet pattern)
        {
            this.wages = new float[pattern.wages.GetLength(0), pattern.wages.GetLength(1)];
            Array.Copy(pattern.wages, this.wages, pattern.wages.GetLength(0) * pattern.wages.GetLength(1));

            this.biasesInOutputLayer = new float[pattern.biasesInOutputLayer.Length];
            Array.Copy(pattern.biasesInOutputLayer, this.biasesInOutputLayer, pattern.biasesInOutputLayer.Length);
        }

        public void Randomize()
        {
            for (int i = 0; i < wages.GetLength(0); i++)
            {
                for (int j = 0; j < wages.GetLength(1); j++)
                {
                    this.wages[i, j] = CRandom.NextFloat(-1.0f, 1.0f);
                }
            }

            for (int i = 0; i < this.biasesInOutputLayer.Length; i++)
            {
                this.biasesInOutputLayer[i] = CRandom.NextFloat(-1.0f, 1.0f);
            }
        }

        public float[] Think(float[] input)
        {
            float[] output = new float[wages.GetLength(1)];

            for(int i = 0; i < output.Length; i++)
            {
                output[i] = this.biasesInOutputLayer[i];

                for(int j = 0; j < wages.GetLength(0); j++)
                {
                    output[i] += input[j] * wages[j, i];
                }
            }

            return output;
        }

        public void Mutate(float chanceOfMutation, float maxAddeValue = 1.0f)
        {
            for(int i = 0; i < wages.GetLength(0); i++)
            {
                for(int j = 0; j < wages.GetLength(1); j++)
                {
                    if(CRandom.NextFloat() < chanceOfMutation)
                    {
                        wages[i, j] += CRandom.NextFloat(-maxAddeValue, maxAddeValue);
                    }
                }
            }

            for (int i = 0; i < this.biasesInOutputLayer.Length; i++)
            {
                if (CRandom.NextFloat() < chanceOfMutation)
                {
                    this.biasesInOutputLayer[i] += CRandom.NextFloat(-maxAddeValue, maxAddeValue);
                }
            }
        }

        public INeuralNet Crossover(INeuralNet other)
        {
            if(other is OneLayerNeuralNet == false)
            {
                throw new ApplicationException("'other' should be of type COneLayerNeuralNet to be able to crossover with COneLayerNeuralNet.");
            }

            var child = new OneLayerNeuralNet(this.wages.GetLength(0), this.wages.GetLength(1));

            child.wages = CrossoverHelper.Crossover(this.wages, (other as OneLayerNeuralNet).wages);
            child.biasesInOutputLayer = CrossoverHelper.Crossover(this.biasesInOutputLayer, (other as OneLayerNeuralNet).biasesInOutputLayer);

            return child;
        }

        public void AdjustInputLayerSize(int newSize)
        {
            throw new NotImplementedException();
        }

        public void AdjustHiddenLayersSize(int newSize)
        {
            throw new NotImplementedException();
        }
        
        public INeuralNet Clone()
        {
            return new OneLayerNeuralNet(this);
        }

        public void Save(StreamWriter sw)
        {
            CStreamHelper.Save(sw, this.wages);
            CStreamHelper.Save(sw, this.biasesInOutputLayer);
        }

        public void Load(StreamReader sr)
        {
            this.wages = CStreamHelper.Load2DimFloatArray(sr);
            this.biasesInOutputLayer = CStreamHelper.Load1DimFloatArray(sr);
        }

        public void Save(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
                Save(sw);
        }

        public void Load(string path)
        {
            using (StreamReader sr = new StreamReader(path))
                Load(sr);
        }
    }
}
