namespace NeuralNet
{
    public static class NeuralNetsProvider
    {
        public static INeuralNet GetRandomOneLayerNeuralNet(int inputLayerSize, int outputLayerSize)
        {
            var randomOneLayerNeuralNet = new OneLayerNeuralNet(inputLayerSize, outputLayerSize);

            randomOneLayerNeuralNet.Randomize();

            return randomOneLayerNeuralNet;
        }

        public static INeuralNet GetRandomMultiLayerNeuralNet(int inputLayerSize, int outputLayerSize, int hiddenLayerSize, int numberOfHiddenLayers)
        {
            var randomMultiLayerNeuralNet = new MultiLayerNeuralNet(inputLayerSize, outputLayerSize, hiddenLayerSize, numberOfHiddenLayers);

            randomMultiLayerNeuralNet.Randomize();

            return randomMultiLayerNeuralNet;
        }
    }
}
