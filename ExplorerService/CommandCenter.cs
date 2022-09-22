using System.IO;
using static System.Reflection.Metadata.BlobBuilder;

namespace ExplorerService
{
    public class CommandCenter
    {
        private Plateau _plateau;
        private const int _numCorrdinates = 2;
        private UserInterface _userInterface = new UserInterface();
        private int[] _plateauMaxCoordinates = new int[_numCorrdinates];
        private List<MarsRover> ListMarsRovers = new List<MarsRover>();

        public void InitEnvironment()
        {
            _plateauMaxCoordinates = _userInterface.GetPlateauCornersCoordinates();
            List<int> plateauCorners = new List<int> { 0, 0, _plateauMaxCoordinates[0], 0, _plateauMaxCoordinates[0], _plateauMaxCoordinates[1], 0, _plateauMaxCoordinates[1] };
            int numPlateauCorners = plateauCorners.Count() / _numCorrdinates;

            _plateau = new Plateau(numPlateauCorners, plateauCorners);
        }

        public void AddVehicle(string vehicleType)
        {
            int numVehicle = _userInterface.GetNumVehicle(vehicleType, _plateauMaxCoordinates[0], _plateauMaxCoordinates[1]);

            for (int i = 0; i < numVehicle; i++)
            {
                int[] vehicleInitPos = _userInterface.GetVehicleInitPos(AddOrdinal(i + 1), vehicleType);
                string vehicleInitFacing = _userInterface.GetVehicleInitFacing(AddOrdinal(i + 1), vehicleType);

                ListMarsRovers.Add(new MarsRover(vehicleInitPos[0], vehicleInitPos[1], vehicleInitFacing, $"MR{i}", vehicleType));

                ManageVehicleAction(i, vehicleType);
            }
        }

        public void ManageVehicleAction(int vehicleNum, string vehicleType)
        {
            string vehicleMoveIns = _userInterface.GetVehicleMovement(AddOrdinal(vehicleNum + 1), vehicleType);
            MoveVehicle(vehicleNum, vehicleType, vehicleMoveIns);
        }

        public void MoveVehicle(int vehicleNum, string vehicleType, string vehicleMoveIns)
        {
            foreach (char singleMoveIns in vehicleMoveIns)
            {
                switch (singleMoveIns)
                {
                    case 'L':
                        ListMarsRovers[vehicleNum].SpinsLeft();
                        break;
                    case 'R':
                        ListMarsRovers[vehicleNum].SpinsRight();
                        break;
                    case 'M':
                        string marsRoverPosFacing = ListMarsRovers[vehicleNum].GetCurrentPosAndFacing();
                        int newX = marsRoverPosFacing[0] - '0'; //"-'0'" to change char to int
                        int newY = marsRoverPosFacing[2] - '0';

                        switch (marsRoverPosFacing[4])
                        {
                            case 'E':
                                newX++;
                                break;
                            case 'S':
                                newY--;
                                break;
                            case 'W':
                                newX--;
                                break;
                            case 'N':
                                newY++;
                                break;
                        }

                        if (_plateau.IsEmptyPos(newX, newY))
                        {
                            if (!_plateau.IsOutOfBoundaryPos(newX, newY))
                            {
                                _plateau.RemoveObstacle(vehicleType, marsRoverPosFacing[0] - '0', marsRoverPosFacing[2] - '0');
                                ListMarsRovers[vehicleNum].MoveOneStepForward();
                                _plateau.AddObstacle(vehicleType, newX, newY);
                            }
                        }
                        break;
                }
            }
        }

        public void DisplayAllVehiclePos(string vehicleType)
        {
            Console.WriteLine($"\nThe {vehicleType} coordinates and facing are:");
            foreach (MarsRover marsRover in ListMarsRovers)
            {
                Console.WriteLine(marsRover.GetCurrentPosAndFacing());
            }
        }

        public static string AddOrdinal(int vehicleNum)
        {
            if (vehicleNum <= 0) return vehicleNum.ToString();

            switch (vehicleNum % 100)
            {
                case 11:
                case 12:
                case 13:
                    return vehicleNum + "th";
            }

            switch (vehicleNum % 10)
            {
                case 1:
                    return vehicleNum + "st";
                case 2:
                    return vehicleNum + "nd";
                case 3:
                    return vehicleNum + "rd";
                default:
                    return vehicleNum + "th";
            }
        }

        public int GetNumPlateauCorners()
        {
            return _plateau.NumPlateauCorners;
        }
    }
}