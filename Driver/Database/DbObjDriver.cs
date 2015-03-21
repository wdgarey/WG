using System;

using WG.Database;

namespace Driver.Database
{
    /// <summary>
    /// A driver for the database object class.
    /// </summary>
    public class DbObjDriver : IDriver
    {
        /// <summary>
        /// The database connection information.
        /// </summary>
        private DbConnectionInfo dci;

        /// <summary>
        /// Gets or sets the database connection information.
        /// </summary>
        public virtual DbConnectionInfo Dci
        {
            get { return this.dci; }
            set { this.dci = value; }
        }

        /// <summary>
        /// Creates an instance of a database object driver.
        /// </summary>
        public DbObjDriver()
        { }

        /// <summary>
        /// Initializes the database object driver.
        /// </summary>
        protected virtual void Initialize()
        {
            DbConnectionInfo dci = this.PromptForDbConnInfo();

            this.Dci = dci;
        }

        /// <summary>
        /// Prompts the user for the database connection information.
        /// </summary>
        /// <returns>The database connection information.</returns>
        protected virtual DbConnectionInfo PromptForDbConnInfo()
        {
            string server = null;
            string userName = null;
            string password  = null;
            string database = null;

            Console.WriteLine("Enter database connection information.");

            Console.Write("Server: ");
            server = Console.ReadLine();

            Console.Write("Username: ");
            userName = Console.ReadLine();

            Console.Write("Password: ");
            password = Console.ReadLine();

            Console.Write("Database: ");
            database = Console.ReadLine();

            DbConnectionInfo dci = new DbConnectionInfo(server, userName, password, database);
            
            return dci;
        }

        /// <summary>
        /// Prompts the user for a user name.
        /// </summary>
        /// <returns>The user name.</returns>
        protected virtual string PromptForUsername()
        {
            string username = null;

            Console.Write("Username: ");
            username = Console.ReadLine();

            return username;
        }

        /// <summary>
        /// Prompts the user for for a user password.
        /// </summary>
        /// <returns>The user password.</returns>
        protected virtual string PromptForPassword()
        {
            string password = null;

            Console.Write("Password: ");
            password = Console.ReadLine();

            return password;
        }

        /// <summary>
        /// Prompts the user for a main menu selection.
        /// </summary>
        /// <returns>The option that the user chose.</returns>
        protected virtual int PromptWithMenu()
        {
            int option = -1;

            bool validOption = false;
            while (!validOption)
            {
                Console.WriteLine("Enter 0 to exit.");
                Console.WriteLine("Enter 1 to select a user.");
                Console.WriteLine("Enter 2 to insert a new user.");
                string input = Console.ReadLine();

                if(!int.TryParse(input, out option))
                {
                    Console.WriteLine("The option must be an integer.");
                }
                else if (option < 0 && option > 2)
                {
                    Console.WriteLine("The option is out of the option range.");
                }
                else
                {
                    validOption = true;
                }
            }

            return option;
        }

        /// <summary>
        /// The main method of the database object driver.
        /// </summary>
        public void Main()
        {
            this.Initialize();            
            DbConnectionInfo dci = this.Dci;

            DbObjUser user = new DbObjUser(dci, "");

            int option = this.PromptWithMenu();

            while (option != 0)
            {
                switch (option)
                {
                    case 1:
                        user.Name = this.PromptForUsername();                        
                        user.Select();
                        break;
                    case 2:
                        user.Name = this.PromptForUsername();                        
                        user.Password = this.PromptForPassword();
                        user.EncryptPw();
                        user.Insert();
                        break;
                }

                option = this.PromptWithMenu();
            }
        }
    }
}
