namespace ExplorerService
{
    public abstract class Plateau : IPlateau
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int NumPlateauCorners { get; private set; }
        public List<int> PlateauVerticesCoordinates { get; private set; }
        protected List<string[]> Obstacle { get; private set; } //structure: {{ Obstacle Type, Coordinate X, Coordinate Y },{...} }

        public Plateau(int numPlateauVertices, List<int> plateauVerticesCoordinates)
        {
            Obstacle = new List<string[]>();
            NumPlateauCorners = numPlateauVertices;
            PlateauVerticesCoordinates = plateauVerticesCoordinates;
        }

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

        public void AddSingleObstacle(string obstacleType, int x, int y)
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

