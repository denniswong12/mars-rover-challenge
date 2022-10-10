namespace ExplorerService
{
    public interface IPlateau
    {
        public bool IsEmptyPos(int x, int y);
        public int PlateauSize();
        public List<string[]> RetrieveObstacles();
        public void AddSingleObstacle(string obstacleType, int x, int y);
        public void RemoveObstacle(string obstacleType, int x, int y);
        public bool IsOutOfBoundaryPos(int x, int y);
    }
}