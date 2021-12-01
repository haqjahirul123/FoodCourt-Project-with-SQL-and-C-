using DataLayer.Backend;

namespace LoginClient;

public static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        string databaseName = "FoodRescue_ProjectDatabase_REAL";
        AdminBackend adminBackend = new(databaseName);
        adminBackend.CreateDb();

        Application.Run(new LoginClientForm(databaseName));
    }
}