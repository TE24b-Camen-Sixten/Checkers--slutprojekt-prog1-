class GameLogic //Denna class ska ansvara för logik så som vems tur det är och vad den spelaren ska göra nu.
{
    public bool player1sTurn = true;

    public Piece SelectPieceToMove(Cursor cursor, Board board) // Låter användaren välja en pjäs att flytta. Detta gör den genom att först låta hen flytta cursorn.
    {                                                         //  Efter det returnerar den pjäsen som har samma position som cursorn om det är rätt färg.
        Console.WriteLine("Move the cursor by using arrow keys, select the current square with [Enter]");

        // cursor.position = new Position { x = 0, y = 0 };
        while (true)
        {
            cursor.MoveCursor(board);
            Piece currentPiece = board.squares[cursor.position.x, cursor.position.y];
            try
            {
                if (SelectedRightColor(player1sTurn, currentPiece))
                {
                    return currentPiece;
                }
                else
                {
                    Console.WriteLine("Can't move that piece! Select a piece of your color!");
                }
            }
            catch (NullReferenceException) { }
        }
    }

    public void SelectMovement(List<Position> legalPositions, Cursor cursor, Board board, Position moveFrom, Position enemyPos, int dirY) // Låter spelaren välja var hen vill flytta den valda pjäsen till en av de tillåtna rutorna.
    {
        while (true)
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
                    if (Math.Abs(y - moveFrom.y) == 2)
                    {
                        board.RemovePiece(enemyPos);
                    }
                    return;
                }
            }
            Console.WriteLine("IDIOT! Det är inte ett lagligt drag.");
        }
    }

    bool SelectedRightColor(bool player1sTurn, Piece selectedPiece) // Kollar ifall pjäsen har den rätta färgen. (svart om det är player 1 och vit om det är player 2)
    {
        if (selectedPiece.isBlack)
        { 
            return player1sTurn;
        } 
        else
        {
            return !player1sTurn;
        }
    }
}