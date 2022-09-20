using System;
namespace ExplorerService
{
    public class Plateau
    {
        public int NumPlateauCorners{ get; private set; }
        public int[] PlateauCornersCoordinates { get; private set; }

        public Plateau(int numPlateauCorners, int[] plateauCornersCoordinates)
        {
            NumPlateauCorners = numPlateauCorners;
            PlateauCornersCoordinates = plateauCornersCoordinates;
        }

        public bool IsEmptyPos(int x, int y)
        {
            return true;
        }
    }
}

