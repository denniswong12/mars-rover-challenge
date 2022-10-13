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

    [Test]
    public void Get_Current_Coordinates_And_Facing_With_A_Given_Vehicle_ID_Should_Return_This_Vehicles_Coordinates_And_Facing()
    {
        _marsRover.GetCurrentPosAndFacing().Should().Be("3 1 S");
    }

    [Test]
    public void Given_Instruction_SpinsLeft_The_Vehicle_Should_Spins_Left()
    {
        _marsRover.SpinsLeft();
        _marsRover.GetCurrentPosAndFacing().Should().Be("3 1 E");
    }

    [Test]
    public void Given_Instruction_SpinsRight_The_Vehicle_Should_Spins_Right()
    {
        _marsRover.SpinsRight();
        _marsRover.GetCurrentPosAndFacing().Should().Be("3 1 W");
    }

    [Test]
    public void Given_Instruction_MoveForward_The_Vehicle_Should_Move_One_Step_Forward()
    {
        _marsRover.MoveOneStepForward();
        _marsRover.GetCurrentPosAndFacing().Should().Be("3 0 S");
    }
}