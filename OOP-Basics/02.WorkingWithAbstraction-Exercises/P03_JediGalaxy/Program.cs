using System;
using System.Linq;


class Program
{
    static void Main()
    {
        int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int x = dimestions[0];
        int y = dimestions[1];

        int[,] matrix = new int[x, y];

        matrix = GetMatrix(x, y, matrix);
        long sum = 0;
        string command;
        
        while ((command=Console.ReadLine()) != "Let the Force be with you")
        {
            int[] ivoS = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] evilArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int xE = evilArgs[0];
            int yE = evilArgs[1];
            Path evil=new Path(xE,yE);
            while (evil.X >= 0 && evil.Y >= 0)
            {
                matrix = EvilPath(evil, matrix);
                evil.X--;
                evil.Y--;
            }

            int xI = ivoS[0];
            int yI = ivoS[1];
            Path pesho = new Path(xI, yI);
            while (pesho.X >= 0 && pesho.Y < matrix.GetLength(1))
            {
                sum = PeshoPath(pesho, matrix, sum);
                pesho.Y++;
                pesho.X--;
            }
        }
        Console.WriteLine(sum);
    }

    public static int[,] GetMatrix(int x, int y, int[,] matrix)
    {
        int value = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = value++;
            }
        }
        return matrix;
    }

    public static int[,] EvilPath(Path evil, int[,] matrix)
    {
        if (evil.X >= 0 && evil.X < matrix.GetLength(0) && evil.Y >= 0 && evil.Y < matrix.GetLength(1))
        {
            matrix[evil.X, evil.Y] = 0;
        }        
        return matrix;
    }

    public static long PeshoPath(Path pesho, int[,] matrix, long sum)
    {
        if (pesho.X >= 0 && pesho.X < matrix.GetLength(0) && pesho.Y >= 0 && pesho.Y < matrix.GetLength(1))
        {
            sum += matrix[pesho.X, pesho.Y];
        }
        return sum;
    }
}

