using ExplorerService;

namespace ExplorerService
{
    public class UserInterface
    {
        public int[] GetPlateauCornersCoordinates()
        {
            Console.WriteLine("Please enter the upper right hand corner coordinates of the Plateau:");
            var plateauMaxCoordinates = Console.ReadLine();
            if (!String.IsNullOrEmpty(plateauMaxCoordinates))
            {
                string[] plateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                int[] plateauCoordinates = new int[] { Int32.Parse(plateauCoordinatesStr[0]), Int32.Parse(plateauCoordinatesStr[1]) };
                return plateauCoordinates;
            }
            return new int[] { 0,0 };
        }

        public int GeNumtVehicle(string vehicleType)
        {
            Console.WriteLine($"Please enter the number of {vehicleType}:");
            var numVehiclesStr = Console.ReadLine();
            if (!String.IsNullOrEmpty(numVehiclesStr))
            {
                return Int32.Parse(numVehiclesStr);
            }
            return 0;
        }
    }
}