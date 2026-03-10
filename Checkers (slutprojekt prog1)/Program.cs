Board board = new Board();

board.Initialize();
board.PrintBoard();

//TEST grejer, gör bra senare
Position temp = new Position{x=2, y=5}; //Skriv in x och y för att få LegalMoves
Piece activePiece = board.squares[temp.x, temp.y];
List<Position> legalpostest = activePiece.LegalMoves(board.squares, temp);

Console.Write(legalpostest[0].x + ", ");
Console.WriteLine(legalpostest[0].y);
Console.Write(legalpostest[1].x + ", ");
Console.WriteLine(legalpostest[1].y);

Console.ReadLine();