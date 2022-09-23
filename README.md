# Mars Explorers Control System

- In this system, the surface of Mars is represented by a rectangular Plateau, starting from coordinate (0,0), following the x-axis and y-axis, user can define the size of it by entering the coordinate of the upper right hand corner of the Plateau.
- On the Plateau, user can choose to randomly place some rocks, some unknown obstacles or even some aliens!
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
