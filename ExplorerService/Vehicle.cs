namespace ExplorerService
{
    public class Vehicle : IVehicle
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public string Facing { get; private set; }
        public string VehicleID { get; private set; }
        public string VehicleType { get; private set; }

        public Vehicle(int x, int y, string facing, string vehicleID, string vehicleType)
        {
            PosX = x;
            PosY = y;
            Facing = facing;
            VehicleID = vehicleID;
            VehicleType = vehicleType;
        }

        public string GetVehicleID()
        {
            return VehicleID;
        }
    }
}