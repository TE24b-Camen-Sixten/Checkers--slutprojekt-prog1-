Board board = new Board();
Cursor cursor = new Cursor();

board.Initialize();
board.RemovePiece(new Position{x=1, y=2});
board.PrintBoard(cursor.position);

GameLogic logic = new GameLogic();

Piece square = logic.SelectPieceToMove(cursor, board);

//TEST grejer, gör bra senare
Position temp = new Position{x=square.position.x, y=square.position.y}; //Skriv in x och y för att få LegalMoves för pjäsen på den positionen
Piece activePiece = board.squares[temp.x, temp.y];
List<Position> legalpostest = activePiece.LegalMoves(board.squares, temp);

if (legalpostest.Count == 0)
{
    Console.WriteLine("Can't move that piece");
}
else if(legalpostest.Count == 1)
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

Console.ReadLine();