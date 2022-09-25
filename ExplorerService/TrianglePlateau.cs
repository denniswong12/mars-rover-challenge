namespace ExplorerService
{
    public class TrianglePlateau : Plateau
    { 
        public TrianglePlateau(int numPlateauCorners, List<int> plateauCornersCoordinates, List<int> plateauMaxCoordinates) : base(numPlateauCorners: numPlateauCorners, plateauCornersCoordinates: plateauCornersCoordinates, plateauMaxCoordinates: plateauMaxCoordinates)
        {
        }

        public override string WhoAmI()
        {
            return "Triangle Plateau :D";
        }

        public override int PlateauSize()
        {
            return ((PlateauMaxCoordinates[0] + 1) * (PlateauMaxCoordinates[1] + 1));
        }

        public override bool IsOutOfBoundaryPos(int x, int y)
        {
            int maxX = 0;
            int maxY = 0;
            //Assume lower left hand corner of the Plateau is (0,0)
            const int minX = 0;
            const int minY = 0;
            const int numCoordinates = 2;
            int[,] eachCornersCoordinates = new int[NumPlateauCorners, numCoordinates];

            for (int i = 0; i < NumPlateauCorners; i++)
            {
                eachCornersCoordinates[i, 0] = PlateauCornersCoordinates[i * numCoordinates];
                eachCornersCoordinates[i, 1] = PlateauCornersCoordinates[i * numCoordinates + 1];
                //Assume Plateau is a rectangle
                if (maxX < eachCornersCoordinates[i, 0]) maxX = eachCornersCoordinates[i, 0];
                if (maxY < eachCornersCoordinates[i, 1]) maxY = eachCornersCoordinates[i, 1];
            }

            return (x < minX || y < minY || x > maxX || y > maxY);
        }
    }
}