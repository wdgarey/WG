using System;
using System.Diagnostics;

using WG.Collections.Vectors;

namespace Driver.Collections
{
    /// <summary>
    /// A driver to test the heaps.
    /// </summary>
    public class HeapDriver : IDriver
    {
        /// <summary>
        /// The main method of the driver.
        /// </summary>
        public void Main()
        {
            Random rnd = new Random();
            Number[] rndArray = new Number[100000000];
            
            Console.WriteLine("Creating array of random numbers.");

            for (int index = 0; index < rndArray.Length; index++)
            {
                rndArray[index] = new Number(rnd.Next());
            }

            Console.WriteLine("Creating heap.");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            MinHeap<Number> heap = new MinHeap<Number>(rndArray);
            timer.Stop();

            TimeSpan time = timer.Elapsed;

            Console.WriteLine("Heap created in " + time.ToString());

            int sect = 25;
            int count = 1;
            while(count <= sect)
            {
                Number n = null;
                
                heap.Dequeue(out n);

                Console.WriteLine(count.ToString("N0") + ": " + n);

                count++;
            }

            Console.WriteLine("...");

            while(heap.Count > sect)
            {
                Number n = null;

                heap.Dequeue(out n);

                count++;
            }

            while(!heap.IsEmpty())
            {
                Number n = null;

                heap.Dequeue(out n);

                Console.WriteLine(count.ToString("N0") + ": " + n);

                count++;
            }

            return;
        }
    }
}
