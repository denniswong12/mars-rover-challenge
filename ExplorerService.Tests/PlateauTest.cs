namespace ExplorerService.Tests;

public class PlateauTests
{
    private Plateau _plateau;
    private CommandCenter _commandCenter;

    [SetUp]
    public void Setup()
    {
        List<int> plateauCornersCoordinates = new List<int> { 0, 0, 0, 5, 5, 5, 5, 0 };
        _plateau = new Plateau(4, plateauCornersCoordinates);
        _commandCenter = new CommandCenter();
    }


    [Test]
    public void GivenPlateauSizeAndNumberOfPointsShouldBeAbleToCreateAPlateau()
    {
        _plateau.NumPlateauCorners.Should().Be(4);
    }

    [Test]
    public void CheckCoordinatesWithEmptyObstaclesSholdReturnTrun()
    {
        _plateau.IsEmptyPos(0,0).Should().Be(true);
    }
}