namespace ExplorerService
{
    public class Vehicle : IVehicle
    {
        protected int PosX { get; private set; }
        protected int PosY { get; private set; }
        protected string Facing { get; private set; }
        protected string VehicleID { get; private set; }
        protected string VehicleType { get; private set; }

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

        public void MoveOneStepForward()
        {
            switch (Facing)
            {
                case "E":
                    PosX++;
                    break;
                case "S":
                    PosY--;
                    break;
                case "W":
                    PosX--;
                    break;
                case "N":
                    PosY++;
                    break;
            }
        }

        public void SetVehicleID(string vehicleID)
        {
            //This method is for future expansion
        }

        public void MoveSidewayLeft()
        {
            //This method is for future expansion
        }

        public void MoveSidewayRight()
        {
            //This method is for future expansion
        }

        public void MoveBackward()
        {
            //This method is for future expansion
        }

        public void Fly()
        {
            //This method is for future expansion
        }
    }
}