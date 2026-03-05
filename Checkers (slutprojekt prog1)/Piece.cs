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

    List<(Piece, Position)> LegalMoves()
    {
        List<(Piece, Position)> legalPositions = [];

        //gör så den lägger in alla lagliga moves i listan
        
        return legalPositions;
    }
}