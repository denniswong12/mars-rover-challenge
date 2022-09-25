namespace ExplorerService
{
    public class TrianglePlateau : Plateau
    {
        public TrianglePlateau(int numPlateauVertices, List<int> plateauVerticesCoordinates) : base(numPlateauVertices: numPlateauVertices, plateauVerticesCoordinates: plateauVerticesCoordinates)
        {
            for (int i = 0; i < PlateauVerticesCoordinates.Count() - 1; i += 2)
            {
                if (MaxX < PlateauVerticesCoordinates[i]) MaxX = PlateauVerticesCoordinates[i];
                if (MaxY < PlateauVerticesCoordinates[i + 1]) MaxY = PlateauVerticesCoordinates[i + 1];
            }
        }

        public override int PlateauSize()
        {
            int baseLength = 0;
            for (int i = 0; i < PlateauVerticesCoordinates.Count() - 1; i += 2)
            {
                if (PlateauVerticesCoordinates[i] != 0 && PlateauVerticesCoordinates[i + 1] == 0)
                    baseLength = PlateauVerticesCoordinates[i];
            }
            return (baseLength * MaxY / 2);
        }

        public override bool IsOutOfBoundaryPos(int x, int y)
        {
            int gradientBase = 0;
            bool pointAtLeft = false;
            bool acuteTriangle = true;

            if (x > MaxX || y > MaxY || x == 0)
                return true;

            for (int i = 0; i < PlateauVerticesCoordinates.Count() - 1; i += 2)
            {
                if ((PlateauVerticesCoordinates[i + 1] == MaxY) && (x < PlateauVerticesCoordinates[i]))
                    pointAtLeft = true;

                if (PlateauVerticesCoordinates[i] == MaxX && PlateauVerticesCoordinates[i + 1] == MaxY)
                {
                    acuteTriangle = false;
                }

                if (PlateauVerticesCoordinates[i] != MaxX && PlateauVerticesCoordinates[i] != 0)
                    gradientBase = MaxX - PlateauVerticesCoordinates[i];
            }

            if (acuteTriangle && pointAtLeft && (y / x > MaxY / MaxX))
                return true;

            if (acuteTriangle && !pointAtLeft && ((y / (MaxX - x)) > (MaxY / gradientBase)))
                return true;

            if (!acuteTriangle && (y / x > MaxY / MaxX))
                return true;

            if (!acuteTriangle && (y / x < MaxY / MaxX))
                if ((y / (x - (MaxX - gradientBase))) < (MaxY / gradientBase))
                    return true;

            return false;
        }
    }
}