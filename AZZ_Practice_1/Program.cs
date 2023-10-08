using System.IO.Pipes;

namespace AZZ_Practice_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Task1();
            Task2();
            Task34();
        }

        private static void FillArraySpiral(int[][] arr)
        {
            int count = 1;

            int offset = 0; //отступ от краев

            int size = arr.Length * arr[0].Length;

            while (count <= size)
            {
                for (int i = 0; i < arr[0].Length && count <= size; i++)
                {
                    if (arr[offset][i] != 0) continue;

                    arr[offset][i] = count;
                    count++;
                }

                for (int i = 0; i < arr.Length && count <= size; i++)
                {
                    if (arr[i][arr[0].Length - 1 - offset] != 0) continue;

                    arr[i][arr[0].Length - 1 - offset] = count;
                    count++;
                }

                for (int i = arr[0].Length - 1; i >= 0 && count <= size; i--)
                {
                    if (arr[arr.Length - 1 - offset][i] != 0) continue;

                    arr[arr.Length - 1 - offset][i] = count;
                    count++;
                }

                for (int i = arr.Length - 1; i >= 0 && count <= size; i--)
                {
                    if (arr[i][offset] != 0) continue;

                    arr[i][offset] = count;
                    count++;
                }

                offset++;
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
        } //инициализирует двумерный массив

        private static void PrintArrayReverse(int[] arr)
        {
            Console.WriteLine("Реверснутый массив");

            for (int i = (arr.Length - 1); i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
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

        private static void Task1()
        {
            Console.WriteLine("-------------- Задание №1 --------------\n");

            Console.Write("Введите длину массива: ");
            int N = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                arr[i] = i+1;
            }


            PrintArrayReverse(arr);
        }

        private static void Task2()
        {
            Console.WriteLine("-------------- Задание №2 --------------\n");

            Console.Write("Введите размерность матрицы: ");
            int N = Convert.ToInt32(Console.ReadLine());


            int[][] arr = GetArray(N, N);

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    arr[i][j] = 1;
                }
            }


            int count = 0;
            for (int i = 2; i < N; i++)
            {

                for (int j = 0; j < N; j++)
                {
                    if (count >= j) continue;
                    arr[i][j] = 1;
                }
                count++;
            }

            PrintArray(arr);
            Console.WriteLine();
        }

        private static void Task34()
        {
            Console.WriteLine("-------------- Задание №3-4 --------------\n");

            Console.Write("Введите количество строк: ");
            int M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество столбцов: ");
            int N = Convert.ToInt32(Console.ReadLine());

            int[][] arr = GetArray(M, N);

            FillArraySpiral(arr);

            PrintArray(arr);
        }
    }
}