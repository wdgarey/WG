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
            BinarySearchTree<Number> numbers = new BinarySearchTree<Number>();
            Number[] array = new Number[] { new Number(10),  new Number(11), new Number(12) };

            numbers.Enqueue(array[0]);
            numbers.Remove(array[0]);


            //RBTDriver driver = new RBTDriver();

            //driver.Main();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
