using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace ExplorerService.Tests;

public class CommandCenterTests
{
    private CommandCenter _commandCenter;

    [SetUp]
    public void Setup()
    {
        _commandCenter = new CommandCenter();
        //Can't test after changing ListMarsRovers to private in CommandCenter.cs
        //_commandCenter.ListMarsRovers.Add(new MarsRover(3, 4, "N", $"MR0", "Mars Rover"));
    }

    [Test]
    public void Calling_InitEnvironment_Should_Initiate_A_Plateau()
    {
        _commandCenter.InitEnvironment();
        Console.SetIn(new StringReader("5 5"));
        _commandCenter.GetNumPlateauCorners().Should().Be(4);
    }

/*
    [Test]
    public void Calling_MoveVehicle_Given_Instruction_L_Should_Spins_The_Vehicle_Left()
    {
        _commandCenter.MoveVehicle(0, "Mars Rover", "L");
        _commandCenter.ListMarsRovers[0].GetCurrentPosAndFacing().Should().Be("3 4 W");
    }

    [Test]
    public void Calling_MoveVehicle_Given_Instruction_R_Should_Spins_The_Vehicle_Right()
    {
        _commandCenter.MoveVehicle(0, "Mars Rover", "R");
        _commandCenter.ListMarsRovers[0].GetCurrentPosAndFacing().Should().Be("3 4 E");
    }
*/
}