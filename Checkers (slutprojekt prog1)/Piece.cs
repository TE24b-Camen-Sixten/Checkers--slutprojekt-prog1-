class Piece
{
    public Position position;
    public bool isBlack;
    public bool isKing = false;

    public Piece(int x, int y)
    {
        position = new Position{x = x, y = y};

        if (position.y > 4)
        {
            isBlack = true;
        }
        else
        {
            isBlack = false;
        }
    }

    public List<Position> LegalMoves(Piece[,] squares, Position moveFrom)
    {
        List<Position> legalPositions = [];

        int dirY = 1;

        if (isBlack)
        {
            dirY = -1;
        }
        
        if(squares[moveFrom.x + 1, moveFrom.y + dirY] == null)
        {
            legalPositions.Add(new Position{x = moveFrom.x + 1, y = moveFrom.y + dirY});
        }
        if(squares[moveFrom.x - 1, moveFrom.y + dirY] == null)
        {
            legalPositions.Add(new Position{x = moveFrom.x - 1, y = moveFrom.y + dirY});
        }

        return legalPositions;
    }

    bool NeedToTake()
    {
        return false;
    }
}