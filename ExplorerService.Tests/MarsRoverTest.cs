namespace ExplorerService.Tests;

public class MarsRoverTests
{
    private MarsRover _marsRover;

    [SetUp]
    public void Setup()
    {
        _marsRover = new MarsRover(3, 1, "S", "M0001", "MarsRover");
    }

    [Test]
    public void Get_Vehicle_ID_Should_Return_This_Vehicles_ID()
    {
        _marsRover.GetVehicleID().Should().Be("M0001");
    }
}