using System.IO;
using static System.Reflection.Metadata.BlobBuilder;

namespace ExplorerService
{
    public class CommandCenter
    {
        const int numCorrdinates = 2;
        protected Plateau _plateau;
        private UserInterface _userInterface = new UserInterface();

        private int[] _plateauMaxCoordinates = new int[numCorrdinates];
        private List<MarsRover> ListMarsRovers = new List<MarsRover>();

        public void InitEnvironment()
        {
            int numCoordinates = 2;

            _plateauMaxCoordinates = _userInterface.GetPlateauCornersCoordinates();
            List<int> plateauCorners = new List<int> { 0, 0, _plateauMaxCoordinates[0], 0, _plateauMaxCoordinates[0], _plateauMaxCoordinates[1], 0, _plateauMaxCoordinates[1] };
            int numPlateauCorners = plateauCorners.Count() / numCoordinates;

            _plateau = new Plateau(numPlateauCorners, plateauCorners);
        }

        public int GetNumPlateauCorners()
        {
            return _plateau.NumPlateauCorners;
        }
    }
}