# Game-Of-Life
InsectsAndFlies.cs
Base class for lady bird and green fly classes, contains the Row and Column functions to get the coordinates of each bird and fly, then move function that will move each of them randomly by creating a random number from 1 to 4, then based on these if number = 0 it will move up, 1 will move down, 2 will move left and three will move right. Then nextCell functions that takes the coordinates of the bird/fly and get the surrounded cells.

LadyBird.cs
	Inherits functions from InsectsAndFlies class, contains the below functions

		MoveLadyBird: 
This function takes grid and greenfly list as arguments, then generates 4 random numbers, then check the cells that surround lady bird, if it contains an enemy it will eat it, if not so it will move to the nearest empty cell.

BreedLadyBird
Takes grid as an argument to check the random cells. And this function will be called in the world class .

getEnemyFly
used In MoveLadyBird function to get the coordinates of the green flies around the lady bird.

GreenFly.cs
Same as previous class which inherits from InsectsAndFlies class and it contains
MoveGreenFly
It moves the green fly randomly and increment the lives counter. 
BreedGreenFly
This function called in redraw function in world class, to breed the green fly if it survived for three moves.

World.cs
World class is responsible for generating green flies and lady birds then store each in separate lists, draw and redraw game board, breeding and moving the objects, containing the below functions:
DrawGame: 
This function is to draw a board 20 x 20  cells and calling functions that generate lady bird and green flies.

RedrawGame:
When the user clicks enter button, this function will redraw the board, then call modayldaybitd and  movegreenfly functions to move randomly based on the empty surrounded cells, also if there are green flies in the cell next to the lady bird, will be eaten.
Checks if lady bird survived for 8 moves, then it will breed and if not, it will die, if the green fly stayed alive for 3 moves, then it will breed.	

GenerateGreenFly and GenerateLadyBird functions
to create 100 green fly and 5 lady bird.

Statistics
When the user chose to end the game, this method will create a file with the statistics of how many steps, count of lady bird and green flies survived till the end of the game.

Main function
Draw the game board when the game run first time and redraw it if the user clicked enter, or close if ESC pressed, also ask the user to restart or close the game if the lady bird can’t breed or eat any green flies anymore.
