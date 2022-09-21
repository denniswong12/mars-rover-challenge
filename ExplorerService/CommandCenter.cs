namespace ExplorerService
{
    public class CommandCenter
    {
        protected Plateau _plateau;
        private MarsRover _marsRover;
        private UserInterface _userInterface;

        private int[] plateauMaxCoordinates;
        private List<MarsRover> ListMarsRovers;

        public void InitEnvironment()
        {
            int numCoordinates = 2;
            _userInterface = new UserInterface();

            plateauMaxCoordinates = _userInterface.GetPlateauCornersCoordinates();
            List<int> plateauCorners = new List<int> { 0, 0, plateauMaxCoordinates[0], 0, plateauMaxCoordinates[0], plateauMaxCoordinates[1], 0, plateauMaxCoordinates[1] };
            int numPlateauCorners = plateauCorners.Count() / numCoordinates;

            _plateau = new Plateau(numPlateauCorners, plateauCorners);
        }

        public int GetNumPlateauCorners()
        {
            return _plateau.NumPlateauCorners;
        }
    }
}