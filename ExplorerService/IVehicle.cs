namespace ExplorerService
{
    public interface IVehicle
    {
        public string GetVehicleID();

        public int PosX { get; }
        public int PosY { get; }
        public string Facing { get; }
        public string VehicleID { get; }
        public string VehicleType { get; }
    }
}