namespace codec_test
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //initializing variables
            Result finalResult = new Result();

            Console.WriteLine("\n" + "Welcome to ROVER CONTROL");

            Console.WriteLine("Enter size of plateau: ");
            ulong plateauSize = Convert.ToUInt64(Console.ReadLine());
            ulong[,] plateau = new ulong[plateauSize, plateauSize];

            Console.WriteLine($"Created plateau of size {plateau.GetLength(0)}x{plateau.GetLength(1)}");

            Console.WriteLine("Enter command string: ");
            string commandString = Console.ReadLine();

            for (int i = 0; i < commandString.Length; i++)
            {
                Result current = Move.MoveRover(finalResult.positionX, finalResult.positionY, plateauSize, finalResult.direction, commandString[i]);
                finalResult.direction = current.direction;
                finalResult.positionX = current.positionX;
                finalResult.positionY = current.positionY;
            }

            Console.WriteLine($"Result: {finalResult.positionX + 1},{finalResult.positionY + 1},{finalResult.direction}");
        }
    }
}

public enum Direction
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}