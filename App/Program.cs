using Classes;

namespace App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string[] files = new string[]
            {
                "input_01_10.txt",
                "input_02_10.txt",
                "input_03_10.txt",
                "input_04_10.txt",
                "input_05_10.txt",
                "input_06_100.txt",
                "input_07_100.txt",
                "input_08_100.txt",
                "input_09_100.txt",
                "input_10_100.txt",
                "input_11_1000.txt",
                "input_12_1000.txt",
                "input_13_1000.txt",
                "input_14_1000.txt",
                "input_15_1000.txt",
                "input_16_10000.txt",
                "input_17_10000.txt",
                "input_18_10000.txt",
                "input_19_10000.txt",
                "input_20_10000.txt"
            };

            FileHelper helper = new FileHelper();
            Algorithm alg = new Algorithm();
            foreach (var file in files)
            {
                string root = "D:\\KPI Labs\\Теорія алгоритмів\\lab3\\Classes\\tests";
                int[] newarr1 = await helper.ReadFile(Path.Combine(root, "input", file));
                int[] newarr2 = (int[])newarr1.Clone();
                int[] newarr3 = (int[])newarr1.Clone();

                long c1 = alg.QuickSort1(newarr1);
                long c2 = alg.QuickSort2(newarr2);
                long c3 = alg.QuickSort3(newarr3);

                string file_out = file.Replace("input", "output");

                await helper.WriteFile(Path.Combine(root, "output", file_out), c1, c2, c3);
            }

            //Test random

            //int[] arr = CreateArray(10000);

            //Algorithm a = new Algorithm();
            //long comps = a.QuickSort3(arr);

            //Console.WriteLine("Comparisons: " + comps);
            //foreach (var i in arr)
            //{
            //    Console.WriteLine(i);
            //}
        }

        static int[] CreateArray(long size)
        {
            int[] res = new int[size];

            for(long i = 0; i < size; i++)
            {
                res[i] = Random.Shared.Next(0, 10000);
            }

            return res;
        }
    }
}
