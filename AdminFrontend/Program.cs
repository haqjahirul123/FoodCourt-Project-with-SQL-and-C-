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


                string menuInput = Console.ReadLine(); //TODO Gör om till en ReadKey. Fick dock inte if satsen att funka när den hade villkor som skulle godkänna numpad också... Får titta senare
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

            Console.WriteLine("Database has been reset!");
            //ReturnToMainMenuPrompt();
            break;
        }

        if (!answer)
        {
            Console.Clear();

            Console.WriteLine("No changes has been made to the database");
            //ReturnToMainMenuPrompt();
            break;
        }
    }
}

void DisplayAllUsers()
{
    var admin = new AdminBackend();

    Console.Clear();

    Console.WriteLine("Users on record:\n");

    var users = admin.GetUsers();
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }

    //ReturnToMainMenuPrompt();
}

void DisplayAllRestaurants()
{
    var admin = new AdminBackend();

    Console.Clear();

    Console.WriteLine("Restaurants on record:\n");

    var restaurants = admin.GetRestaurants();
    foreach (var restaurant in restaurants)
    {
        Console.WriteLine(restaurant);
    }

    string prompt = "\nDo you want to add a restaurant?";
    bool answer = YesNoPrompt(prompt, false);

    if (answer)
    {
        AddRestaurantRecord();
    }

    //ReturnToMainMenuPrompt();
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

            Console.WriteLine("Please enter the name of the restaurant:");
            name = Console.ReadLine();

            if (name.Length < 3 || name.Length > 30)
            {
                Console.WriteLine("\nRestaurant name has to be between 3 and 30 characters\n" +
                                  "If restaurant name is shorter than 3 characters, get rekt\n" + //jk
                                  "Press enter to try again");
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
            Console.WriteLine("Please enter the phonenumber of the restaurant:");
            phoneNumber = Console.ReadLine();
            if (phoneNumber.Length < 3 || phoneNumber.Length > 30)
            {
                Console.WriteLine("\nRestaurant phonenumber has to be between 3 and 30 characters\n" +
                                  "Press enter to try again");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                runLoop = false;
            }
        }

        Console.Clear();

        string prompt = $"Do you want to add the restaurant {name} with the phonenumber {phoneNumber} to the database?";
        bool answer = YesNoPrompt(prompt, true);

        if (answer)
        {
            var admin = new AdminBackend();
            admin.AddRestaurant(name, phoneNumber);
            Console.WriteLine($"{name} has been added to the database");

            DisplayAllRestaurants();
        }
        else
        {
            prompt = $"{name} was not added\n\n" +
                     $"Do you want to start over? Selecting no will return you to the main menu";
            runLoop = !YesNoPrompt(prompt, true);
        }
    }

    //ReturnToMainMenuPrompt();
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
            //ReturnToMainMenuPrompt();
            return true;
        }

        Console.Clear();
    }
}

bool YesNoPrompt(string outputPrompt, bool clearConsole)
{
    while (true)
    {
        Console.Write($"{outputPrompt}\n[y/n]\t");

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
    Console.WriteLine("\nPlease press enter to return to the menu");
    
    
    Console.ReadLine();
}