# Mars Explorers Control System

- In this system, the surface of Mars is represented by a rectangular Plateau, starting from coordinate (0,0), following the x-axis and y-axis, user can define the size of it by entering the coordinate of the upper right hand corner of the Plateau.
- On the Plateau with size bigger than 8, user can choose to randomly place some rocks and some aliens!
- User can also add some Mars Rovers onto the Plateau, remember those Rovers can’t overlap with each other and of course not over the obstacles. The Rovers can’t be put outside of the Plateau as well.
- When adding the Rovers, user need to specify the coordinate and the facing of it. The facing can be marked by:
    - N : North
    - E : East
    - S : South
    - W : West
- After adding a Rover, user can give instruction to move the Rover, the available instructions are:
    - L : Spins Left
    - R : Spins Right
    - M : Move one step forward
- Only one Rover will move at a time, when a Rover move to the edge of the Plateau, the Rover will stop and then ignore the rest of the instructions. When a Rover trying to move in to another Rover or an obstacle, the Rover will stop and ignore the rest of the instructions.
- After moving all Rovers, the system will show the location of each Rover.
- Different Rovers navigate the Plateau so they can use their special cameras and robot arms to collect samples back to Planet Earth.

## What’s in this System

The system is written in C#, with git as version control and store the source codes in GitHub - https://github.com/denniswong12/mars-rover-challenge.git. Design using UML Class Diagram with 5 classes and 1 interface. The interface and the classes and their features are:

Class - CommandCenter:
- Initialise the plateau.
- Call Plateau to add vehicle onto the plateau.
- Trigger vehicle to move.
- Request display vehicle positions.

Class - UserInterface:
- Get plateau coordinates from user via console input.
- Get vehicle coordinates and facing from user via console input.
- Get vehicle movement instructions from user via console input.
- Display coordinates and facing of all vehicles on console.

Class - Plateau:
- Instantiate the plateau object.
- Check the given coordinates is free of obstacle or not.
- Check the given coordinates is out of the boundary of the plateau or not.
- Add obstacle/vehicle on the plateau.
- Remove obstacle/vehicle from the plateau.

Interface - IVehicle
Base Class - Vehicle 
Subclass - MarsRover:
- Instantiate MarsRover object.
- Hold the vehicle ID and type of the MarsRover object.
- Allow change vehicle ID after instantiated the MarsRover object.
- Hold the coordinates and facing of that MarsRover object.
- Actually spins left/right and move forward of the MarsRover object.
- Support further extension to move backward/sideway or even fly.
- Support further extension to control camera and the robot arm to capture samples.


## How to Run

- This system is a Console application, can run using Visual Studio with .Net6.0+
- Example of the user interface:

Please note the following when entering information:
- All coordinates should be entered in the format "x y" where x and y are integers.
- The lower left hand corner of the Plateau is (0,0), each coordinate of the upper right hand corner of the Plateau must be > or = 0.
- You can have some Aliens or Rocks on the Plateau with the Plateau size > 8.
- The initial position of a vehicle must be within the Plateau.
- Due to the limitation of the Plateau's size, there is a maximum number of vehicle can be put on to the Plateau.
- Only one character is needed when entering facing of a vehicle: N for North, E for East, S for South and W for West.
- Instructions to move the vehicle are: L for spins left, R for spins right, M for move forward  (e.g. LMRMMLLM).
  The vehicle will stop and ignore the rest of the instruction(s) when it try to move to an obstacle or try to move outside of the Plateau.

Please enter the upper right hand corner coordinates of the Plateau:
3 5
Are there any Aliens on the Plateau? (Y/N):
Y
Are there any Rocks on the Plateau? (Y/N):
Y

The coordinates of the obstacles are:
Aliens: 0 0
Aliens: 2 1
Rocks: 1 0

Please enter the number of Mars Rover with maximum 24.
2
Please enter the coordinates of the 1st Mars Rover:
2 3
Please enter the facing of the 1st Mars Rover (N/E/S/W):
E
Please enter the instruction(s) to move the 1st Mars Rover (e.g. LMRMMLLM):
LMMRMMM
Please enter the coordinates of the 2nd Mars Rover:
1 2
Please enter the facing of the 2nd Mars Rover (N/E/S/W):
A
Invalid input, please enter again.
Please enter the facing of the 2nd Mars Rover (N/E/S/W):
W
Please enter the instruction(s) to move the 2nd Mars Rover (e.g. LMRMMLLM):
MMRMMLMR

The Mars Rover coordinates and facing are:
Mars Rover: 3 5 E
Mars Rover: 0 4 N

## Development framework
- The system was developed using Test Driven Development framework, starting from the simplest test cases with Arrange, Act and Assert approach to implement the classes. All test cases were starting from a fail case, then write the code to get the case pass and then refactor the code.
How to test
- To run all test cases, under the solution folder, user can type: dotnet test
- Or use the test feature in Visual Studio.

## Assumptions:
1. Assume the Plateau is rectangular grid.
2. Assume the Plateau is not a single point. 
3. If user doesn’t add obstacles, there are no rocks/aliens/etc on the Plateau stopping the rover to move.
4. Assume user input the number of Mars rovers.
5. All instructions can be successfully transmitted to the rover.
6. Every turn / move can be carried out successfully, with the following limitations:
    i. Rovers will not be able to move out of the boundaries of the Plateau.
    ii. The remaining instructions will be ignored after the rover is trying to move out of the boundaries of the Plateau.
    iii. Two or more rovers cannot stop/passing by the same location(i.e. same X and Y coordinates).
    iv. The remaining instructions will be ignored after the rover is trying to move into the position where already has another rover.
    v. Rovers move sequentially.

## What's Next?

With some modifications, it is possible to add the following features to the system:
- User can add Obstacles.
- Rover acknowledge after receiving an instruction.
    - How to implement: Modify class Vehicle and return acknowledgment after receiving any instructions.
- Rover able to move backward/sidewards.
    - How to implement: Modify class UserInterface to accept user input of backward/sidewards instructions, modify class CommandCenter to verify those new instructions as valid input and modify class Vehicle to carry out those instructions.
- Different shapes of plateau
    - How to implement: Modify class Plateau 
- Support different types of vehicles.
    - How to implement: Add a new subclass for the new vehicle and inherit from base class Vehicle. 
- Visual UI.
- Flying Rover.
