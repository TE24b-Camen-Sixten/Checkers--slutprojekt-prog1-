GameLogic logic = new GameLogic();
Board board = new Board();
Cursor cursor = new Cursor();

board.Initialize();
// board.RemovePiece(new Position { x = 1, y = 2 });
// board.MovePiece(new Position { x = 3, y = 2 }, new Position { x = 2, y = 3 });
board.PrintBoard(cursor.position);

while(true)
{ 
    Piece movingPiece = logic.SelectPieceToMove(cursor, board);

    //TEST grejer, gör bra senare
    Position temp = new Position { x = movingPiece.position.x, y = movingPiece.position.y }; //Skriv in x och y för att få LegalMoves för pjäsen på den positionen
    Piece activePiece = board.squares[temp.x, temp.y];
    List<Position> legalpostest = activePiece.LegalMoves(board.squares, temp);

    if (legalpostest.Count == 0)
    {
        Console.WriteLine("Can't move that piece");
    }
    else if (legalpostest.Count == 1)
    {
        Console.Write(legalpostest[0].x + ", ");
        Console.WriteLine(legalpostest[0].y);
    }
    else if (legalpostest.Count == 2)
    {
        Console.Write(legalpostest[0].x + ", ");
        Console.WriteLine(legalpostest[0].y);
        Console.Write(legalpostest[1].x + ", ");
        Console.WriteLine(legalpostest[1].y);
    }

    logic.SelectMovement(legalpostest, cursor, board, movingPiece.position, movingPiece.enemyPos, movingPiece.dirY);

    Console.Clear();
    board.PrintBoard(cursor.position);

    // Console.ReadLine();
    logic.player1sTurn = !logic.player1sTurn;
}