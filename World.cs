using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIGameOfLife
{
    class World
    {
        // declare variables needed to draw the game board, green fly, lady bird and breeding
        private int gridHeight, gridWidth;
        private string[,] gameGrid;

        //Count steps
        public int countSteps = 1;

        //generate random numbers for random generating to green fly and lady bird
        Random generator = new Random();
        int numberOfInsects;

        //declare list to store each of the greenfly and ladybird
        public List<GreenFly> greenFly = new List<GreenFly>();
        public List<LadyBird> ladyBird = new List<LadyBird>();

        //height and width of the board container
        public World(int height, int width)
        {
            this.gridHeight = height;
            this.gridWidth = width;
            gameGrid = new string[height, width];
        }

        //Draw game the first time when the running the program
        public void DrawGame()
        {
            //call the genereate green fly and lady bird functions when running the game
            generateGreenFly();
            generateLadyBird();
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    if (gameGrid[i, j] == null)
                    {
                        gameGrid[i, j] = " ";
                        Console.Write(gameGrid[i, j]);
                        if (j == gridWidth - 1)
                            Console.WriteLine("\r");
                    }
                    else
                    {
                        Console.Write(gameGrid[i, j]);
                    }
                }
            }
        }

        //redraw the game and breed 
        public void RedrawGame()
        {
            //kill lady bird if it didn't eat after the third move
            for (int i = 0; i < ladyBird.Count; i++)
            {
                LadyBird bird = ladyBird[i];
                if (bird.noEating == 3)
                {
                    ladyBird.Remove(bird);
                    gameGrid[bird.Row, bird.Column] = " ";
                }
            }

            //counter to get the lady bird count
            int ladybirdcounter = ladyBird.Count;
            for (int i = 0; i < ladybirdcounter; i++)
            {
                //move lady bird randomly
                LadyBird bird = ladyBird[i];
                bird.MoveLadyBird(gameGrid, greenFly);

                //call the breed function if the lady bird alive after 8 moves
                if (bird.lives == 8)
                {
                    LadyBird newLadyBird = bird.BreedLadyBird(gameGrid);
                    if (newLadyBird != null)
                    {
                        ladyBird.Add(newLadyBird);
                    }
                    bird.lives = 0;
                }
            }

            //move the green fly randomly based on the surrounded empty cells
            int flyCounter = greenFly.Count;
            for (int i = 0; i < flyCounter; i++)
            {
                //move green fly randomly
                GreenFly fly = greenFly[i];
                fly.MoveGreenFly(gameGrid);

                //breed green fly it its a live for three moves
                if (fly.lives == 3)
                {
                    GreenFly newfly = fly.BreedGreenFly(gameGrid);
                    if (newfly != null)
                    {
                        greenFly.Add(newfly);
                    }
                    fly.lives = 0;
                }
            }

            //redraw the cells
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    Console.Write(gameGrid[i, j]);
                    if (j == gridWidth - 1)
                        Console.WriteLine("\r");
                }
            }

            Console.WriteLine("Press Enter to move the cells or Escape to close the game");
            Console.WriteLine("Green Fly = " + greenFly.Count + " .");
            Console.WriteLine("Lady Birds = " + ladyBird.Count + " .");
            Console.WriteLine("Steps = " + countSteps++);
        }

        //function to create the greenfly randomly and store it in green fly list
        public void generateGreenFly()
        {
            numberOfInsects = 100;
            for (int i = 0; i < numberOfInsects; i++)
            {
                int randomX = generator.Next(0, gridWidth - 1);
                int randomY = generator.Next(0, gridHeight - 1);

                if (gameGrid[randomX, randomY] == null)
                {
                    GreenFly fly = new GreenFly(randomX, randomY);
                    gameGrid.SetValue("o", randomX, randomY);
                    greenFly.Add(fly);
                }
                else
                {
                    while (gameGrid[randomX, randomY] != null)
                    {

                        randomX = generator.Next(0, gridWidth - 1);
                        randomY = generator.Next(0, gridHeight - 1);
                    }
                    GreenFly fly = new GreenFly(randomX, randomY);
                    gameGrid.SetValue("o", randomX, randomY);
                    greenFly.Add(fly);
                }
            }
        }

        //function to generateb lady bird randomly and store it in it's list
        public void generateLadyBird()
        {
            numberOfInsects = 5;
            for (int i = 0; i < numberOfInsects; i++)
            {
                int randomX = generator.Next(0, gridWidth - 1);
                int randomY = generator.Next(0, gridHeight - 1);

                if (gameGrid[randomX, randomY] == null)
                {
                    LadyBird bird = new LadyBird(randomX, randomY);
                    gameGrid.SetValue("x", randomX, randomY);
                    ladyBird.Add(bird);
                }
                else
                {
                    while (gameGrid[randomX, randomY] != null)
                    {
                        randomX = generator.Next(0, gridWidth - 1);
                        randomY = generator.Next(0, gridHeight - 1);
                    }
                    LadyBird bird = new LadyBird(randomX, randomY);
                    gameGrid.SetValue("x", randomX, randomY);
                    ladyBird.Add(bird);
                }
            }
        }

        //Create a file and add the count of both green flies and lady birds, and how many steps.
        public void Statistics()
        {
            using (StreamWriter streamWriter = new StreamWriter("output.txt"))
            {
                streamWriter.WriteLine("Game Statistics");
                streamWriter.WriteLine("Green Fly = " + greenFly.Count + ".");
                streamWriter.WriteLine("Lady Birds = " + ladyBird.Count + ".");
                streamWriter.WriteLine("Number of steps: " + countSteps);
            }
        }
    }
}
