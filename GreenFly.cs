using System;
using System.Collections.Generic;
using System.Text;

namespace AIGameOfLife
{
    class GreenFly : InsectsAndFlies
    {
        public GreenFly(int randomX, int randomY) : base(randomX, randomY)
        {
            this.Row = randomX;
            this.Column = randomY;
        }

        //move the green fly if the surrounded cell is empty
        public void MoveGreenFly(string[,] gameGrid)
        {
            randMove = generator.Next(0, 4);
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
                lives++;
                gameGrid[Row, Column] = "o";
            }
            else
                lives++;
        }

        //Breed green fly if it stayed alive for three moves
        public GreenFly BreedGreenFly(string[,] gameGrid)
        {
            GreenFly newGreenFly;
            if (Row + 1 >= 0 && Row + 1 < 20 && gameGrid[Row + 1, Column] == " ")
            {
                gameGrid[Row + 1, Column] = "o";
                newGreenFly = new GreenFly(Row + 1, Column);
                return newGreenFly;
            }
            else if (Row - 1 >= 0 && Row - 1 < 20 && gameGrid[Row - 1, Column] == " ")
            {
                gameGrid[Row - 1, Column] = "o";
                newGreenFly = new GreenFly(Row - 1, Column);
                return newGreenFly;
            }
            else if (Column + 1 >= 0 && Column + 1 < 20 && gameGrid[Row, Column + 1] == " ")
            {
                gameGrid[Row, Column + 1] = "o";
                newGreenFly = new GreenFly(Row, Column + 1);
                return newGreenFly;
            }
            else if (Column - 1 >= 0 && Column - 1 < 20 && gameGrid[Row, Column - 1] == " ")
            {
                gameGrid[Row, Column - 1] = "o";
                newGreenFly = new GreenFly(Row, Column - 1);
                return newGreenFly;
            }
            else
                return null;

        }
    }
}
