class Piece //Pjäsen håller koll på vilken färg den har och om den är kung. Den kan även sin egen position och vilka lagliga drag den kan göra
{
    public Position position;
    public bool isBlack;
    public bool isKing = false;

    public bool NeedToTake;

    public Piece(int x, int y) // Körs när en pjäs skapas. Den sätter positionen och sätter pjäsen till antingen svart eller vit.
    {
        position = new Position { x = x, y = y };

        if (position.y > 4)
        {
            isBlack = true;
        }
        else
        {
            isBlack = false;
        }
    }

    public List<Position> LegalMoves(Piece[,] squares, Position moveFrom) // Räknar ut vilka rutor den kan flytta sig till, retunerar sedan det i en lista med positioner
    {
        List<Position> legalPositions = [];

        int dirY = 1; // En variabel som säger om pjäsen kan gå upp eller ner. 1 = ner -1 = ner egersom då kan man bara multiplicera in det.

        if (isBlack)
        {
            dirY = -1;
        }

        try // Kollar ifall det krashar, vilket det gör om en pjäs är på kanten. Isåfall skippar den koden.
        {
            if (squares[moveFrom.x + 1, moveFrom.y + dirY] == null)
            {
                legalPositions.Add(new Position { x = moveFrom.x + 1, y = moveFrom.y + dirY });
            }
            if (squares[moveFrom.x - 1, moveFrom.y + dirY] == null)
            {
                legalPositions.Add(new Position { x = moveFrom.x - 1, y = moveFrom.y + dirY });
            }
            
            if (squares[moveFrom.x + 1, moveFrom.y + dirY].isBlack != isBlack || squares[moveFrom.x - 1, moveFrom.y + dirY].isBlack != isBlack)
            {
                return CanTake()
            }
        }
        catch (IndexOutOfRangeException) { }

        return legalPositions;
    }

    List<Position> CanTake(Piece[,] squares, Position startPos, int dirY, List<Position> legalPositions)
    {
        if (CanTakeChecker(squares, startPos, dirY))
        {
            legalPositions.Clear();
            if (squares[startPos.x + 1, startPos.y + dirY] == null)
            {
                NeedToTake = true;
                legalPositions.Add(new Position { x = startPos.x + 1, y = startPos.y + dirY });
            }
            if (squares[startPos.x - 1, startPos.y + dirY] == null)
            {
                NeedToTake = true;
                legalPositions.Add(new Position { x = startPos.x - 1, y = startPos.y + dirY });
            }
        }

        return legalPositions;
    }

    bool CanTakeChecker(Piece[,] squares, Position startPos, int dirY)
    {
        if (squares[startPos.x + 1, startPos.y + dirY] == null || squares[startPos.x - 1, startPos.y + dirY] == null)
        {
            return true;
        }
        return false;
    }
}