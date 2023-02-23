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

            Console.WriteLine($"Rover is now facing {direction}");


            //check whether moving forward will take rover off the map
            if (command.Equals('F'))
            {
                //first check corners then check edges
                //position 1,1
                if (positionX == 0 && positionY == 0 && (direction == Direction.WEST || direction == Direction.SOUTH))
                {
                    return null;//return object with same position
                }
                // position plateauSize, plateauSize
                if (positionX == (plateauSize - 1) && positionY == (plateauSize - 1) && (direction == Direction.EAST || direction == Direction.NORTH))
                {
                    return null;//return object with same position
                }
                //checking left edges
                if (positionY == 0 && direction == Direction.SOUTH)
                {
                    return null;//return object with same position
                }
                if (positionY == (plateauSize - 1) && direction == Direction.NORTH)
                {
                    return null;//return object with same position
                }
                if (positionX == 0 && direction == Direction.WEST)
                {
                    return null;
                }
                if (positionX == (plateauSize - 1) && direction == Direction.EAST)
                {
                    return null;
                }

                //moveForward
                switch (direction)
                {
                    case Direction.NORTH: positionY++; break;
                    case Direction.SOUTH: positionY--; break;
                    case Direction.EAST: positionX++; break;
                    case Direction.WEST: positionX--; break;
                }
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