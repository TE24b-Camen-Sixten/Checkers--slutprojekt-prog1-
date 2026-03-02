static void PrintBoard()
{
    for (int y = 0; y < 8; y++)
    {
        for (int x = 0; x < 8; x++)
        {
            if (x % 2 == 0)
            {
                if (y % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
            }
            else
            {
                if (y % 2 != 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
            }

            Console.Write(" ");
        }
        Console.WriteLine();
    }
}

PrintBoard();
Console.ReadLine();