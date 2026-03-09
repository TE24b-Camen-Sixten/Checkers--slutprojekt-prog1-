Board board = new Board();

board.Initialize();
board.PrintBoard();

Console.WriteLine(Piece.LegalMoves(board.squares, ));

Console.ReadLine();