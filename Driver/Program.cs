using System;

using WG.Collections.Vectors;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Number[] array = new Number[100];
            for (int index = 0; index < array.Length; index++)
            {
                array[index] = new Number(rnd.Next(array.Length));
            }

            Heap<Number> heap = new MaxHeap<Number>(array);

            int count = 1;
            Number number = null;
            while (heap.Dequeue(out number))
            {   
                Console.WriteLine(count + ": " + number.ToString());
                count++;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
