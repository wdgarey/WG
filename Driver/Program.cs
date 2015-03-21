using System;

using Driver.Database;
using Driver.Collections;
using WG.Collections.Linked;

namespace Driver
{
    /// <summary>
    /// The driver program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main method of the driver program.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            IDriver driver = null;
            //driver = new RBTDriver();
            //driver = new DbObjDriver();
            //driver = new HeapDriver();

            if (driver != null)
            {
                driver.Main();
            }

            List<int> numbers = new List<int>();

            numbers.Remove(1);
            numbers.Add(1);
            numbers.RemoveAt(0);
            numbers.RemoveAt(0);
            numbers.Add(1);
            
            foreach(int n in numbers)
            {   
                Console.WriteLine(n.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
