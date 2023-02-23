using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codec_test
{

    public static class Move
    {

        public static Result MoveRover(ulong positionX, ulong positionY, ulong plateauSize, Direction direction, char command)
        {
            if (!command.Equals('F'))
                if (command.Equals('L'))
                {
                    direction = rotateLeft(direction);
                }
                else if (command.Equals('R'))
                {
                    direction = rotateRight(direction);
                }
                else
                    Console.WriteLine("Invalid input. Skipping ...");

            Console.WriteLine($"Rover rotated and is now facing {direction}");


            //check whether moving forward will take rover off the map
            if (positionX == 0 && direction == Direction.WEST && command.Equals('F'))
            {
                return null;
            }
            if (positionY == 0 && direction == Direction.SOUTH && command.Equals('F'))
            {
                return null;
            }
            if (positionX == plateauSize && direction == Direction.EAST && command.Equals('F'))
            {
                return null;
            }
            if (positionY == plateauSize && direction == Direction.NORTH && command.Equals('F'))
            {
                return null;
            }

            return new Result
            {
                positionX = positionX,
                positionY = positionY,
                direction = direction,
            };
        }

        private static Direction rotateRight(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH: { direction = Direction.EAST; break; }
                case Direction.EAST: { direction = Direction.SOUTH; break; }
                case Direction.SOUTH: { direction = Direction.WEST; break; }
                case Direction.WEST: { direction = Direction.NORTH; break; }
            }
            return direction;
        }

        private static Direction rotateLeft(Direction direction)
        {
            switch (direction)
            {
                case Direction.NORTH: { direction = Direction.WEST; break; }
                case Direction.EAST: { direction = Direction.NORTH; break; }
                case Direction.SOUTH: { direction = Direction.EAST; break; }
                case Direction.WEST: { direction = Direction.SOUTH; break; }
            }
            return direction;
        }
    }
}