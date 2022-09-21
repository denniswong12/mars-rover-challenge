using System.Linq;

namespace ExplorerService
{
    public class Plateau
    {
        public int NumPlateauCorners{ get; private set; }
        protected List<int> PlateauCornersCoordinates { get; private set; }
        protected List<string[]> Obstacle { get; private set; } //structure: {{ Obstacle Type, Coordinate X, Coordinate Y }, { Obstacle Type, Coordinate X, Coordinate Y }, etc}

        public Plateau(int numPlateauCorners, List<int> plateauCornersCoordinates)
        {
            Obstacle = new List<string[]>();
            NumPlateauCorners = numPlateauCorners;
            PlateauCornersCoordinates = plateauCornersCoordinates;
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

        public bool IsOutOfBoundaryPos(int x, int y)
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

            if (x < minX || y < minY || x > maxX || y > maxY) return true;
            return false;
        }
    }
}

