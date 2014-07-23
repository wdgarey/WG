using System;

using WG.Collections.Trees;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 100000;
            Number number = null;
            Random rnd = new Random();

            RedBlackTree<Number> tree = new RedBlackTree<Number>();

            int value;
            while(int.TryParse(Console.ReadLine(), out value))
            {
                number = new Number(value);
                tree.Enqueue(number);
            }
            
            while (int.TryParse(Console.ReadLine(), out value))
            {
                number = new Number(value);
                tree.Remove(number);
            }

            Number[] array = tree.GetInOrder();

            int position = 1;
            foreach (Number n in array)
            {
                //Console.WriteLine(position + ": " + n.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
