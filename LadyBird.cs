using System;
using System.Collections.Generic;
using System.Text;

namespace AIGameOfLife
{
    class LadyBird : InsectsAndFlies
    {
        public int noEating = 0;
        public LadyBird(int randomX, int randomY) : base(randomX, randomY)
        {
            this.Row = randomX;
            this.Column = randomY;
        }

        //move lady bird randomly and check if there is a green fly in the neighbour cell to eat it
        public void MoveLadyBird(string[,] gameGrid, List<GreenFly> greenFly)
        {
            //random number up, down, left, right
            randMove = generator.Next(0, 4);
            nextCell = getNextCell(Row, Column, randMove);
            int enemy = 0;

            //check if the rows cells contain an enemy( green fly ) and eat it.
            if (Row + 1 >= 0 && Row + 1 < 20 && gameGrid[Row + 1, Column] == "o")
            {
                enemy = getEnemyFly(Row + 1, Column, greenFly);
                gameGrid[Row, Column] = " ";
                greenFly.RemoveAt(enemy);
                Move(1);
                lives++;
                gameGrid[Row, Column] = "x";
            }
            else if (Row - 1 >= 0 && Row - 1 < 20 && gameGrid[Row - 1, Column] == "o")
            {
                enemy = getEnemyFly(Row - 1, Column, greenFly);
                gameGrid[Row, Column] = " ";
                greenFly.RemoveAt(enemy);
                Move(0);
                lives++;
                gameGrid[Row, Column] = "x";

            }
            //check the columns cells if there is a green fly and eat it
            else if (Column + 1 >= 0 && Column + 1 < 20 && gameGrid[Row, Column + 1] == "o")
            {
                enemy = getEnemyFly(Row, Column + 1, greenFly);
                gameGrid[Row, Column] = " ";
                greenFly.RemoveAt(enemy);
                Move(3);
                lives++;
                gameGrid[Row, Column] = "x";
            }
            else if (Column - 1 >= 0 && Column - 1 < 20 && gameGrid[Row, Column - 1] == "o")
            {
                enemy = getEnemyFly(Row, Column - 1, greenFly);
                gameGrid[Row, Column] = " ";
                greenFly.RemoveAt(enemy);
                Move(2);
                lives++;
                gameGrid[Row, Column] = "x";
            }

            //if there is not any green fly then move it randomly
            else
            {
                nextCell = getNextCell(Row, Column, randMove);
                while (nextCell[0] < 0 || nextCell[0] >= 20 || nextCell[1] < 0 || nextCell[1] >= 20)
                {
                    randMove = generator.Next(0, 4);
                    nextCell = getNextCell(Row, Column, randMove);
                }
                if (gameGrid[nextCell[0], nextCell[1]] == " ")
                {
                    gameGrid[Row, Column] = " ";
                    Move(randMove);
                    gameGrid[Row, Column] = "x";
                }
                noEating++;
                lives++;
            }
        }

        //breed the lady bird if it is alive for 8 moves
        public LadyBird BreedLadyBird(string[,] gameGrid)
        {
            LadyBird newLadyBird;

            //check the cells around lady bird and create a new lady bird in the empty one
            if (Row + 1 >= 0 && Row + 1 < 20 && gameGrid[Row + 1, Column] == " ")
            {
                gameGrid[Row + 1, Column] = "x";
                newLadyBird = new LadyBird(Row + 1, Column);
                return newLadyBird;
            }
            else if (Row - 1 >= 0 && Row - 1 < 20 && gameGrid[Row - 1, Column] == " ")
            {
                gameGrid[Row - 1, Column] = "x";
                newLadyBird = new LadyBird(Row - 1, Column);
                return newLadyBird;
            }
            else if (Column + 1 >= 0 && Column + 1 < 20 && gameGrid[Row, Column + 1] == " ")
            {
                gameGrid[Row, Column + 1] = "x";
                newLadyBird = new LadyBird(Row, Column + 1);
                return newLadyBird;
            }
            else if (Column - 1 >= 0 && Column - 1 < 20 && gameGrid[Row, Column - 1] == " ")
            {
                gameGrid[Row, Column - 1] = "x";
                newLadyBird = new LadyBird(Row, Column - 1);
                return newLadyBird;
            }
            else return null;
        }

        //function to check the next cell if it has a green fly before moving
        public int getEnemyFly(int row, int column, List<GreenFly> greenFly)
        {
            int flyIndex = -1;

            for (int i = greenFly.Count - 1; i >= 0; i--)
            {
                if (greenFly[i].Row == row && greenFly[i].Column == column)
                {
                    flyIndex = i;
                    break;
                }
            }
            return flyIndex;
        }
    }
}

