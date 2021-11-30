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
                Console.WriteLine("\n\tWelcome admin.\n\t\t" +
                                  "Please choose an option");
                Console.Write("\t\t[1] Reset database\n\t\t" +
                                  "[2] Display all user records\n\t\t" +
                                  "[3] Display all restaurant records\n\t\t" +
                                  "[4] Add restaurant record\n\t\t" +
                                  "[0] Exit program\n\t\t");
                
                var menuInput = Console.ReadKey();
                int menuChoice = -1;
                
                try
                {
                    menuChoice = int.Parse(menuInput.KeyChar.ToString());

                    if (menuChoice < 0 || menuChoice > 4)
                    {
                        throw new Exception();
                    }

                    switch (menuChoice)
                    {
                        case 1:
                            ResetDatabasePrompt();
                            ReturnToMainMenuPrompt();
                            break;

                        case 2:
                            DisplayAllUsers();
                            ReturnToMainMenuPrompt();
                            break;

                        case 3:
                            DisplayAllRestaurants();
                            ReturnToMainMenuPrompt();
                            break;

                        case 4:
                            AddRestaurantRecord();
                            ReturnToMainMenuPrompt();
                            break;

                        case 0:
                            runProgram = ExitProgramPrompt();
                            break;
                    }
                    Console.Clear();
                }
                catch
                {
                    Console.Write("\tInvalid input, please try again");

                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        catch
        {
            Console.Write("\tAn unexpected error has accoured\n" +
                              "\tPlease press enter to restart");

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

void ResetDatabasePrompt()
{
    var admin = new AdminBackend();
    while (true)
    {
        Console.Clear();
        string prompt = "\n\tAll changes and additions will be deleted and the database will be reset to its default state\n" +
                        "\n\tAre you sure you want to reset the database?";

        bool answer = YesNoPrompt(prompt, true);

        if (answer)
        {
            admin.CreateAndSeedDb();

            Console.WriteLine("\n\tDatabase has been reset!");
            break;
        }

        if (!answer)
        {
            Console.Clear();

            Console.WriteLine("\n\tNo changes has been made to the database");
            break;
        }
    }
}

void DisplayAllUsers()
{
    var admin = new AdminBackend();

    Console.Clear();

    Console.WriteLine("\n\tUsers on record:\n");

    var users = admin.GetUsers();
    foreach (var user in users)
    {
        Console.WriteLine("\t\t" + user);
    }
}

void DisplayAllRestaurants()
{
    var admin = new AdminBackend();

    Console.Clear();

    Console.WriteLine("\n\tRestaurants on record:\n");

    var restaurants = admin.GetRestaurants();
    foreach (var restaurant in restaurants)
    {
        Console.WriteLine("\t\t" + restaurant);
    }

    string prompt = "\n\tDo you want to add a restaurant?";
    bool answer = YesNoPrompt(prompt, false);

    if (answer)
    {
        AddRestaurantRecord();
    }
}

void AddRestaurantRecord()
{
    string name = "";
    string phoneNumber = "";
    bool runLoop = true;

    while (runLoop)
    {
        while (runLoop)
        {
            Console.Clear();
            
            Console.Write("\n\tPlease enter the name of the restaurant:\n\n\t\t");
            name = Console.ReadLine();

            if (name.Length < 3 || name.Length > 30)
            {
                Console.WriteLine("\n\tRestaurant name has to be between 3 and 30 characters\n" +
                                  "\tIf restaurant name is shorter than 3 characters, get rekt\n" + //jk
                                  "\tPress enter to try again");
                Console.ReadKey();
            }
            else
            {
                runLoop = false;
            }
        }

        runLoop = true;
        while (runLoop)
        {
            Console.Clear();
            Console.Write("\n\tPlease enter the phonenumber of the restaurant:\n\n\t\t");
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Length < 3 || phoneNumber.Length > 30)
            {
                Console.WriteLine("\n\tRestaurant phonenumber has to be between 3 and 30 characters\n" +
                                  "\tPress enter to try again");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                runLoop = false;
            }
        }

        Console.Clear();

        string prompt = $"\n\tDo you want to add the restaurant {name} with the phonenumber {phoneNumber} to the database?";
        bool answer = YesNoPrompt(prompt, true);

        if (answer)
        {
            var admin = new AdminBackend();
            admin.AddRestaurant(name, phoneNumber);
            Console.WriteLine($"\n\t{name} has been added to the database");

            DisplayAllRestaurants();
        }
        else
        {
            prompt = $"\n\t{name} was not added\n" +
                     $"\n\tDo you want to start over? Selecting no will return you to the main menu";
            runLoop = YesNoPrompt(prompt, true);
        }
    }
}

bool ExitProgramPrompt()
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
            return true;
        }

        Console.Clear();
    }
}

bool YesNoPrompt(string outputPrompt, bool clearConsole)
{
    while (true)
    {
        Console.Write($"\t{outputPrompt}\n\n\t[y/n]\t");

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

void ReturnToMainMenuPrompt()
{
    Console.Write("\n\tPlease press enter to return to the menu");
    
    Console.ReadLine();
}