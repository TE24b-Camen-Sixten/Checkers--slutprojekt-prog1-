using System.Security.Cryptography.X509Certificates;

class Piece //Pjäsen håller koll på vilken färg den har och om den är kung. Den kan även sin egen position och vilka lagliga drag den kan göra
{
    Board board;
    public Position position;

    public Position enemyPos;
    public bool isBlack;
    public bool isKing = false;
    int dirY; // En variabel som håller koll på om en pjäs går upp eller ner 1 = ner -1 = upp. Det är en int för då kan man bara addera in den

    public Piece(int x, int y, Board getBoard) // Körs när en pjäs skapas. Den sätter positionen och sätter pjäsen till antingen svart eller vit.
    {
        position = new Position { x = x, y = y };
        board = getBoard;

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

        (Piece? right, Piece? left) DiagonalSquares = GetPieceOnDiagonals(squares, startPos);

        try
        {
            if (DiagonalSquares.right == null)
            {
                legalPositions.Add(new Position { x = startPos.x - 1, y = startPos.y + dirY });
            }
            else
            {
                enemyPos = new Position { x = startPos.x - 1, y = startPos.y + dirY };
                Position? pos = CanTake(squares, enemyPos, dirY, false);
                if (pos != null)
                {
                    // board.RemovePiece(enemyPos);
                    legalPositions.Add(pos.Value);
                }
            }

            if (DiagonalSquares.left == null)
            {
                legalPositions.Add(new Position { x = startPos.x + 1, y = startPos.y + dirY });
            }
            else
            {
                enemyPos = new Position { x = startPos.x + 1, y = startPos.y + dirY };
                Position? pos = CanTake(squares, enemyPos, dirY, true); ;
                if (pos != null)
                {
                    // board.RemovePiece(enemyPos);
                    legalPositions.Add(pos.Value);
                }
            }
        }
        catch (IndexOutOfRangeException) { }



        return LegalPosFixer(legalPositions);
    }

    (Piece?, Piece?) GetPieceOnDiagonals(Piece[,] squares, Position startPos) // Ska vara en mer generell version av det som händer i LegalMoves
    {
        Piece? rightPiece;
        Piece? leftPiece;
        try
        {
            rightPiece = squares[startPos.x - 1, startPos.y + dirY];
        }
        catch (IndexOutOfRangeException)
        {
            rightPiece = null;
        }
        try
        {
            leftPiece = squares[startPos.x + 1, startPos.y + dirY]; //gör en try där dessa blir null om den fakar
        }
        catch (IndexOutOfRangeException)
        {
            leftPiece = null;
        }

        return (rightPiece, leftPiece);
    }

    Position? CanTake(Piece[,] squares, Position startPos, int dirY, bool checkLeft)
    {
        (Piece? right, Piece? left) DiagonalSquares = GetPieceOnDiagonals(squares, startPos);
        if (checkLeft)
        {
            if (DiagonalSquares.left == null)
            {
                return new Position { x = startPos.x + 1, y = startPos.y + dirY };
            }
        }
        else if (!checkLeft)
        {
            if (DiagonalSquares.right == null)
            {
                return new Position { x = startPos.x - 1, y = startPos.y + dirY };
            }
        }

        return null;
    }

    List<Position> LegalPosFixer(List<Position> legalPositionsRaw)
    {
        for (int i = 0; i < legalPositionsRaw.Count; i++)
        {
            if (legalPositionsRaw[i].x >= 8 || legalPositionsRaw[i].x <= -1)
            {
                legalPositionsRaw.RemoveAt(i);
            }
        }
        return legalPositionsRaw;
    }
}
