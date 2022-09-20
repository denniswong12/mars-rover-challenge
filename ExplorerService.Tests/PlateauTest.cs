namespace ExplorerService.Tests;

public class PlateauTests
{
    private Plateau _plateau;

    [SetUp]
    public void Setup()
    {
        List<int> plateauCornersCoordinates = new List<int> { 0, 0, 0, 6, 6, 6, 6, 0 };
        _plateau = new Plateau(4, plateauCornersCoordinates);
    }

/*
    [Test]
    public void GivenPlateauSizeAndNumberOfPointsShouldBeAbleToCreateAPlateau()
    {
        _plateau.NumPlateauCorners.Should().Be(4);
    }
*/

    [Test]
    public void CheckCoordinatesWithEmptyObstaclesSholdReturnTrue()
    {
        _plateau.IsEmptyPos(0, 0).Should().Be(true);
    }

    [Test]
    public void AddObstacleWithGivenObstacleTypeAndCoordinatesShouldReturnFalseWhenCallingIsEmptyPosOnTheSameCoordinates()
    {
        _plateau.AddObstacle("MarsRover", 0, 1);
        _plateau.IsEmptyPos(0, 1).Should().Be(false);
    }

    [Test]
    public void RemoveObstacleWithGivenObstacleTypeAndCoordinatesShouldReturnTrueWhenCallingIsEmptyPosOnTheSameCoordinates()
    {
        _plateau.RemoveObstacle("MarsRover", 0, 1);
        _plateau.IsEmptyPos(0, 1).Should().Be(true);
    }

    [Test]
    public void GivenCoordinatesOfAPointNotOnThePlateausBoundaryShouldReturnFalse()
    {
        _plateau.IsBoundaryPos(1, 1).Should().Be(false);
    }

    [TestCase(0, 6)]
    [TestCase(1, 6)]
    [TestCase(6, 3)]
    [TestCase(0, 0)]
    [TestCase(6, 6)]
    public void GivenCoordinatesOfAPointOnThePlateausBoundaryShouldReturnTrue(int x, int y)
    {
        _plateau.IsBoundaryPos(x, y).Should().Be(true);
    }    
}