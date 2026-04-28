class Piece //Pjäsen håller koll på vilken färg den har och om den är kung. Den kan även sin egen position och vilka lagliga drag den kan göra
{
    public Position position;
    public bool isBlack;
    public bool isKing = false;
    int dirY; // En variabel som håller koll på om en pjäs går upp eller ner 1 = ner -1 = upp. Det är en int för då kan man bara addera in den

    public Piece(int x, int y) // Körs när en pjäs skapas. Den sätter positionen och sätter pjäsen till antingen svart eller vit.
    {
        position = new Position { x = x, y = y };

        if (position.y > 4)
        {
            isBlack = true;
            dirY = -1;
        }
        else
        {
            isBlack = false;
            dirY = 1;
        }
    }

    public List<Position> LegalMoves(Piece[,] squares, Position startPos) // Räknar ut vilka rutor den kan flytta sig till, retunerar sedan det i en lista med positioner
    {
        List<Position> legalPositions = [];

        (Piece right, Piece left) DiagonalSquares = IsPieceOnDiagonals(squares, startPos);

        try
        {
            if(DiagonalSquares.right == null)
            {
                legalPositions.Add(new Position { x = startPos.x + 1, y = startPos.y + dirY });
            }
            if(DiagonalSquares.left == null)
            {
                legalPositions.Add(new Position { x = startPos.x - 1, y = startPos.y + dirY });
            }
        }
        catch (IndexOutOfRangeException) {  }
        

        // try // Kollar ifall det krashar, vilket det gör om en pjäs är på kanten. Isåfall skippar den koden.
        // {
        //     if (squares[moveFrom.x + 1, moveFrom.y + dirY] == null)
        //     {
        //         legalPositions.Add(new Position { x = moveFrom.x + 1, y = moveFrom.y + dirY });
        //     }
        //     if (squares[moveFrom.x - 1, moveFrom.y + dirY] == null)
        //     {
        //         legalPositions.Add(new Position { x = moveFrom.x - 1, y = moveFrom.y + dirY });
        //     }

        //     // try
        //     // {
        //     //     if (squares[moveFrom.x + 1, moveFrom.y + dirY].isBlack != isBlack || squares[moveFrom.x - 1, moveFrom.y + dirY].isBlack != isBlack)
        //     //     {
        //     //         // return CanTake();
        //     //     }
        //     // }
        //     // catch (NullReferenceException) { }
        // }
        // catch (IndexOutOfRangeException) { }

        return legalPositions;
    }

    (Piece, Piece) IsPieceOnDiagonals(Piece[,] squares, Position startPos) // Ska vara en mer generell version av det som händer i LegalMoves
    {
        Piece rightPiece = squares[startPos.x + 1, startPos.y + dirY];
        Piece leftPiece = squares[startPos.x - 1, startPos.y + dirY]; //gör en try där dessa blir null om den fakar

        // try
        // {
        //     if (squares[startPos.x + 1, startPos.y + dirY] != null)
        //     {
        //         rightPiece = squares[startPos.x + 1, startPos.y + dirY];
        //     }
        // }
        // catch (IndexOutOfRangeException) {  }
        // try
        // {
        //     if (squares[startPos.x - 1, startPos.y + dirY] != null)
        //     {
        //         leftPiece = ;
        //     }    
        // }
        // catch (IndexOutOfRangeException) {  }

        return (rightPiece, leftPiece);
    }



    //Dålig tanke under, jag gör om hela grejen.

    // List<Position> CanTake(Piece[,] squares, Position startPos, int dirY, List<Position> legalPositions)
    // {
    //     if (CanTakeChecker(squares, startPos, dirY))
    //     {
    //         legalPositions.Clear();
    //         if (squares[startPos.x + 1, startPos.y + dirY] == null)
    //         {
    //             NeedToTake = true;
    //             legalPositions.Add(new Position { x = startPos.x + 1, y = startPos.y + dirY });
    //         }
    //         if (squares[startPos.x - 1, startPos.y + dirY] == null)
    //         {
    //             NeedToTake = true;
    //             legalPositions.Add(new Position { x = startPos.x - 1, y = startPos.y + dirY });
    //         }
    //     }

    //     return legalPositions;
    // }

    // bool CanTakeChecker(Piece[,] squares, Position startPos, int dirY)
    // {
    //     if (squares[startPos.x + 1, startPos.y + dirY] == null || squares[startPos.x - 1, startPos.y + dirY] == null)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
}