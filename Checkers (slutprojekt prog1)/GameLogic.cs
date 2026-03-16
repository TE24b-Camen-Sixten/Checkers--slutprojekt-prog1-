using System.Xml;

class GameLogic //Denna class ska ansvara för logik så som vems tur det är och vad den spelaren ska göra nu.
{
    bool player1sTurn = true;

    public void ChoosePiece()
    {
        Cursor cursor = new Cursor{position = new Position{x = 0, y = 0}};
        ConsoleKey pressedKey = Console.ReadKey(true).Key;

        Console.WriteLine("Move the cursor by using arrow keys, select the current square with spacebar or Enter");

        switch (pressedKey)
        {
            case ConsoleKey.UpArrow:
                cursor.MoveUp();
                break;
            case ConsoleKey.DownArrow:
                cursor.MoveDown();
                break;
            case ConsoleKey.RightArrow:
                cursor.MoveRight();
                break;
            case ConsoleKey.LeftArrow:
                cursor.MoveLeft();
                break;
        }
    }
}