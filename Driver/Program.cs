using System;
using System.Threading;
using System.Threading.Tasks;

using WG.Collections.Trees;

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
