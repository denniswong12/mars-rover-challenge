namespace ExplorerService
{
    public class Plateau
    {
        protected int NumPlateauCorners{ get; private set; }
        protected List<int> PlateauCornersCoordinates { get; private set; }
        protected List<string[]> Obstacle { get; private set; } //structure {{ Obstacle Type, Coordinate X, Coordinate Y }, { Obstacle Type, Coordinate X, Coordinate Y }, etc}

        public Plateau(int numPlateauCorners, List<int> plateauCornersCoordinates)
        {
            NumPlateauCorners = numPlateauCorners;
            PlateauCornersCoordinates = plateauCornersCoordinates;
            Obstacle = new List<string[]>();
        }

        public bool IsEmptyPos(int x, int y)
        {
            foreach (string[] obstacleObject in Obstacle)
            {
                if (x.ToString() == obstacleObject[1] && y.ToString() == obstacleObject[2])
                {
                    return false;
                }
            }
            return true;
        }

        public void AddObstacle(string obstacleType, int x, int y)
        {
            Obstacle.Add(new string[] { obstacleType, x.ToString(), y.ToString() });
        }

        public void RemoveObstacle(string obstacleType, int x, int y)
        {
            Obstacle.Remove(new string[] { obstacleType, x.ToString(), y.ToString() });
        }

        public bool IsBoundaryPos(int x, int y)
        {
            if ( x == 0 || y == 0 || x == 5 || y == 5 ) return true;
            return false;

            //Following code can get the coordinates of all the points of the Plateau corners,
            //useful to extend support for different shape of Platau
            /*
            int[,] EachCornersCoordinates = new int[NumPlateauCorners, 2];

            for (int i = 0; i < NumPlateauCorners; i++)
            {
                EachCornersCoordinates[i, 0] = PlateauCornersCoordinates[i * 2];
                EachCornersCoordinates[i, 1] = PlateauCornersCoordinates[i * 2 + 1];
            }
            */
        }
    }
}

