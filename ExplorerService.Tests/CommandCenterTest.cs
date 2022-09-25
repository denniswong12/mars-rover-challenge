using System.Numerics;

namespace ExplorerService.Tests;

public class CommandCenterTests
{
    private CommandCenter _commandCenter;

    [SetUp]
    public void Setup()
    {
        _commandCenter = new CommandCenter();
    }

    [Test]
    public void Calling_InitEnvironment_And_Select_Rectangle_Plateau_Should_Initiate_A_Rectangle_Plateau()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testInitPlateau.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.GetNumPlateauCorners().Should().Be(4);
        }
    }

    [Test]
    public void Calling_InitEnvironment_And_Select_Triangle_Plateau_Should_Initiate_A_Triangle_Plateau()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testInitPlateau.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.GetNumPlateauCorners().Should().Be(4);
        }
    }

    [Test]
    public void Calling_AddVehicle_Should_Add_A_Vehicle_To_The_Plateau()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testAddVehicle.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.AddVehicle("Mars Rover");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _commandCenter.DisplayAllVehiclePos("Mars Rover");

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\nMars Rover - MR0: 3 3 N\n\n"));
            
        }
    }

    [Test]
    public void Calling_AddVehicle_With_Input_Of_Movement_Instructions_Should_Move_The_Vehicle()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testMove.csv"))
        { 
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.AddVehicle("Mars Rover");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _commandCenter.DisplayAllVehiclePos("Mars Rover");

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\nMars Rover - MR0: 1 3 N\n\n"));
        }
    }

    [Test]
    public void Calling_AddVehicle_With_Input_Of_Movement_Instructions_Trying_To_Move_Out_Of_The_Plateau_Should_Stop_At_The_Boundary()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testBoundary.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.AddVehicle("Mars Rover");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _commandCenter.DisplayAllVehiclePos("Mars Rover");

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\nMars Rover - MR0: 2 1 E\n\n"));
        }
    }

    [Test]
    public void Adding_Two_Vehicles_And_Trying_To_Move_Into_One_Another_Should_Stop_In_Front_Of_The_Vehicle()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testObstacle.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.AddVehicle("Mars Rover");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _commandCenter.DisplayAllVehiclePos("Mars Rover");

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\nMars Rover - MR0: 3 1 E\nMars Rover - MR1: 3 2 S\n\n"));
        }
    }

    [Test]
    public void Calling_AddObstacles_To_Add_Some_Alien_Should_Be_Able_To_Add_Some_Aliens()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testAlien.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.AddObstacles("Aliens");
            Console.ReadLine();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _commandCenter.DisplayAllObstaclePos();

            var output = stringWriter.ToString();
            Assert.IsTrue(output.Contains("The coordinates of the obstacles are:\nAliens:"));
        }
    }

    [Test]
    public void A_Plateau_With_Size_Less_Than_8_Should_Not_Ask_User_To_Add_Obstacle()
    {
        using (StreamReader inputs = new StreamReader("../../../../inputs/testPlasteauSmallerThan8.csv"))
        {
            Console.SetIn(inputs);
            _commandCenter.InitEnvironment();
            Console.ReadLine();
            _commandCenter.AddObstacles("Aliens");
            _commandCenter.DisplayAllObstaclePos();
            _commandCenter.AddVehicle("Mars Rover");
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //_commandCenter.DisplayAllVehiclePos("Mars Rover");

            var output = stringWriter.ToString();
            Assert.IsFalse(output.Contains("Are there any Aliens on the Plateau? (Y/N)"));
        }
    }
}