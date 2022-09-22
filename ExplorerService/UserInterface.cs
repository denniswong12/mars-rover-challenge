namespace ExplorerService
{
    public class UserInterface
    {
        public int[] GetPlateauCornersCoordinates()
        {
            Console.WriteLine("Please enter the upper right hand corner coordinates of the Plateau in the format \"x y\":");
            var plateauMaxCoordinates = Console.ReadLine();
            if (!(plateauMaxCoordinates==null))
            {
                int plateauMaxX;
                int plateauMaxY;
                string[] plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                
                while (plateauCoordinatesStr.Count() != 2 || !(Int32.TryParse(plateauCoordinatesStr[0], out plateauMaxX)) || plateauMaxX < 0 || !(Int32.TryParse(plateauCoordinatesStr[1], out plateauMaxY)) || plateauMaxY < 0)
                {
                    Console.WriteLine("Please enter the upper right hand corner coordinates of the Plateau in the format \"x y\":");
                    plateauMaxCoordinates = Console.ReadLine();
                    if (!(plateauMaxCoordinates == null))
                        plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                }
                return (new int[] { plateauMaxX, plateauMaxY });
            }
            else
                return new int[] { -1, -1 };
        }

        public int GetNumVehicle(string vehicleType, int PlateauCornersCoordinateX, int PlateauCornersCoordinateY)
        {
            //Assume Plateau is a rectangle
            int maxNumVehicle = PlateauCornersCoordinateX * PlateauCornersCoordinateY;
            Console.WriteLine($"Please enter the number of {vehicleType}, please note that the maximum number of {vehicleType} is {maxNumVehicle} due to the limitation of the Plateau's size.");
            var numVehiclesStr = Console.ReadLine();
            if (!(numVehiclesStr == null))
            {
                int numVehicles = 0;
                while (!(Int32.TryParse(numVehiclesStr, out numVehicles)) || numVehicles < 0)
                {
                    Console.WriteLine($"Please enter the number of {vehicleType}, please note that the maximum number of {vehicleType} is {maxNumVehicle} due to the limitation of the Plateau's size.");
                    numVehiclesStr = Console.ReadLine();
                }
                return numVehicles;
            }
            else
                return 0;
        }

        public int[] GetVehicleInitPos(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the coordinates of the {vehicleNum} {vehicleType} in the format of \"x y\":");
            var vehicleCoordinates = Console.ReadLine();
            if (!(vehicleCoordinates == null))
            {
                int vehicleCoordinateX;
                int vehicleCoordinateY;
                string[] vehicleCoordinatesStr = vehicleCoordinates.Split(' ');

                while (vehicleCoordinatesStr.Count() != 2 || !(Int32.TryParse(vehicleCoordinatesStr[0], out vehicleCoordinateX)) || vehicleCoordinateX < 0 || !(Int32.TryParse(vehicleCoordinatesStr[1], out vehicleCoordinateY)) || vehicleCoordinateY < 0)
                {
                    Console.WriteLine($"Please enter the coordinates of the {vehicleNum} {vehicleType} in the format of \"x y\":");
                    vehicleCoordinates = Console.ReadLine();
                    if (!(vehicleCoordinates == null))
                        vehicleCoordinatesStr = vehicleCoordinates.Split(' ');
                }
                return (new int[] { vehicleCoordinateX, vehicleCoordinateY });
            }
            else
                return new int[] { -1, -1 };
        }

        public string GetVehicleInitFacing(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the facing of the {vehicleNum} {vehicleType} (e.g. N for North, E for East, S for South, W for West):");
            var vehicleFacing= Console.ReadLine();
            if (!(vehicleFacing == null))
            {
                vehicleFacing = vehicleFacing.ToUpper();
                while ( !(vehicleFacing=="N" || vehicleFacing=="E" || vehicleFacing=="S" || vehicleFacing=="W") )
                {
                    Console.WriteLine($"Please enter the facing of the {vehicleNum} {vehicleType} (e.g. N for North, E for East, S for South, W for West):");
                    vehicleFacing = Console.ReadLine();
                    if (!(vehicleFacing == null))
                        vehicleFacing = vehicleFacing.ToUpper();
                }
                return vehicleFacing;
            }
            else
                return "Invalid Facing";
        }

        public string GetVehicleMovement(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the instruction(s) to move the {vehicleNum} {vehicleType}, L for spins left, R for spins right, M for move forward  (e.g. LMRMMLLM). The {vehicleType} will stop and ignore the rest of the instruction(s) when it try to move to an obstacle or try to move out of the Plateau:");
            var vehicleMoveIns = Console.ReadLine();
            if (!(vehicleMoveIns == null))
            {
                vehicleMoveIns = vehicleMoveIns.ToUpper();
                while (!(ValidateMoveInstruction(vehicleMoveIns)))
                {
                    Console.WriteLine($"Please enter the instruction(s) to move the {vehicleNum} {vehicleType}, L for spins left, R for spins right, M for move forward  (e.g. LMRMMLLM). The {vehicleType} will stop and ignore the rest of the instruction(s) when it try to move to an obstacle or try to move out of the Plateau:");
                    vehicleMoveIns = Console.ReadLine();
                    if (!(vehicleMoveIns == null))
                        vehicleMoveIns = vehicleMoveIns.ToUpper();
                }
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

        public void DisplayVehiclePosAndFacing(string marsRoverPosAndFacing)
        {
            Console.WriteLine(marsRoverPosAndFacing);
        }
    }
}