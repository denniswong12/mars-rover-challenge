namespace ExplorerService
{
    public class Vehicle : IVehicle
    {
        public bool IsAsleep { get; private set; }
        public int AverageHeight { get; private set; }
        public string Setting { get; private set; }

        protected Vehicle(int averageHeight, string setting)
        {
            AverageHeight = averageHeight;
            Setting = setting;
        }

        public abstract string Eat();

        public void GoToSleep()
        {
            IsAsleep = true;
        }

        public void WakeUp()
        {
            IsAsleep = false;
        }
    }
}