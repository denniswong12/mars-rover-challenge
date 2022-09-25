namespace ExplorerService
{
    public class UserInterface
    {
        public void DisplayIntro()
        {
            Console.WriteLine("Please note the following when entering information:");
            Console.WriteLine("- All coordinates should be entered in the format \"x y\" where x and y are integers.");
            Console.WriteLine("- The lower left hand corner of the Plateau is (0,0), each coordinate of the upper right hand corner of the Plateau must be > or = 0.");
            Console.WriteLine("- You can have some Aliens or Rocks on the Plateau with the Plateau size > 8.");
            Console.WriteLine("- The initial position of a vehicle must be within the Plateau.");
            Console.WriteLine("- Due to the limitation of the Plateau's size, there is a maximum number of vehicle can be put on to the Plateau.");
            Console.WriteLine("- Only one character is needed when entering facing of a vehicle: N for North, E for East, S for South and W for West.");
            Console.WriteLine("- Instructions to move the vehicle are: L for spins left, R for spins right, M for move forward  (e.g. LMRMMLLM).");
            Console.WriteLine("  The vehicle will stop and ignore the rest of the instruction(s) when it try to move to an obstacle or try to move outside of the Plateau.\n");
        }

        public int GetPlateauShape()
        {
            int plateauShape;
            Console.WriteLine("Please select the shape of the Plateau (1-Rectangle, 2-Triangle)");
            var plateauShapeStr = Console.ReadLine();
            if (plateauShapeStr != null)
            {
                while (!(Int32.TryParse(plateauShapeStr, out plateauShape)) || plateauShape < 1 || plateauShape > 2)
                    plateauShapeStr = ReInputData("Please select the shape of the Plateau (1-Rectangle, 2-Triangle)");
                return (plateauShape);
            }
            else
                return -1;
        }

        public int[] GetPlateauCornersCoordinates()
        {
            Console.WriteLine("Please enter the upper right hand corner coordinates of the Plateau:");
            var plateauMaxCoordinates = Console.ReadLine();
            if (plateauMaxCoordinates != null)
            {
                int plateauMaxX;
                int plateauMaxY;
                string[] plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                
                while (plateauCoordinatesStr.Count() != 2 || !(Int32.TryParse(plateauCoordinatesStr[0], out plateauMaxX)) || plateauMaxX < 0 || !(Int32.TryParse(plateauCoordinatesStr[1], out plateauMaxY)) || plateauMaxY < 0)
                {
                    plateauMaxCoordinates = ReInputData($"Please enter the upper right hand corner coordinates of the Plateau:");
                    plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                }
                return (new int[] { plateauMaxX, plateauMaxY });
            }
            else
                return new int[] { -1, -1 };
        }

        public int GetNumVehicle(string vehicleType, int maxNumVehicle)
        {
            //Assume Plateau is a rectangle
            Console.WriteLine($"Please enter the number of {vehicleType} with maximum {maxNumVehicle}.");
            var numVehiclesStr = Console.ReadLine();
            if (numVehiclesStr != null)
            {
                int numVehicles = 0;
                while (!(Int32.TryParse(numVehiclesStr, out numVehicles)) || numVehicles < 0 || numVehicles > maxNumVehicle)
                {
                    UserErrInput();
                    Console.WriteLine($"Please enter the number of {vehicleType} with maximum {maxNumVehicle}.");
                    numVehiclesStr = Console.ReadLine();
                }
                return numVehicles;
            }
            else
                return 0;
        }

        public int[] GetVehicleInitPos(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the coordinates of the {vehicleNum} {vehicleType}:");
            var vehicleCoordinates = Console.ReadLine();
            if (vehicleCoordinates != null)
            {
                int vehicleCoordinateX;
                int vehicleCoordinateY;
                string[] vehicleCoordinatesStr = vehicleCoordinates.Split(' ');

                while (vehicleCoordinatesStr.Count() != 2 || !(Int32.TryParse(vehicleCoordinatesStr[0], out vehicleCoordinateX)) || vehicleCoordinateX < 0 || !(Int32.TryParse(vehicleCoordinatesStr[1], out vehicleCoordinateY)) || vehicleCoordinateY < 0)
                {
                    vehicleCoordinates = ReInputData($"Please enter the coordinates of the {vehicleNum} {vehicleType}:");
                    vehicleCoordinatesStr = vehicleCoordinates.Split(' ');
                }
                return (new int[] { vehicleCoordinateX, vehicleCoordinateY });
            }
            else
                return new int[] { -1, -1 };
        }

        public string GetVehicleInitFacing(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the facing of the {vehicleNum} {vehicleType} (N/E/S/W):");
            var vehicleFacing= Console.ReadLine();
            if (vehicleFacing != null)
            {
                vehicleFacing = vehicleFacing.ToUpper();
                while ( !(vehicleFacing=="N" || vehicleFacing=="E" || vehicleFacing=="S" || vehicleFacing=="W") )
                    vehicleFacing = ReInputData($"Please enter the facing of the {vehicleNum} {vehicleType} (N/E/S/W):");
                return vehicleFacing;
            }
            else
                return "Invalid Facing";
        }

        public string GetVehicleMovement(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the instruction(s) to move the {vehicleNum} {vehicleType} (e.g. LMRMMLLM):");
            var vehicleMoveIns = Console.ReadLine();
            if (vehicleMoveIns != null)
            {
                vehicleMoveIns = vehicleMoveIns.ToUpper();
                while (!(ValidateMoveInstruction(vehicleMoveIns)))
                    vehicleMoveIns = ReInputData($"Please enter the instruction(s) to move the {vehicleNum} {vehicleType} (e.g. LMRMMLLM):");
                return vehicleMoveIns;
            }
            else
                return "Invalid Instruction to Move";
        }

        bool ValidateMoveInstruction(string vehicleMoveIns)
        {
            string allowableMovement = "LRM";
            vehicleMoveIns = vehicleMoveIns.ToUpper();

            foreach (char c in vehicleMoveIns)
                if (!allowableMovement.Contains(c.ToString()))
                    return false;

             return true;
        }

        public bool GetGenerateObstacle(string obstacleType)
        {
            Console.WriteLine($"Are there any {obstacleType} on the Plateau? (Y/N):");
            var hasObstacles = Console.ReadLine();
            if (hasObstacles != null)
            {
                hasObstacles = hasObstacles.ToUpper();
                while (!(hasObstacles == "N" || hasObstacles == "Y"))
                    hasObstacles = ReInputData($"Are there any {obstacleType} on the Plateau? (Y/N):");
                return (hasObstacles=="Y");
            }
            else
                return false;
        }

        public string ReInputData(string msgToConsole)
        {
            UserErrInput();
            Console.WriteLine(msgToConsole);
            return (Console.ReadLine().ToUpper());
        }

        public void DisplayToConsole(string message)
        {
            Console.WriteLine(message);
        }

        private void UserErrInput()
        {
            Console.WriteLine("Invalid input, please enter again.");
        }

        public void DisplayVehiclePosAndFacing(string marsRoverPosAndFacing)
        {
            Console.WriteLine(marsRoverPosAndFacing);
        }
    }
}