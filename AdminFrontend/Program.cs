using DataLayer.Backend;

MainMenu();

void MainMenu()
{
    CreateDatabase();

    bool runProgram = true;

    while (runProgram)
    {
        try
        {
            while (runProgram)
            {
                Console.WriteLine("Welcome admin. Please choose an option");
                Console.WriteLine("[1] Reset database\n" +
                                  "[2] Display all user records\n" +
                                  "[3] Display all restaurant records\n" +
                                  "[4] Add restaurant record\n" +
                                  "[0] Exit program");


                string menuInput = Console.ReadLine();//Gör om till en ReadKey? Fick dock inte if satsen att funka när den hade villkor som skulle godkänna numpad också... Får titta senare
                int menuChoice = -1;

                try
                {
                    menuChoice = Convert.ToInt32(menuInput);

                    if (menuChoice < 0 || menuChoice > 4)
                    {
                        throw new Exception();
                    }

                    switch (menuChoice)
                    {
                        case 1:
                            ResetDatabasePrompt();
                            break;

                        case 2:
                            DisplayAllUsers();
                            break;

                        case 3:
                            DisplayAllRestaurants();
                            break;

                        case 4:
                            AddRestaurantRecord();
                            break;

                        case 0:
                            runProgram = ContinueProgramPrompt();
                            break;
                    }
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine("Invalid input, please try again");

                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        catch
        {
            Console.WriteLine("An unexpected error has accoured\n" +
                              "Please press enter to restart");

            Console.ReadLine();
            Console.Clear();
        }
    }
}

void CreateDatabase()
{
    var admin = new AdminBackend();
    admin.CreateAndSeedDb();
}

bool YesNoPrompt(string outputPrompt, bool clearConsole)
{
    while (true)
    {
        Console.WriteLine($"{outputPrompt}\n[y/n]\t");

        var keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.Y)
        {
            if (clearConsole)
            {
                Console.Clear();
            }
            return true;
        }

        if (keyInfo.Key == ConsoleKey.N)
        {
            if (clearConsole)
            {
                Console.Clear();
            }
            return false;
        }

        if (clearConsole)
        {
            Console.Clear();
        }
    }
}

void ResetDatabasePrompt()
{
    var admin = new AdminBackend();
    while (true)
    {
        Console.Clear();
        string prompt = "All changes and additions will be deleted and the database will be reset to its default state\n" +
                        "Are you sure you want to reset the database?";

        bool answer = YesNoPrompt(prompt, true);

        if (answer)
        {
            admin.CreateAndSeedDb();

            Console.WriteLine("Database has been reset!\n" +
                              "Please press enter to return to the menu");

            Console.ReadLine();
            break;
        }

        if (!answer)
        {
            Console.Clear();

            Console.WriteLine("No changes has been made to the database\n" +
                              "Please press enter to return to the menu");
            Console.ReadLine();
            break;
        }
    }
}

bool ContinueProgramPrompt()
{
    while (true)
    {
        Console.Clear();

        string prompt = "Are you sure you want to exit the program?";
        bool answer = YesNoPrompt(prompt, true);

        if (answer)
        {
            return false;
        }

        if (!answer)
        {
            Console.WriteLine("Please press enter to return to the menu");

            Console.ReadLine();
            return true;
        }

        Console.Clear();
    }
}

void DisplayAllUsers()
{
    //TODO Display all users
}

void DisplayAllRestaurants()
{
    //TODO Display all restaurants
}

void AddRestaurantRecord()
{
    //TODO Add restaurant record
}