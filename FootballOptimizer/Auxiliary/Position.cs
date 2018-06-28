using System;
using System.Collections.Generic;
using System.Linq;

namespace Auxiliary
{
    public class Position
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Position()
        { }

        public Position(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(Position value)
        {
            this.X = value.X;
            this.Y = value.Y;
        }

        public static float SquaredDistance(Position A, Position B)
        {
            float dx = A.X - B.X;
            float dy = A.Y - B.Y;
            return dx * dx + dy * dy;
        }


        public static float Length(Position A)
        {
            return A.X * A.X + A.Y * A.Y;
        }

        public static float Distance(Position A, Position B)
        {
            return (float)Math.Sqrt(Position.SquaredDistance(A, B));
        }

        public static IList<Position> GenerateRandomPositionsList(int length, float min, float max)
        {
            var randomPositionsList = new List<Position>();

            for (int i = 0; i < length; i++ )
            {
                randomPositionsList.Add(
                    new Position(
                        CRandom.NextFloat(min, max),
                        CRandom.NextFloat(min, max)));
            }

            return randomPositionsList;
        }

        public static List<Position> PositionsInRelativeCoordinationSystem(Position newO, Position anyPointOnPositiveSideOfNewOY, IEnumerable<Position> positionsInOldCoordinationSystem)
        {
            var movedCentre = positionsInOldCoordinationSystem.Select(p => new Position(p.X - newO.X, p.Y - newO.Y)).ToList<Position>();

            anyPointOnPositiveSideOfNewOY = new Position(
                anyPointOnPositiveSideOfNewOY.X - newO.X, anyPointOnPositiveSideOfNewOY.Y - newO.Y);
            
            float d = (float)Math.Sqrt(anyPointOnPositiveSideOfNewOY.X * anyPointOnPositiveSideOfNewOY.X + anyPointOnPositiveSideOfNewOY.Y * anyPointOnPositiveSideOfNewOY.Y);

            float sin = anyPointOnPositiveSideOfNewOY.X / d;
            float cos = anyPointOnPositiveSideOfNewOY.Y / d;

            if (float.IsNaN(sin))
                sin = 0.0f;

            if (float.IsNaN(cos))
                cos = 1.0f;

            return movedCentre.Select(p => new Position(p.X * cos - p.Y * sin, p.X * sin + p.Y * cos)).ToList();
        }

        public class DistanceFromOOComparer : IComparer<Position>
        {
            public int Compare(Position a, Position b)
            {
                if (a.X * a.X + a.Y * a.Y > b.X * b.X + b.Y * b.Y)
                {
                    return 1;
                }
                else return -1;
            }
        }

        public static float SumOfDistancesFromCentreOfGravity(IList<Position> positions)
        {
            var centerOfGravity =
                CenterOfGravityCalculator.CenterOfGravity(positions);

            float sumOfDistances = 0.0f;

            foreach (var p in positions)
            {
                sumOfDistances += Position.Distance(centerOfGravity, p);
            }

            return sumOfDistances;
        }
    }
}
