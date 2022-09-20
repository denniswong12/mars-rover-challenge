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
    public void CheckCoordinatesWithEmptyObstaclesSholdReturnTrue()
    {
        _plateau.IsEmptyPos(0, 0).Should().Be(true);
    }

    [Test]
    public void GivenCoordinatesOfAPointNotOnThePlateausBoundaryShouldReturnFalse()
    {
        _plateau.IsBoundaryPos(1, 1).Should().Be(false);
    }

    [Test]
    public void GivenCoordinatesOfAPointOnThePlateausBoundaryShouldReturnTrue()
    {
        _plateau.IsBoundaryPos(1, 0).Should().Be(true);
    }
}