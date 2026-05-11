class Cursor
{
    public Position position;

    public Cursor() // Sätter Cursorns position till 0,0 när den skapas.
    {
        position.x = 0;
        position.y = 0;    
    }

    Piece selectSquare(Board board)
    {
        return board.squares[position.x, position.y];
    }
    void MoveUp() // Flyttar up cursorn ett steg.
    {
        position.y -= 1;
    }
    void MoveDown() // Flyttar ner cursorn ett steg.
    {
        position.y += 1;
    }
    void MoveRight() // Flyttar cursorn ett steg till höger.
    {
        position.x += 1;
    }
    void MoveLeft() // Flyttar cursorn ett steg till vänster.
    {
        position.x -= 1;
    }

    public void MoveCursor(Board board) // Låter användaren flytta cursorn, hen kan stoppa metoden genom att klicka enter.
    {                                  //  Efter att cursorn har flyttats ett steg används en annan funktion för att se till så cursorn är kvar på brädet
        while (true)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.Enter:
                    return;
                default:
                    Console.WriteLine("You need to use the arrow keys to move, or Enter to select the current square");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();
            CursorOutOfBoundsChecker();
            board.PrintBoard(position);
        }
    }

    void CursorOutOfBoundsChecker() // Kollar ifall cursorn är utanför spelplanen, om så är fallet flyttar den in cursorn på brädet.
    {
        if (position.y < 0) position.y = 0;
        else if (position.y > 7) position.y = 7;
        else if (position.x > 7) position.x = 7;
        else if (position.x < 0) position.x = 0;
    }
}