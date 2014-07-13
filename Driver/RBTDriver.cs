using System;
using System.Threading.Tasks;

using WG.Collections.Trees;

namespace Driver
{
    /// <summary>
    /// A Red-Black tree driver.
    /// </summary>
    public class RBTDriver
    {
        /// <summary>
        /// The Red-Black tree.
        /// </summary>
        private RedBlackTree<Number> rbt;

        /// <summary>
        /// Accessor to the Red-Black tree.
        /// </summary>
        public RedBlackTree<Number> RBT
        {
            get { return this.rbt; }
            set { this.rbt = value; }
        }

        /// <summary>
        /// Creates an instance of an RBTDriver.
        /// </summary>
        public RBTDriver()
        {
            this.RBT = new RedBlackTree<Number>();
        }

        /// <summary>
        /// Populates the tree with random numbers until the given flag is set to TRUE.
        /// </summary>
        /// <param name="stop">The given flag.</param>
        public virtual void PopulateTree(ref bool stop)
        {
            RedBlackTree<Number> rbt = this.RBT;
            int value = -1;
            if (!rbt.IsEmpty())
            {
                Number start = null;
                rbt.GetMax(out start);
            }

            while (!stop)
            {
                value++;

                rbt.Enqueue(new Number(value));
            }
        }

        /// <summary>
        /// Gets the smallest number found in the tree.
        /// </summary>
        /// <returns>The smallest number found in the tree.</returns>
        public virtual Number GetMin()
        {
            RedBlackTree<Number> rbt = this.RBT;

            Number min = null;
            rbt.GetMin(out min);

            return min;
        }

        /// <summary>
        /// Gets the largest number found in the tree.
        /// </summary>
        /// <returns>The largest number found in the tree.</returns>
        public virtual Number GetMax()
        {
            RedBlackTree<Number> rbt = this.RBT;

            Number max = null;
            rbt.GetMax(out max);

            return max;
        }

        /// <summary>
        /// Gets the number of elements in the tree.
        /// </summary>
        /// <returns>The number of elements stored in the tree.</returns>
        public virtual int GetCount()
        {
            RedBlackTree<Number> rbt = this.RBT;

            return rbt.Count;
        }

        /// <summary>
        /// Indicates whether or not the given number exists within the tree.
        /// </summary>
        /// <param name="number">The number to search for.</param>
        /// <returns>True, if the number was found.</returns>
        public virtual bool SearchFor(Number number)
        {
            RedBlackTree<Number> rbt = this.RBT;
            bool found = rbt.Search(number);

            return found;
        }

        public virtual void ShowOptions()
        {
            Console.WriteLine("Enter \"0\" to exit the driver.");
            Console.WriteLine("Enter \"1\" to populate the tree.");
            Console.WriteLine("Enter \"2\" to search for a number.");
            Console.WriteLine("Enter \"3\" to get the minimum number.");
            Console.WriteLine("Enter \"4\" to get the maximum number.");
        }

        public virtual int GetNumber()
        {
            int number;

            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Please enter a number.");
            }

            return number;
        }

        public virtual void Main()
        {
            bool run = true;

            while (run)
            {
                this.ShowOptions();
                int option = this.GetNumber();

                switch (option)
                {
                    case 0:
                        run = false;
                        break;
                    case 1:
                        Console.WriteLine("Populating tree...");
                        bool stop = false;
                        Task.Factory.StartNew(() => { this.PopulateTree(ref stop); });
                        Console.WriteLine("Press enter to stop.");
                        Console.ReadLine();
                        stop = true;
                        break;
                    case 2:
                        Console.WriteLine("Enter number to search for:");
                        Number number = new Number(this.GetNumber());
                        bool found = this.SearchFor(number);
                        Console.WriteLine("The number, \"" + number.ToString() + "\", was " + (found ? "" : " NOT ") + "found.");
                        break;
                    case 3:
                        Number min = this.GetMin();
                        Console.WriteLine("The smallest number is: " + min.ToString());
                        break;
                    case 4:
                        Number max = this.GetMax();
                        Console.WriteLine("The largest number is: " + max.ToString());
                        break;
                }
            }
        }
    }
}
