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

        public string GetCurrentPosAndFacing()
        {
            return $"{PosX} {PosY} {Facing}";
        }

        public void SpinsLeft()
        {
            switch(Facing)
            { 
                case "E":
                    Facing = "N";
                    break;
                case "N":
                    Facing = "W";
                    break;
                case "W":
                    Facing = "S";
                    break;
                case "S":
                    Facing = "E";
                    break;
            }
        }

        public void SpinsRight()
        {
            switch (Facing)
            {
                case "E":
                    Facing = "S";
                    break;
                case "S":
                    Facing = "W";
                    break;
                case "W":
                    Facing = "N";
                    break;
                case "N":
                    Facing = "E";
                    break;
            }
        }
        
    }
}