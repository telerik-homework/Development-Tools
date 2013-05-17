using System;
using System.Collections.Generic;

class SpecialValue
{
    static void Main()
    {
        // 2. Special value
        // C# Part 2 - 2012/2013 @ 11 Feb 2013

        // Input
        int lines = int.Parse(Console.ReadLine());
        int[][] cells = new int[lines][]; // jagged array
        for (int i = 0; i < lines; i++)
        {
            string currentLine = Console.ReadLine();
            string[] currentNumbers = currentLine.Split(',');
            cells[i] = new int[currentNumbers.Length];
            for (int j = 0; j < currentNumbers.Length; j++)
            {
                currentNumbers[j] = currentNumbers[j].Trim();
                cells[i][j] = int.Parse(currentNumbers[j]);
            }
        }

        // Solution
        int max = 1;
        List<string> indexesVisited = new List<string>(); // We will add here the indexes of the visited cells => "row,col"

        // Check possible solutions from first row:
        for (int i = 0; i < cells[0].Length; i++)
        {
            if (cells[0][i] < 0)
            {
                int tempMax = Math.Abs(cells[0][i]) + 1;
                if (tempMax > max)
                {
                    max = tempMax;
                }
            }
        }

        // Check paths longer than one cell
        int row = 0;
        int col = 0;
        for (int i = 0; i < cells[0].Length; i++)
        {
            if (cells[0][i] >= 0)
            {
                row = 0;
                int tempMax = 1;
                col = i;
                do
                {
                    col = cells[row][col];
                    row++;

                    if (row >= cells.Length) // if last row -> go to first row
                    {
                        row = 0;
                    }

                    string currentIndexes = row.ToString() + ',' + col.ToString();
                    if (indexesVisited.Contains(currentIndexes)) // if visited
                    {
                        tempMax = 1;
                        break;
                    }
                    else // if not visited -> mark as visited
                    {
                        tempMax++;
                        indexesVisited.Add(currentIndexes);
                    }

                    if (cells[row][col] < 0) // if negative
                    {
                        tempMax += Math.Abs(cells[row][col]);
                        break;
                    }
                } while (true);

                if (tempMax > max)
                {
                    max = tempMax;
                }

                indexesVisited.Clear();
            }
        }

        Console.WriteLine(max);
    }
}