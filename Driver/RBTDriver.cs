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

        /// <summary>
        /// Adds the given number to the tree.
        /// </summary>
        /// <param name="number">The given number.</param>
        public virtual void Add(Number number)
        {
            RedBlackTree<Number> rbt = this.RBT;

            rbt.Enqueue(number);
        }

        /// <summary>
        /// Remvoves the given number from the tree.
        /// </summary>
        /// <param name="number">The number to remove.</param>
        public virtual bool Remove(Number number)
        {
            RedBlackTree<Number> rbt = this.RBT;

            bool found = rbt.Remove(number);

            return found;
        }

        /// <summary>
        /// Shows the available driver options.
        /// </summary>
        public virtual void ShowOptions()
        {
            Console.WriteLine("Enter \"0\" to exit the driver.");
            Console.WriteLine("Enter \"1\" to populate the tree.");
            Console.WriteLine("Enter \"2\" to search for a number.");
            Console.WriteLine("Enter \"3\" to get the minimum number.");
            Console.WriteLine("Enter \"4\" to get the maximum number.");
            Console.WriteLine("Enter \"5\" to add a number to the tree.");
            Console.WriteLine("Enter \"6\" to remov a number from the tree.");
        }

        /// <summary>
        /// Gets a number from the user.
        /// </summary>
        /// <returns>The number that the user entered.</returns>
        public virtual int GetNumber()
        {
            int number;

            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Please enter a number.");
            }

            return number;
        }

        /// <summary>
        /// The main method for the driver.
        /// </summary>
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
                    case 5:
                         Console.WriteLine("Enter a number to add:");
                         this.Add(new Number(this.GetNumber()));
                        break;
                    case 6:
                        Console.WriteLine("Enter a number to remove:");
                        int value = this.GetNumber();
                        found = this.Remove(new Number(value));
                        Console.WriteLine("The number, \"" + value.ToString() + "\", was " + (found ? "" : " NOT ") + "found.");
                        break;
                }
            }
        }
    }
}
