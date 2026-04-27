class Board //Är brädet. Tar bort och skapar pjäser. Vet även var alla pieces befinner sig.
{
    public Piece[,] squares = new Piece[8, 8]; // Gör ett 8x8 bräde där varje ruta kan vara en piece, nu är de null dock. Valde en array för att den ska ha samma länd hela tiden (8) och kunna vara null eftersom det är så jag ser att det inte är en pjäs på den positionen.
    public void Initialize() // Skapar pjäser på deras startpositioner. 
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (y < 3 || y > 4)
                {
                    if (x % 2 == 0) // jag är en bög ocg vet inte varför jag gjorde så här
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

    public void PrintBoard(Position cursorPos) // Ritar ut det man ser, kallar på PrintPieces där det ska vara pjäser och PrintBackground för själva brädet.
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                PrintBackground(x, y);

                if (x == cursorPos.x && y == cursorPos.y)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }

                if (squares[x, y] != null)
                {
                    PrintPiece(x, y);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    void PrintBackground(int x, int y) // Kollar om rutan ska vara svart eller vit, ändrar sedan bakgrundsfärgen till rätt färg.
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
    }

    void PrintPiece(int x, int y) // Skriver ut ett "X" för att symbolisera en pjäs. Ser även till att pjäserna har rätt färg.
    {
        if (squares[x, y].isBlack == true)
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.Write("X");
    }

    public void MovePiece(Position startPosition, Position endPosition) // Flyttar en pjäs från en position till en annan
    {
        Piece piece = squares[startPosition.x, startPosition.y];

        squares[endPosition.x, endPosition.y] = piece;
        squares[startPosition.x, startPosition.y] = null;

        piece.position = endPosition;
    }

    public void RemovePiece(Position position) // Tar bort den pjäs som befinner sig på den position som blir inmatad 
    {
        squares[position.x, position.y] = null;
    }
}