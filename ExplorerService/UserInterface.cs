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
                string[] PlateauCoordinatesStr = plateauMaxCoordinates.Split(' ');
                int[] PlateauCoordinates = new int[] { Int32.Parse(PlateauCoordinatesStr[0]), Int32.Parse(PlateauCoordinatesStr[1]) };
                return PlateauCoordinates;
            }
            return new int[] { 0,0 };
        }
    }
}