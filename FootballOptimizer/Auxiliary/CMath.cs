using System;

namespace Auxiliary
{
    public static class CMath
    {
        public const float PI = 1.57079632679f;

        public static int Max(int[] nums)
        {
            if(nums.Length == 0)
            {
                throw new ApplicationException("'nums' has to contain at least one int.");
            }

            int max = nums[0];

            for(int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > max)
                    max = nums[i];
            }

            return max;
        }

        public static float Tanh(float x)
        {
            return (float)Math.Tanh(x);
        }

        public static void ToVectorLengthOne(ref float x, ref float y)
        {
            bool negativeX = x < 0;
            bool negativeY = y < 0;

            float p = x / y;

            if (float.IsInfinity(p))
                p = float.MaxValue;
            if (float.IsNegativeInfinity(p))
                p = -float.MaxValue;

            if (p < 0)
                p = -p;

            y = (float)Math.Sqrt(1 / (p * p + 1));
            x = p * y;

            if (negativeX) x = -x;
            if (negativeY) y = -y;
        }
    }
}
