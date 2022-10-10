namespace ExplorerService
{
    public class MarsRover : Vehicle
    {
        public MarsRover(int x, int y, string facing, string vehicleID, string vehicleType) : base(x: x, y: y, facing: facing, vehicleID: vehicleID, vehicleType: vehicleType)
        {
        }

        public void ArmControl()
        {
            //This method is for future expansion
        }

        public void CameraControl()
        {
            //This method is for future expansion
        }
    }
}