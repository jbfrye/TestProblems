using System;
using System.Collections.Generic;
using System.Text;

namespace TestProblems
{
    class ShortestPathProblem
    {
        public static int MinimumDistance(int numRows, int numColumns, int[,] area)
        {
            int[,] visited = new int[area.GetLength(0), area.GetLength(1)];
            visited[0, 0] = 1;
            int downPath = 1000000, rightPath = 1000000;
            if (area[1, 0] != 0)
                downPath = 1 + FindRoute(1, 0, 3, area, visited);
            if (area[0, 1] != 0)
                rightPath = 1 + FindRoute(0, 1, 2, area, visited);

            return Math.Min(downPath, rightPath);
        }

        static int FindRoute(int x, int y, int dir, int[,] area, int[,] visited)
        {
            // Package is delivered
            if (area[x, y] == 9)
                return 0;

            // Mark this cell as visited
            visited[x, y] = 1;

            int leftPath = 1000000, upPath = 1000000, rightPath = 1000000, downPath = 1000000;

            // Check if there is a path left
            if (dir != 2 && y > 0)
            {
                if (area[x, y - 1] != 0 && visited[x, y - 1] != 1)
                    leftPath = 1 + FindRoute(x, y - 1, 0, area, visited);
            }
            // Check if there is a path up
            if (dir != 3 && x > 0)
            {
                if (area[x - 1, y] != 0 && visited[x - 1, y] != 1)
                    upPath = 1 + FindRoute(x - 1, y, 1, area, visited);
            }
            // Check if there is a path right
            if (dir != 0 && y < area.GetLength(1) - 1)
            {
                if (area[x, y + 1] != 0 && visited[x, y + 1] != 1)
                    rightPath = 1 + FindRoute(x, y + 1, 2, area, visited);
            }
            // Check if there is a path down
            if (dir != 1 && x < area.GetLength(0) - 1)
            {
                if (area[x + 1, y] != 0 && visited[x + 1, y] != 1)
                    downPath = 1 + FindRoute(x + 1, y, 3, area, visited);
            }

            return Math.Min(leftPath, Math.Min(upPath, Math.Min(rightPath, downPath)));
        }
        public static void Run()
        {
            int[,] arr = new int[,] {{ 1, 1, 1, 1 },
                                     { 0, 1, 1, 1 },
                                     { 1, 1, 9, 1 },
                                     { 0, 0, 1, 1 } };
            Console.WriteLine(MinimumDistance(4, 4, arr));
        }
    }
}