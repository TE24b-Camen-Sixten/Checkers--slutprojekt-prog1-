class Piece //Pjäsen håller koll på vilken färg den har och om den är kung. Den kan även sin egen position och vilka lagliga drag den kan göra
{
    public Position position;
    public bool isBlack;
    public bool isKing = false;

    public bool NeedToTake;

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

    public List<Position> LegalMoves(Piece[,] squares, Position moveFrom) // Räknar ut vilka rutor den kan flytta sig till, retunerar sedan det i en lista med positioner
    {
        List<Position> legalPositions = [];

        int dirY = 1;

        if (isBlack)
        {
            dirY = -1;
        }

        try
        {
            if(squares[moveFrom.x + 1, moveFrom.y + dirY] == null)
            {
                legalPositions.Add(new Position{x = moveFrom.x + 1, y = moveFrom.y + dirY});
            }
            else if (squares[moveFrom.x + 1, moveFrom.y + dirY].isBlack != isBlack)
            {
                //Denna ska inte göra något, har kvar för kommer användas frö need to take
                // NeedToTake = true;
            }
            if(squares[moveFrom.x - 1, moveFrom.y + dirY] == null)
            {
                legalPositions.Add(new Position{x = moveFrom.x - 1, y = moveFrom.y + dirY});
            } 
        }
        catch (IndexOutOfRangeException) {  }
        
        return legalPositions;
    }

    List<Position> TakeList(List<Position> legalMovesBefore)
    {
        //Idéen är  att denna kollar alla pieces och ser om man måste ta, om man måste det returnar denb en lista med pieces man kan göra ett drag med.
        return [];
    }
}