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
        _commandCenter.InitEnvironment();
        Console.SetIn(new StringReader("5 5"));
        _commandCenter.GetNumPlateauCorners().Should().Be(4);
    }
}