class Cursor
{
    public Position position;

    public Piece selectSquare(Board board)
    {
        return board.squares[position.x, position.y];
    }

    public void MoveUp()
    {
        position.y += 1;
    }
    public void MoveDown()
    {
        position.y -= 1;
    }
    public void MoveRight()
    {
        position.x += 1;
    }
    public void MoveLeft()
    {
        position.x -= 1;
    }
}