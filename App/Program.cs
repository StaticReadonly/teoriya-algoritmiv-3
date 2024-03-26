using Classes;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = CreateArray(100);
            //int[] arr = new int[] {3,10,9,4,1,2,8,7,6,5 };

            Algorithm a = new Algorithm();
            long comps = a.QuickSort2(arr);

            Console.WriteLine("Comparisons: " + comps);
            foreach (var i in arr)
            {
                Console.WriteLine(i);
            }
        }

        static int[] CreateArray(long size)
        {
            int[] res = new int[size];

            for(long i = 0; i < size; i++)
            {
                res[i] = Random.Shared.Next(0, 100);
            }

            return res;
        }
    }
}
