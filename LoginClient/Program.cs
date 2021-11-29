using DataLayer.Backend;

namespace LoginClient
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            AdminBackend adminBackend = new AdminBackend("FoodRescue_ProjectDatabase_REAL");
            adminBackend.CreateDb();
            Application.Run(new LoginClientForm("FoodRescue_ProjectDatabase_REAL"));
        }
    }
}