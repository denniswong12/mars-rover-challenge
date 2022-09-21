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

    /* Not able to test after chaning NumPlateauCorners to "protected"
        [Test]
        public void Given_Plateau_Size_And_Number_Of_Points_Should_Be_Able_To_Create_A_Plateau()
        {
            _plateau.NumPlateauCorners.Should().Be(4);
        }
    */

    [Test]
    public void Check_Coordinates_With_Empty_Obstacles_Shold_Return_True()
    {
        _plateau.IsEmptyPos(0, 0).Should().Be(true);
    }

    [Test]
    public void Add_Obstacle_With_Given_ObstacleType_And_Coordinates_Should_Return_False_When_Calling_IsEmptyPos_On_The_Same_Coordinates()
    {
        _plateau.AddObstacle("MarsRover", 0, 1);
        _plateau.IsEmptyPos(0, 1).Should().Be(false);
    }

    [Test]
    public void Remove_Obstacle_With_Given_ObstacleType_And_Coordinates_Should_Return_True_Whe_nCalling_IsEmptyPos_On_The_Same_Coordinates()
    {
        _plateau.RemoveObstacle("MarsRover", 0, 1);
        _plateau.IsEmptyPos(0, 1).Should().Be(true);
    }

    [TestCase(1, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 2)]
    [TestCase(1, 4)]
    public void Given_Coordinates_Of_A_Point_Not_On_The_Plateaus_Boundary_Should_Return_False(int x, int y)
    {
        _plateau.IsBoundaryPos(x, y).Should().Be(false);
    }

    [TestCase(0, 6)]
    [TestCase(1, 6)]
    [TestCase(6, 3)]
    [TestCase(0, 0)]
    [TestCase(6, 6)]
    public void Given_Coordinates_Of_A_Point_On_The_Plateaus_Boundary_Should_Return_True(int x, int y)
    {
        _plateau.IsBoundaryPos(x, y).Should().Be(true);
    }    
}