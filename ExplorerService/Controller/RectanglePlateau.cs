namespace ExplorerService
{
    public class RectanglePlateau : Plateau
    {
        public RectanglePlateau(int numPlateauVertices, List<int> plateauVerticesCoordinates) : base(numPlateauVertices: numPlateauVertices, plateauVerticesCoordinates: plateauVerticesCoordinates)
        {
            for (int i = 0; i < PlateauVerticesCoordinates.Count() - 1; i += 2)
            {
                if (MaxX < PlateauVerticesCoordinates[i]) MaxX = PlateauVerticesCoordinates[i];
                if (MaxY < PlateauVerticesCoordinates[i + 1]) MaxY = PlateauVerticesCoordinates[i + 1];
            }
        }

        public override int PlateauSize()
        {
            return (MaxX * MaxY);
        }

        public override bool IsOutOfBoundaryPos(int x, int y)
        {
            //Assume lower left hand corner of the Plateau is (0,0)
            const int minX = 0;
            const int minY = 0;

            return (x < minX || y < minY || x > MaxX || y > MaxY);
        }
    }
}