class Board()
{
    public Piece[,] squares = new Piece[8, 8]; // Gör ett 8x8 bräde som heter squares där varje ruta är en piece, de tomma rutorna ska vara null

    public void Initialize()
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (y < 3 || y > 4)
                {
                    if (x % 2 == 0)
                    {
                        if (y % 2 != 0)
                        {
                            squares[x, y] = new Piece(x, y);
                        }
                    }
                    else
                    {
                        if (y % 2 == 0)
                        {
                            squares[x, y] = new Piece(x, y);
                        }
                    }
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

                PrintPieces(x, y);
            }
            Console.WriteLine();
        }
        Console.BackgroundColor = ConsoleColor.Black;
    }



    void PrintPieces(int x, int y)
    {
        if (squares[x, y] != null)
        {
            if (squares[x, y].isBlack == true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("X");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("X");
            }
        }
        else
        {
            Console.Write(" ");
        }
    }
}

