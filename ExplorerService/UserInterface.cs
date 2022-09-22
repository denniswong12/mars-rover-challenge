using ExplorerService;

namespace ExplorerService
{
    public class UserInterface
    {
        public int[] GetPlateauCornersCoordinates()
        {
            Console.WriteLine("Please enter the upper right hand corner coordinates of the Plateau in the format \"x y\":");
            var plateauMaxCoordinates = Console.ReadLine();
            if (!String.IsNullOrEmpty(plateauMaxCoordinates))
            {
                string[] plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                int[] plateauCoordinates = new int[] { Int32.Parse(plateauCoordinatesStr[0]), Int32.Parse(plateauCoordinatesStr[1]) };
                return plateauCoordinates;
            }
            else
                return new int[] { 0,0 };
        }

        public int GetNumVehicle(string vehicleType, int PlateauCornersCoordinateX, int PlateauCornersCoordinateY)
        {
            //Assume Plateau is a rectangle
            int maxNumVehicle = PlateauCornersCoordinateX * PlateauCornersCoordinateY;
            Console.WriteLine($"Please enter the number of {vehicleType}, please note that the maximum number of {vehicleType} is {maxNumVehicle} due to the limitation of the Plateau's size.");
            var numVehiclesStr = Console.ReadLine();
            if (!String.IsNullOrEmpty(numVehiclesStr))
                return Int32.Parse(numVehiclesStr);
            else
                return 0;
        }

        public int[] GetVehicleInitPos(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the coordinates of the {vehicleNum} {vehicleType} in the format of \"x y\":");
            var vehicleCoordinates = Console.ReadLine();
            if (!String.IsNullOrEmpty(vehicleCoordinates))
            {
                string[] vehicleCoordinatesStr = vehicleCoordinates.Split(' ');
                int[] vehicleCoordinatesInt = new int[] { Int32.Parse(vehicleCoordinatesStr[0]), Int32.Parse(vehicleCoordinatesStr[1]) };
                return vehicleCoordinatesInt;
            }
            else
                return new int[] { -1, -1 };
        }

        public string GetVehicleInitFacing(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the facing of the {vehicleNum} {vehicleType} (e.g. N for North, E for East, S for South, W for West):");
            var vehicleFacing= Console.ReadLine();
            if (!String.IsNullOrEmpty(vehicleFacing))
                return vehicleFacing;
            else
                return "Invalid Facing";
        }

        public string GetVehicleMovement(string vehicleNum, string vehicleType)
        {
            Console.WriteLine($"Please enter the instruction(s) to move the {vehicleNum} {vehicleType}, L for spins left, R for spins right, M for move forward  (e.g. LMRMMLLM). The {vehicleType} will stop and ignore the rest of the instruction(s) when it try to move to an obstacle or try to move out of the Plateau:");
            var vehicleMoveIns = Console.ReadLine();
            if (!String.IsNullOrEmpty(vehicleMoveIns))
                return vehicleMoveIns;
            else
                return "Invalid Instruction to Move";
        }

        public void DisplayVehiclePosAndFacing(string marsRoverPosAndFacing)
        {
            Console.WriteLine(marsRoverPosAndFacing);
        }
    }
}