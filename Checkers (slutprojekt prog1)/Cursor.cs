class Cursor
{
    public Piece selectSquare(int x, int y, Board board)
    {
        return board.squares[x, y];
    }

    public void MoveUp(){}
    public void MoveDown(){}
    public void MoveLeft(){}
    public void MoveRight(){}
}