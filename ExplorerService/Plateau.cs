using System;
namespace ExplorerService
{
    public class Plateau
    {
        public int NumPlateauCorners{ get; private set; }
        public List<int> PlateauCornersCoordinates { get; private set; }
        public List<int[]> Obstacle { get; set; }

        public Plateau(int numPlateauCorners, List<int> plateauCornersCoordinates)
        {
            NumPlateauCorners = numPlateauCorners;
            PlateauCornersCoordinates = plateauCornersCoordinates;
            Obstacle = new List<int[]>();
        }

        public bool IsEmptyPos(int x, int y)
        {
            for (int i=0; i<Obstacle.Count(); i++)
            {
                if (x == Obstacle[i][0] && y == Obstacle[i][1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

