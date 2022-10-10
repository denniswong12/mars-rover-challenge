using System.Net.NetworkInformation;

namespace ExplorerService
{
    public class UserInterface
    {
        public void DisplayIntro()
        {
            Console.WriteLine("Please note the following when entering information:");
            Console.WriteLine("- All coordinates should be entered in the format \"x y\" where x and y are integers.");
            Console.WriteLine("- The lower left hand corner of the Plateau is (0, 0), all other coordinates of the of the Plateau must be > or = 0.");
            Console.WriteLine("- The Triangle Plateau with base lying on X - axis.");
            Console.WriteLine("- You can have some Aliens or Rocks on the Plateau with the Plateau size > 9.");
            Console.WriteLine("- The initial position of a vehicle must be within the Plateau.");
            Console.WriteLine("- Due to the limitation of the Plateau's size, there is a maximum number of vehicle can be put on to the Plateau.");
            Console.WriteLine("- Only one character is needed when entering facing of a vehicle: N for North, E for East, S for South and W for West.");
            Console.WriteLine("- Instructions to move the vehicle are: L for spins left, R for spins right, M for move forward  (e.g. LMRMMLLM).");
            Console.WriteLine("  The vehicle will stop and ignore the rest of the instruction(s) when it try to move to an obstacle or try to move outside of the Plateau.\n");
        }

        public int GetPlateauShape()
        {
            int plateauShape;
            string requestMsg = "Please select the shape of the Plateau (1-Rectangle, 2-Triangle)";
            Console.WriteLine(requestMsg);
            var plateauShapeStr = Console.ReadLine();
            if (plateauShapeStr != null)
            {
                while (!(Int32.TryParse(plateauShapeStr, out plateauShape)) || plateauShape < 1 || plateauShape > 2)
                    plateauShapeStr = ReInputData(requestMsg);
                return (plateauShape);
            }
            else
                return -1;
        }

        public List<int> GetPlateauVerticesCoordinates(int plateauShape)
        {
            string requestMsg = "Please enter all coordinates of the vertices of the Plateau starting from 0 0 (e.g. 0 0 8 0 4 5 for a triangle):";
            Console.WriteLine(requestMsg);
            var plateauMaxCoordinates = Console.ReadLine();
            if (plateauMaxCoordinates != null)
            {
                List<int> vertices = new List<int>();
                string[] plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');

                while (!ValidatePlateauVertices(plateauCoordinatesStr, plateauShape))
                {
                    plateauMaxCoordinates = ReInputData(requestMsg);
                    plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                }
                for (int i = 0; i < plateauCoordinatesStr.Count(); i++)
                    vertices.Add(Int32.Parse(plateauCoordinatesStr[i]));
                return vertices;
            }
            else
                return new List<int> { -1, -1 };
        }

        public int GetNumVehicle(string vehicleType, int maxNumVehicle)
        {
            string requestMsg = $"Please enter the number of {vehicleType} with maximum {maxNumVehicle}.";
            Console.WriteLine(requestMsg);
            var numVehiclesStr = Console.ReadLine();
            if (numVehiclesStr != null)
            {
                int numVehicles = 0;
                while (!(Int32.TryParse(numVehiclesStr, out numVehicles)) || numVehicles < 0 || numVehicles > maxNumVehicle)
                {
                    UserErrInput();
                    Console.WriteLine(requestMsg);
                    numVehiclesStr = Console.ReadLine();
                }
                return numVehicles;
            }
            else
                return 0;
        }

        public int[] GetVehicleInitPos(string vehicleNum, string vehicleType)
        {
            string requestMsg = $"Please enter the coordinates of the {vehicleNum} {vehicleType}:";
            Console.WriteLine(requestMsg);
            var vehicleCoordinates = Console.ReadLine();
            if (vehicleCoordinates != null)
            {
                int vehicleCoordinateX;
                int vehicleCoordinateY;
                string[] vehicleCoordinatesStr = vehicleCoordinates.Split(' ');

                while (vehicleCoordinatesStr.Count() != 2 || !(Int32.TryParse(vehicleCoordinatesStr[0], out vehicleCoordinateX)) || vehicleCoordinateX < 0 || !(Int32.TryParse(vehicleCoordinatesStr[1], out vehicleCoordinateY)) || vehicleCoordinateY < 0)
                {
                    vehicleCoordinates = ReInputData(requestMsg);
                    vehicleCoordinatesStr = vehicleCoordinates.Split(' ');
                }
                return (new int[] { vehicleCoordinateX, vehicleCoordinateY });
            }
            else
                return new int[] { -1, -1 };
        }

        public string GetVehicleInitFacing(string vehicleNum, string vehicleType)
        {
            string requestMsg = $"Please enter the facing of the {vehicleNum} {vehicleType} (N/E/S/W):";
            Console.WriteLine(requestMsg);
            var vehicleFacing= Console.ReadLine();
            if (vehicleFacing != null)
            {
                vehicleFacing = vehicleFacing.ToUpper();
                while ( !(vehicleFacing=="N" || vehicleFacing=="E" || vehicleFacing=="S" || vehicleFacing=="W") )
                    vehicleFacing = ReInputData(requestMsg);
                return vehicleFacing;
            }
            else
                return "Invalid Facing";
        }

        public string GetVehicleMovement(string vehicleNum, string vehicleType)
        {
            string requestMsg = $"Please enter the instruction(s) to move the {vehicleNum} {vehicleType} (e.g. MLMRMLMMM):";
            Console.WriteLine(requestMsg);
            var vehicleMoveIns = Console.ReadLine();
            if (vehicleMoveIns != null)
            {
                vehicleMoveIns = vehicleMoveIns.ToUpper();
                while (!(ValidateMoveInstruction(vehicleMoveIns)))
                    vehicleMoveIns = ReInputData(requestMsg);
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
            string requestMsg = $"Are there any {obstacleType} on the Plateau? (Y/N):";
            Console.WriteLine(requestMsg);
            var hasObstacles = Console.ReadLine();
            if (hasObstacles != null)
            {
                hasObstacles = hasObstacles.ToUpper();
                while (!(hasObstacles == "N" || hasObstacles == "Y"))
                    hasObstacles = ReInputData(requestMsg);
                return (hasObstacles=="Y");
            }
            else
                return false;
        }

        private bool ValidatePlateauVertices(String[] plateauCoordinatesStr, int plateauShape)
        {
            const int numCoordinates = 2;
            const int rectanglePlateau = 1;
            const int trianglePlateau = 2;
            const int numTriangleVertices = 3;
            const int numRectangleVertices = 4;
            int coordinate;

            if (!((plateauCoordinatesStr.Count() == numRectangleVertices * numCoordinates) || (plateauCoordinatesStr.Count() == numTriangleVertices * numCoordinates))
                || ((plateauShape == rectanglePlateau) && (plateauCoordinatesStr.Count() != numRectangleVertices * numCoordinates))
                || ((plateauShape == trianglePlateau) && (plateauCoordinatesStr.Count() != numTriangleVertices * numCoordinates)))
                return false;

            for (int i = 0; i < plateauCoordinatesStr.Count(); i++)
            {
                if (!(Int32.TryParse(plateauCoordinatesStr[i], out coordinate)) || coordinate < 0)
                    return false;
            }
            return true;
        }

        public string ReInputData(string msgToConsole)
        {
            UserErrInput();
            DisplayToConsole(msgToConsole);
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