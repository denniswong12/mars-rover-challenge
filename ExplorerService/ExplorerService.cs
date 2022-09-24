using ExplorerService;

//string s = $"Now = {DateTime.Now,24:dd HH:mm:ss}, y = {y,12:#,##0.00}";
//Console.WriteLine($"{"abc",5} {"ddd",10} {"neiaddf",10}");
var commandCenter = new CommandCenter();
commandCenter.InitEnvironment();
commandCenter.AddVehicle("Mars Rover");
commandCenter.DisplayAllVehiclePos("Mars Rover");