class Board()
{
    public Piece[,] squares = new Piece[8,8]; // Gör ett 8x8 bräde som heter squares där varje ruta är en piece

    public void Initialize()
    {
        List<Position.x> startpositions = []; //fixa en lista med vart pices ska börja.

        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (squares[x, y].position ) //Gör så den kollar gemtemot en lista och ser om det ska vara en piece där
                {
                    
                }
            }
        }
    }

    public void PrintBoard()
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
}