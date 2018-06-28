namespace ActivationFunctions
{
    class CStep : IActivationFunction
    {
        public float Impuls(float net)
        {
            if (net == 0.0f)
                return 0.0f;

            return net > 0.0f ? 1.0f : -1.0f;
        }

    }
}
