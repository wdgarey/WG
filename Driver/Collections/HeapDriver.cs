using System;
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
            Number[] rndArray = new Number[22000000];
            
            Console.WriteLine("Creating array of random numbers.");

            for (int index = 0; index < rndArray.Length; index++)
            {
                rndArray[index] = new Number(rnd.Next());
            }

            Console.WriteLine("Creating heap.");

            MinHeap<Number> heap = new MinHeap<Number>(rndArray);

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
