using System;
using System.Collections.Generic;

namespace Auxiliary
{
    public static class CenterOfGravityCalculator
    {
        public static Position CenterOfGravity(IList<Position> points)
        {
            Position centerOfGravity = new Position(0, 0);

            foreach (var p in points)
            {
                centerOfGravity.X += p.X;
                centerOfGravity.Y += p.Y;
            }

            centerOfGravity.X /= points.Count;
            centerOfGravity.Y /= points.Count;

            return centerOfGravity;
        }

        public static float SumOfDistancesFromCenterOfGravity(IList<Position> points)
        {
            Position centerOfGravity = CenterOfGravityCalculator.CenterOfGravity(points);

            float sumOfDistances = 0.0f;

            foreach (var p in points)
            {
                sumOfDistances += (float)Math.Sqrt(Position.SquaredDistance(centerOfGravity, p));
            }

            return sumOfDistances;
        }

    }
}
