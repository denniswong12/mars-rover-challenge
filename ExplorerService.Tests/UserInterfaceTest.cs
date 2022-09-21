﻿namespace ExplorerService.Tests;

public class UserInterfaceTests
{
    private UserInterface _userInterface;

    [SetUp]
    public void Setup()
    {
        _userInterface = new UserInterface();
    }

    [Test]
    public void Given_User_Input_5_5_Of_The_Plateau_Corner_Coordinates_Should_Return_int_array_5_5()
    {
        var plateauCornerCoordinates = "5 5";
        int[] expectedCoordinates = new int[] { 5, 5 };
        Console.SetIn(new StringReader(plateauCornerCoordinates));
        CollectionAssert.AreEqual(expectedCoordinates, _userInterface.GetPlateauCornersCoordinates());
    }

    [Test]
    public void Given_User_Input_2_As_The_Number_Of_Vehicles_Should_Return_2()
    {
        var vehicleTypeNum = "2";
        var PlateauCornersCoordinateX = 5;
        var PlateauCornersCoordinateY = 5;
        Console.SetIn(new StringReader(vehicleTypeNum));
        _userInterface.GeNumtVehicle("Mars Rover(s)", PlateauCornersCoordinateX, PlateauCornersCoordinateY).Should().Be(2);
    }

    [Test]
    public void Given_User_Input_2_1_Of_The_Initial_Coordinates_Of_A_Vehicles_Should_Return_2_1()
    {
        var vehicleInitCoordinates = "2 1";
        int[] expectedCoordinates = new int[] { 2, 1 };
        Console.SetIn(new StringReader(vehicleInitCoordinates));
        CollectionAssert.AreEqual(expectedCoordinates, _userInterface.GetVehicleInitPos("1st", "Mars Rover"));
    }

    [Test]
    public void Given_User_Input_N_Of_The_Initial_Facing_Of_A_Vehicles_Should_Return_N()
    {
        Console.SetIn(new StringReader("N"));
        _userInterface.GetVehicleInitFacing("1st", "Mars Rover").Should().Be("N");
    }

    [TestCase("L")]
    [TestCase("LMLMLMLMM")]
    [TestCase("MMRMMRMRRM")]
    public void Given_User_Input_For_Vehicle_Moving_Instructions_Should_Return_The_Same_Moving_Instructions(string moveInstructions)
    {
        Console.SetIn(new StringReader(moveInstructions));
        _userInterface.GetVehicleMovement("1st", "Mars Rover").Should().Be(moveInstructions);
    }

    [Test]
    public void Caller_Pass_In_Vehicles_Information_Should_Display_The_Same_On_Console()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _userInterface.DisplayVehiclePosAndFacing("1 3 N\n5 1 E");
        Assert.That(stringWriter.ToString(), Is.EqualTo($"1 3 N\n5 1 E\n"));
    }
}