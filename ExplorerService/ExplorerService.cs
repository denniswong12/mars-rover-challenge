using ExplorerService;

var commandCenter = new CommandCenter();
commandCenter.InitEnvironment();
commandCenter.AddObstacles("Aliens");
commandCenter.AddObstacles("Rocks");
commandCenter.DisplayAllObstaclePos();
commandCenter.AddVehicle("Mars Rover");
commandCenter.DisplayAllVehiclePos("Mars Rover");