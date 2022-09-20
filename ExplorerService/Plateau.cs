using System;
namespace ExplorerService
{
    public class Plateau
    {
        //{ 0, 0, 0, 5, 5, 5, 5, 0 };
        public int NumPlateauCorners{ get; private set; }
        public List<int> PlateauCornersCoordinates { get; private set; }
        public List<string[]> Obstacle { get; set; } //structure {{ Obstacle Type, Coordinate X, Coordinate Y }, { Obstacle Type, Coordinate X, Coordinate Y }, etc}

        public Plateau(int numPlateauCorners, List<int> plateauCornersCoordinates)
        {
            NumPlateauCorners = numPlateauCorners;
            PlateauCornersCoordinates = plateauCornersCoordinates;
            Obstacle = new List<string[]>();
        }

        public bool IsEmptyPos(int x, int y)
        {
            //Obstacle.Add(new string[] { "MarsRover", "1", "1" });
            foreach (string[] obstacleObject in Obstacle)
            {
                if (x.ToString() == obstacleObject[1] && y.ToString() == obstacleObject[2])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsBoundaryPos(int x, int y)
        {
            int[,] EachCornersCoordinates = new int[NumPlateauCorners, 2];

            for (int i = 0; i < NumPlateauCorners; i++)
            {
                EachCornersCoordinates[i, 0] = PlateauCornersCoordinates[i * 2];
                EachCornersCoordinates[i, 1] = PlateauCornersCoordinates[i * 2 + 1];
            }
            return true;
        }
    }
}

