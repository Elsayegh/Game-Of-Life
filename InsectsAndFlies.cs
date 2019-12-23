using System;
using System.Collections.Generic;
using System.Text;

namespace AIGameOfLife
{
    class InsectsAndFlies
    {
        //public int row, column;
        public int Row { get; set; }
        public int Column { get; set; }
        public int lives = 0;

        //generate random numbers for random movement
        public Random generator = new Random();

        //declare variable to get next cell 
        public int[] nextCell;
        //variable for random move
        public int randMove;

        public InsectsAndFlies(int randomX, int randomY)
        {
            this.Row = randomX;
            this.Column = randomY;
        }

        public void Move(int randNum)
        {
            //move up
            if (randNum == 0)
            {
                this.Row--;
            }
            //move down
            else if (randNum == 1)
            {
                this.Row++;
            }
            //move left
            else if (randNum == 2)
            {
                this.Column--;
            }
            //move right
            else if (randNum == 3)
            {
                this.Column++;
            }
        }

        //check the next cell if its empty to move lady bird or green fly 
        public int[] getNextCell(int coordX, int coordY, int direction)
        {
            int nextX = 0, nextY = 0;
            if (direction == 0)
            {
                nextX = coordX - 1;
                nextY = coordY;
            }
            else if (direction == 1)
            {
                nextX = coordX + 1;
                nextY = coordY;
            }
            else if (direction == 2)
            {
                nextX = coordX;
                nextY = coordY - 1;
            }
            else if (direction == 3)
            {
                nextX = coordX;
                nextY = coordY + 1;
            }

            return new int[] { nextX, nextY };
        }
    }
}
