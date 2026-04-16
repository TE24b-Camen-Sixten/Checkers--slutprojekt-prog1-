class GameLogic //Denna class ska ansvara för logik så som vems tur det är och vad den spelaren ska göra nu.
{
    public bool player1sTurn = true;

    public Piece SelectPieceToMove(Cursor cursor, Board board)
    {
        Console.WriteLine("Move the cursor by using arrow keys, select the current square with [Enter]");

        // cursor.position = new Position { x = 0, y = 0 };
        while (true)
        {
            cursor.MoveCursor(board);
            Piece currentPiece = board.squares[cursor.position.x, cursor.position.y];

            if (SelectedRightColor(player1sTurn, currentPiece))
            {
                return currentPiece;
            }
            else
            {
                Console.WriteLine("Can't move that piece! Select a piece of your color! 1");
            }
        }


        // while (true)
        // {
        //     if (SelectedRightColor(player1sTurn, cursor.selectSquare(board)))
        //     {
        //     }
        //     else
        //     {
        //         Console.WriteLine("You need to select a piece of your own color");
        //         Console.ReadLine();
        //     }
        // }


        // while (true)
        // {
        //     ConsoleKey pressedKey = Console.ReadKey(true).Key;
        //     switch (pressedKey) // Fixa så det är MoveCursor.
        //     {
        //         case ConsoleKey.UpArrow:
        //             cursor.MoveUp();
        //             if (cursor.position.y < 0)
        //             {
        //                 cursor.position.y = 0;
        //             }
        //             break;
        //         case ConsoleKey.DownArrow:
        //             cursor.MoveDown();
        //             if (cursor.position.y > 7)
        //             {
        //                 cursor.position.y = 7;
        //             }
        //             break;
        //         case ConsoleKey.RightArrow:
        //             cursor.MoveRight();
        //             if (cursor.position.x > 7)
        //             {
        //                 cursor.position.x = 7;
        //             }
        //             break;
        //         case ConsoleKey.LeftArrow:
        //             cursor.MoveLeft();
        //             if (cursor.position.x < 0)
        //             {
        //                 cursor.position.x = 0;
        //             }
        //             break;
        //         case ConsoleKey.Enter:
        //             if (SelectedRightColor(player1sTurn, cursor.selectSquare(board)))
        //             {
        //                 return cursor.selectSquare(board);
        //             }
        //             else
        //             {
        //                 Console.WriteLine("You need to select a piece of your own color");
        //                 Console.ReadLine();
        //                 break;
        //             }
        //         default:
        //             Console.WriteLine("You need to use the arrow keys to move, or Enter to select the current square");
        //             Console.ReadLine();
        //             break;
        //     }

        //     Console.Clear();
        //     board.PrintBoard(cursor.position);
        // }
    }

    public void SelectMovement(List<Position> legalPositions, Cursor cursor, Board board, Position moveFrom)
    {
        cursor.MoveCursor(board);
        Position choosenPosition = cursor.position;
        for (int i = 0; i < legalPositions.Count; i++)
        {
            int x = legalPositions[i].x;
            int y = legalPositions[i].y;

            if (choosenPosition.x == x && choosenPosition.y == y)
            {
                board.MovePiece(moveFrom, choosenPosition);
                return;
            }
        }
        Console.WriteLine("IDIOT!");

        // while (true)<
        // {
        //     Position choosenPosition = cursor.MoveAndSelect(board).position;
        //     if (legalPositions.Contains(choosenPosition))
        //     {
        //         board.MovePiece(moveFrom, choosenPosition);
        //     }
        // }
    }

    bool SelectedRightColor(bool player1sTurn, Piece selectedPiece)
    {
        //Detta krashar om man tar en tom ruta, lös!
        if (selectedPiece.isBlack == true)
        {
            if (player1sTurn == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (player1sTurn == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}