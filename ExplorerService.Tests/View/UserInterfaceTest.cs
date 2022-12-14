namespace ExplorerService.Tests;

public class UserInterfaceTests
{
    private UserInterface _userInterface;

    [SetUp]
    public void Setup()
    {
        _userInterface = new UserInterface();
    }

    [Test]
    public void Given_User_Input_Vertices_Of_The_Triangle_Plateau_Corner_Coordinates_Should_Return_Int_Array_Containing_Vertices()
    {
        var plateauCornerCoordinates = "0 0 5 5 10 0";
        List<int> expectedCoordinates = new List<int> { 0, 0, 5, 5, 10, 0 };
        Console.SetIn(new StringReader(plateauCornerCoordinates));
        CollectionAssert.AreEqual(expectedCoordinates, _userInterface.GetPlateauVerticesCoordinates(2));
    }

    [Test]
    public void Given_User_Input_Two_As_The_Number_Of_Vehicles_Should_Return_Two()
    {
        Console.SetIn(new StringReader("2"));
        _userInterface.GetNumVehicle("Mars Rover(s)", 36).Should().Be(2);
    }

    [Test]
    public void Given_User_Input_One_As_The_Shape_Of_Plateau_Should_Return_One()
    {
        Console.SetIn(new StringReader("1"));
        _userInterface.GetPlateauShape().Should().Be(1);
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

    [Test]
    public void Given_User_Input_Y_To_Have_Some_Obstacles_Should_Return_True_To_Caller()
    {
        Console.SetIn(new StringReader("Y"));
        _userInterface.GetGenerateObstacle("Alien").Should().Be(true);
    }

    [Test]
    public void Caller_Pass_In_Obstacles_Information_Should_Display_The_Same_On_Console()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        _userInterface.DisplayToConsole("Rock 1 3 N\nAliens 5 1 E");
        Assert.That(stringWriter.ToString(), Is.EqualTo($"Rock 1 3 N\nAliens 5 1 E\n"));
    }
}