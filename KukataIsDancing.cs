using System;
using System.Text;

class KukataIsDancing
{
    static void Main()
    {
        // 3. Kukata is dancing
        // C# Part 2 - 2012/2013 @ 11 Feb 2013

        // Input:
        int lines = int.Parse(Console.ReadLine());
        string[] dances = new string[lines];
        for (int i = 0; i < lines; i++)
        {
            dances[i] = Console.ReadLine();
        }

        // Solution:
        for (int i = 0; i < dances.Length; i++)
        {
            if (dances[i].IndexOf('W') != -1)
            {
                string result = FindLastSquare(dances[i]);
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("GREEN");
            }
        }
    }

    private static string FindLastSquare(string dance)
    {
        string[,] square = { { "RED", "BLUE", "RED" },
                             { "BLUE", "GREEN", "BLUE" },
                             { "RED", "BLUE", "RED" } };

        // Initial position indexes
        int i = 1;
        int j = 1;

        string direction = String.Empty;
        if (dance[0] == 'W') 
        {
            direction = "UP"; i = 0; 
        }
        else if (dance[0] == 'L') direction = "LEFT";
        else if (dance[0] == 'R') direction = "RIGHT";

        for (int k = 1; k < dance.Length; k++)
        {
            direction = DetermineDirection(dance[k], direction);

            if (dance[k] != 'W')
            {
                continue;
            }

            // Move according to direction
            if (direction == "UP") i--;
            else if (direction == "DOWN") i++;
            else if (direction == "LEFT") j--;
            else if (direction == "RIGHT") j++;

            // Check if we go outside the 3x3 square
            if (j < 0) j = 2;
            if (j > 2) j = 0;
            if (i < 0) i = 2;
            if (i > 2) i = 0;
        }

        return square[i, j];
    }

    private static string DetermineDirection(char ch, string currDirection)
    {
        if (currDirection == "UP")
        {
            if (ch == 'W') return currDirection;
            else if (ch == 'L') return "LEFT";
            else if (ch == 'R') return "RIGHT";
        }
        else if (currDirection == "DOWN")
        {
            if (ch == 'W') return currDirection;
            else if (ch == 'L') return "RIGHT";
            else if (ch == 'R') return "LEFT";
        }
        else if (currDirection == "LEFT")
        {
            if (ch == 'W') return currDirection;
            else if (ch == 'L') return "DOWN";
            else if (ch == 'R') return "UP";
        }
        else if (currDirection == "RIGHT")
        {
            if (ch == 'W') return currDirection;
            else if (ch == 'L') return "UP";
            else if (ch == 'R') return "DOWN";
        }
        
        return String.Empty;
    }
}