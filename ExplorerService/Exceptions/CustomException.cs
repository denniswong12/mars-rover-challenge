using System;
namespace ExplorerService
{
    [Serializable]
    public class VehicleMovementException : Exception
    {
        public VehicleMovementException()
        { }

        public VehicleMovementException(string message)
            : base(message)
        { }
    }
}
