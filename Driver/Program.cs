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
            driver = new HeapDriver();

            if (driver != null)
            {
                driver.Main();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
