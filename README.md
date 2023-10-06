
## Title: Conway's Game of Life
## Author: Dang Nhat Linh Vu
## Date: 20/09/2020


## Build Instructions
The project is set up to be built in Visual Studio or any other IDEs that can support Visual Studio solutions files. To build in Visual Studio, open file "Life.snl", click on Life.cs, build the program then press debugging or use command prompt with dotnet to run the project.

##### _Running in Visual Studio_
After building solutions, press F5 or click Start Debugging to start the game.

##### _Directly_
After building, double click on "Life.exe" file to start the game.

##### _Via command prompt_
After building, change the directory to the folder containing "Life.dll" file, then type "dotnet Life.dll" and press enter to start the game.

## Usage 

#### _Game behaviour_
The game of life exists in universe comprised of a two-dimensional grid of square cell. The default game's dimension is 16x16. Each cell in the grid can exist in one of two states: dead or alive. The game processes through a series of generations. The rules of the game:

1. Any live cell with 2 or 3 live neigbours stays alive in the next generation.

2. Any dead cell with 3 live neighbours resurrects in the next generation.

3. Any other cells are dead in the next generation.

#### _Seeds_
The first generation of the game is called the seed. The seed can be generated randomly with a random factor value, or via a formatted file.

#### _Randomisation_
The default value of random factor is 0.5 (50%). This value can be changed before the game starts.

#### _Update rate_
The default value of update rate is 5 updates/second. This value can be changed before the game starts. The update rate value should follow real time in the world, and be calculated carefully.

#### _Command line interfaces_
Command line is used for starting the game, or change any values of the game. This also enables cheats for the game.

To enable this, user should type like this: dotnet Life.dll --{option1} {param1} {param2} --{option2} {param3}

###### Rows and Columns
How to use: --seed {number of row} {number of column}

This flag changes the dimension of the game. The value for the row and column should be between 4 and 48.

###### Periodic Behaviour
How to use: --periodic

This flag enables periodic behaviour of the seed. This flag should not be followed by any parameters.

###### Random Factor
How to use: --random {probability}

This flag enables changing of the probability of how seed generates at the first time of the game. The value of probability should be between 0 and 1 inclusively.

###### Input File
How to use: --seed {filepath}

This flag enables of putting default value of the first seed of the game. The filepath should be given correctly.

###### Generations
How to use: --generations {number of generations}

This flag enables changing the value of max generation of the game. The number should be positive.

###### Update Rate
How to use: --max-update {value}

This flag enables changing the value of update rate. The value should be between 1 and 30 inclusively.

###### Step Mode
How to use: --step

This flag enables running the game step by step via pressing spacebar key. This flag should not be followed by any parameters.

## Notes 
The game cannot process two or more of any flags.

The game still has some issues.

Update rate of the game has not implemented in the setting of the game.

Step mode can be enabled via command line, but not during the game.

Seed file can be accessed and read, but cannot put into array values to run the game.
