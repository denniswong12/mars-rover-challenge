namespace ExplorerService
{
    public class CommandCenter
    {
        private Plateau _plateau;
        private int _minPlateauSizeHasObstacles = 8;
        private const int _numCorrdinates = 2;
        private UserInterface _userInterface = new UserInterface();
        private int[] _plateauMaxCoordinates = new int[_numCorrdinates];
        private List<MarsRover> _listMarsRovers = new List<MarsRover>();

        public void InitEnvironment()
        {
            _userInterface.DisplayIntro();
            _plateauMaxCoordinates = _userInterface.GetPlateauCornersCoordinates();
            List<int> plateauCorners = new List<int> { 0, 0, _plateauMaxCoordinates[0], 0, _plateauMaxCoordinates[0], _plateauMaxCoordinates[1], 0, _plateauMaxCoordinates[1] };
            int numPlateauCorners = plateauCorners.Count() / _numCorrdinates;
            _plateau = new Plateau(numPlateauCorners, plateauCorners, _plateauMaxCoordinates);
        }

        public void AddObstacles(string obstacleType)
        {
            if (_plateau.PlateauSize() > _minPlateauSizeHasObstacles && _userInterface.GetGenerateObstacle(obstacleType))
            {
                int obstacleX = 0;
                int obstacleY = 0;
                float maxObstaclesRatio = 0.2f;
                Random rnd = new Random();
                int numobstacle = 0;

                while (numobstacle <= 0)
                    numobstacle = rnd.Next((int)(_plateau.PlateauSize() * maxObstaclesRatio));
                    
                for (int i=0; i< numobstacle; i++)
                {
                    while (!(_plateau.IsEmptyPos(obstacleX, obstacleY)))
                    {
                        obstacleX = rnd.Next(_plateauMaxCoordinates[0]);
                        obstacleY = rnd.Next(_plateauMaxCoordinates[1]);
                    }
                    _plateau.AddObstacle(obstacleType, obstacleX, obstacleY);
                }
            }
        }

        public void AddVehicle(string vehicleType)
        {
            int numVehicle = _userInterface.GetNumVehicle(vehicleType, _plateau.PlateauSize());
            for (int i = 0; i < numVehicle; i++)
            {
                int[] vehicleInitPos = _userInterface.GetVehicleInitPos(AddOrdinal(i + 1), vehicleType);
                while (_plateau.IsOutOfBoundaryPos(vehicleInitPos[0], vehicleInitPos[1]) || !_plateau.IsEmptyPos(vehicleInitPos[0], vehicleInitPos[1]))
                {
                    Console.WriteLine($"The input coordinates is not empty or is out of the Plateau.");
                    vehicleInitPos = _userInterface.GetVehicleInitPos(AddOrdinal(i + 1), vehicleType);
                }
                string vehicleInitFacing = _userInterface.GetVehicleInitFacing(AddOrdinal(i + 1), vehicleType);

                _listMarsRovers.Add(new MarsRover(vehicleInitPos[0], vehicleInitPos[1], vehicleInitFacing, $"MR{i}", vehicleType));
                _plateau.AddObstacle(vehicleType, vehicleInitPos[0], vehicleInitPos[1]);
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
                        _listMarsRovers[vehicleNum].SpinsLeft();
                        break;
                    case 'R':
                        _listMarsRovers[vehicleNum].SpinsRight();
                        break;
                    case 'M':
                        string marsRoverPosFacing = _listMarsRovers[vehicleNum].GetCurrentPosAndFacing();
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
                                _listMarsRovers[vehicleNum].MoveOneStepForward();
                                _plateau.AddObstacle(vehicleType, newX, newY);
                            }
                            else
                            {
                                Console.WriteLine($"Stopped {vehicleType} at {marsRoverPosFacing[0] - '0'} {marsRoverPosFacing[2] - '0'} to avoid moving out of the Plateau.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Stopped {vehicleType} at {marsRoverPosFacing[0] - '0'} {marsRoverPosFacing[2] - '0'} to avoid collision.");
                        }
                        break;
                }
            }
        }

        public void DisplayAllVehiclePos(string vehicleType)
        {
            string disVehicles = $"\nThe {vehicleType} coordinates and facing are:\n";
            foreach (MarsRover marsRover in _listMarsRovers)
            {
                disVehicles += $"{vehicleType} - {marsRover.GetVehicleID()}: {marsRover.GetCurrentPosAndFacing()}\n";
            }
            _userInterface.DisplayToConsole(disVehicles);
        }

        public void DisplayAllObstaclePos()
        {
            List<string[]> obstacle = _plateau.RetrieveObstacles();
            if (obstacle.Count() > 0)
            {
                string disObstacles = $"\nThe coordinates of the obstacles are:\n";
                for (int i = 0; i < obstacle.Count(); i++)
                {
                    if (obstacle[i][0] != "Mars Rover")
                        disObstacles += $"{obstacle[i][0]}: {obstacle[i][1]} {obstacle[i][2]}\n";
                }
                _userInterface.DisplayToConsole(disObstacles);
            }
            else if (_plateau.PlateauSize() > _minPlateauSizeHasObstacles)
            {
                _userInterface.DisplayToConsole("There no obstacles generated.");
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