using System;

using WG.Collections.Trees;

namespace Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            RedBlackTree<Number> numbers = new RedBlackTree<Number>();

            int number;
            //while (int.TryParse(Console.ReadLine(), out number))
            for(int x = 0; x < 1000000; x++)
            {
                number = rnd.Next();
                numbers.Enqueue(new Number(number));
                Console.WriteLine();
            }

            Number[] array = numbers.GetInOrder();

            foreach (Number n in array)
            {
                Console.WriteLine(n.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    class Number : WG.Collections.Interfaces.IRelatable<Number>
    {
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Number(int value)
        {
            this.Value = value;
        }

        public bool IsEqualTo(Number comparable)
        {
            return (this.Value == comparable.Value);
        }

        public bool IsLessThan(Number comparable)
        {
            return (this.Value < comparable.Value);
        }

        public bool IsGreaterThan(Number comparable)
        {
            return (this.Value > comparable.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString("N");
        }
    }
}
