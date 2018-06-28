
namespace Auxiliary
{
    public static class Normalizator
    {
        public static float Normalize(float value, float oldMin, float oldMax, float newMin, float newMax)
        {
            float proportion = (value - oldMin) / (oldMax - oldMin);
            return (proportion * (newMax - newMin) + newMin);
        }
    }
}
