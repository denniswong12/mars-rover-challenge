namespace ExplorerService.Tests;

public class TrianglePlateauTests
{
    private TrianglePlateau _plateau;

    [SetUp]
    public void Setup()
    {
        List<int> plateauCornersCoordinates = new List<int> { 0, 0, 6, 0, 6, 5};
        _plateau = new TrianglePlateau(3, plateauCornersCoordinates);
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
        _plateau.AddSingleObstacle("MarsRover", 0, 1);
        _plateau.IsEmptyPos(0, 1).Should().Be(false);
    }

    [Test]
    public void Remove_Obstacle_With_Given_ObstacleType_And_Coordinates_Should_Return_True_Whe_nCalling_IsEmptyPos_On_The_Same_Coordinates()
    {
        _plateau.RemoveObstacle("MarsRover", 0, 1);
        _plateau.IsEmptyPos(0, 1).Should().Be(true);
    }

    [TestCase(3, 1)]
    [TestCase(4, 2)]
    public void Given_Coordinates_Of_A_Point_Not_Out_Of_The_Plateaus_Boundary_Should_Return_False(int x, int y)
    {
        _plateau.IsOutOfBoundaryPos(x, y).Should().Be(false);
    }

    [TestCase(0, 6)]
    [TestCase(1, 6)]
    public void Given_Coordinates_Of_A_Point_Out_Of_The_Plateaus_Boundary_Should_Return_True(int x, int y)
    {
        _plateau.IsOutOfBoundaryPos(x, y).Should().Be(true);
    }

    [Test]
    public void Get_Plateau_Size_Should_Return_Its_Size()
    {
        _plateau.PlateauSize().Should().Be(15);
    }
}