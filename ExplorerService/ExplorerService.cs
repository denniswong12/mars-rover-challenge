using ExplorerService;

var commandCenter = new CommandCenter();
commandCenter.InitEnvironment();
commandCenter.AddVehicle("Mars Rover");
commandCenter.DisplayAllVehiclePos("Mars Rover");