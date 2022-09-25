namespace ExplorerService
{
    public abstract class Plateau : IPlateau
    {
        public int NumPlateauCorners{ get; private set; }
        public int[] PlateauMaxCoordinates { get; private set; }
        public List<int> PlateauCornersCoordinates { get; private set; }
        protected List<string[]> Obstacle { get; private set; } //structure: {{ Obstacle Type, Coordinate X, Coordinate Y },{...} }

        public Plateau(int numPlateauCorners, List<int> plateauCornersCoordinates, int[] plateauMaxCoordinates)
        {
            Obstacle = new List<string[]>();
            NumPlateauCorners = numPlateauCorners;
            PlateauCornersCoordinates = plateauCornersCoordinates;
            PlateauMaxCoordinates = plateauMaxCoordinates;
        }

        public abstract string WhoAmI();

        public abstract int PlateauSize();

        public abstract bool IsOutOfBoundaryPos(int x, int y);

        public void SetNumPlateauCorners(int numPlateauCorners)
        {
            NumPlateauCorners = numPlateauCorners;
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

        public List<string[]> RetrieveObstacles()
        {
            return Obstacle;
        }

        public void AddObstacle(string obstacleType, int x, int y)
        {
            Obstacle.Add(new string[] { obstacleType, x.ToString(), y.ToString() });
        }

        public void RemoveObstacle(string obstacleType, int x, int y)
        {
            for (int i=0; i<Obstacle.Count; i++)
            {
                if (Obstacle[i][0]==obstacleType && Obstacle[i][1]==x.ToString() && Obstacle[i][2]==y.ToString())
                    Obstacle.RemoveAt(i);
            }
        }
    }
}

