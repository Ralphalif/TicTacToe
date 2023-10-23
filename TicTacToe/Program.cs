internal class Program
{
    private static string[] Board = new string[9];
    private static bool GameIsFinished = false;
    private static string CurrentPlayer = "X";
    private static string? Winner = null;
    private static int MovesMade = 0;

    private static void Main(string[] args)
    {
        Console.WriteLine("Let's play some tic-tac-toe!");
        Console.WriteLine("It is player X's turn");

        while (!GameIsFinished)
        {
            PrintBoard();
            Console.WriteLine($"Enter a number (1-9) for player {CurrentPlayer}:");
            if (int.TryParse(Console.ReadLine(), out var squareNumber) && squareNumber >= 1 && squareNumber <= 9)
            {
                if (string.IsNullOrEmpty(Board[squareNumber - 1]))
                {
                    MakeMove(squareNumber);
                    if (MovesMade >= 5)  // Check for a win after at least 5 moves
                    {
                        CheckWin();
                    }
                    TogglePlayer();
                }
                else
                {
                    Console.WriteLine("Square already played. Try another number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number between 1 and 9.");
            }
        }

        PrintBoard();
        Console.WriteLine("Winner is " + Winner);
    }

    private static void TogglePlayer()
    {
        CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
    }

    private static void MakeMove(int squareNumber)
    {
        Board[squareNumber - 1] = CurrentPlayer;
        MovesMade++;
    }

    private static void CheckWin()
    {
        // Check rows
        for (int i = 0; i < 9; i += 3)
        {
            CheckRow(Board[i], Board[i + 1], Board[i + 2]);
        }

        // Check columns
        if (GameIsFinished == false)
            for (int i = 0; i < 3; i++)
            {
                CheckRow(Board[i], Board[i + 3], Board[i + 6]);
            }

        // Check diagonals
        if (GameIsFinished == false)
            CheckRow(Board[0], Board[4], Board[8]);
        if (GameIsFinished == false)
            CheckRow(Board[2], Board[4], Board[6]);
    }

    private static void CheckRow(string a, string b, string c)
    {
        if (a == b && b == c && !string.IsNullOrEmpty(a))
        {
            Winner = a;
            GameIsFinished = true;
        }
    }

    private static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine(" ---|---|---");
        Console.WriteLine($"  {Board[0]} | {Board[1]} | {Board[2]} ");
        Console.WriteLine(" ---|---|---");
        Console.WriteLine($"  {Board[3]} | {Board[4]} | {Board[5]} ");
        Console.WriteLine(" ---|---|---");
        Console.WriteLine($"  {Board[6]} | {Board[7]} | {Board[8]} ");
    }
}
