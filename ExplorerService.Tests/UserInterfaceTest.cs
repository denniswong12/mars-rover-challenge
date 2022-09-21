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
    public void Get_User_Input_Of_The_Plateau_Corner_Coordinates_Should_Return_int_array_5_5()
    {
        var plateauCornerCoordinates = "5 5";
        int[] expectedCoordinates = new int[] { 5, 5 };
        Console.SetIn(new StringReader(plateauCornerCoordinates));
        CollectionAssert.AreEqual(expectedCoordinates, _userInterface.GetPlateauCornersCoordinates());
    }
}