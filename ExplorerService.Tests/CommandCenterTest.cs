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
    public void Calling_InitEnvironment_Should_Initiate_A_Plateau()
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
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\n3 3 N\n"));
            
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
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\n1 3 N\n"));
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
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\n2 1 E\n"));
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
            Assert.That(output, Is.EqualTo("\nThe Mars Rover coordinates and facing are:\n3 1 E\n3 2 S\n"));
        }
    }
}