class GameLogic //Denna class ska ansvara för logik så som vems tur det är och vad den spelaren ska göra nu.
{
    bool player1sTurn = true;

    public Piece SelectPieceToMove(Cursor cursor, Board board)
    {
        Console.WriteLine("Move the cursor by using arrow keys, select the current square with Enter");

        cursor.position = new Position{x = 0, y = 0};
        
        while (true)
        {
            ConsoleKey pressedKey = Console.ReadKey(true).Key;
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    cursor.MoveUp();
                    if (cursor.position.y < 0)
                    {
                        cursor.position.y = 0;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    cursor.MoveDown();
                    if (cursor.position.y > 7)
                    {
                        cursor.position.y = 7;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    cursor.MoveRight();
                    if (cursor.position.x > 7)
                    {
                        cursor.position.x = 7;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    cursor.MoveLeft();
                    if (cursor.position.x < 0)
                    {
                        cursor.position.x = 0;
                    }
                    break;
                case ConsoleKey.Enter:
                    return cursor.selectSquare(board);
                default:
                    Console.WriteLine("You need to use the arrow keys to move, or Enter to select the current square");
                    break;
            }
            
            Console.Clear();
            board.PrintBoard(cursor.position);
        }
    }

    public void MovePieceTo()
    {
        
    }
}