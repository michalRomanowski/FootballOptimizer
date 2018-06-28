using Auxiliary;

namespace ActivationFunctions
{
    class CTanh : IActivationFunction
    {
        public float Impuls(float net)
        {
            return CMath.Tanh(net);
        }
    }
}
