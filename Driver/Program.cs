using System;

using WG.Collections.Vectors;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            RBTDriver driver = new RBTDriver();

            driver.Main();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
