namespace AZZ_Practice_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int N = Convert.ToInt32(Console.ReadLine());

            int[][] arr = GetArray(M, N);

            FillArraySpiral(arr);

            PrintArray(arr);
        }

        private static void FillArraySpiral(int[][] arr)
        {
            int count = 1;

            int index = 0;

            int size = arr.Length * arr[0].Length;

            while (count <= size)
            {
                for (int i = 0; i < arr[0].Length && count <= size; i++)
                {
                    if (arr[index][i] != 0) continue;

                    arr[index][i] = count;
                    count++;
                }

                for (int i = 0; i < arr.Length && count <= size; i++)
                {
                    if (arr[i][arr[0].Length - 1 - index] != 0) continue;

                    arr[i][arr[0].Length - 1 - index] = count;
                    count++;
                }

                for (int i = arr[0].Length - 1; i >= 0 && count <= size; i--)
                {
                    if (arr[arr.Length - 1 - index][i] != 0) continue;

                    arr[arr.Length - 1 - index][i] = count;
                    count++;
                }

                for (int i = arr.Length - 1; i >= 0 && count <= size; i--)
                {
                    if (arr[i][index] != 0) continue;

                    arr[i][index] = count;
                    count++;
                }

                index++;
            }
        }

        private static int[][] GetArray(int M, int N)
        {
            int[][] arr = new int[M][];
            for (int i = 0; i < M; i++)
            {
                arr[i] = new int[N];
            }
            return arr;
        }

        private static void PrintArray(int[][] arr)
        {
            Console.WriteLine("\nДвумерный массив");

            foreach (int[] rows in arr)
            {
                foreach (int item in rows)
                    Console.Write(item + " ");
                Console.WriteLine("");
            }
        }
    }
}