namespace ExplorerService
{
    public interface IVehicle
    {
        public string GetVehicleID();
        public string GetCurrentPosAndFacing();
        public void SpinsLeft();
        public void SpinsRight();
        public void MoveOneStepForward();
        public void SetVehicleID(string vehicleID);
        public void MoveSidewayLeft();
        public void MoveSidewayRight();
        public void MoveBackward();
        public void Fly();
    }
}