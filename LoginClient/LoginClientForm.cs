using System.Diagnostics;
using DataLayer.Backend;

namespace LoginClient;

    public partial class LoginClientForm : Form
    {
        private readonly string _databaseName;
    private readonly LoginBackend _loginBackend;
        public LoginClientForm(string databaseName)
        {
            _databaseName = databaseName;
            _loginBackend = new LoginBackend(_databaseName);
            InitializeComponent();
        }

    private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = EmailTextBox.Text;
                string password = PasswordTextBox.Text;
                int userId = _loginBackend.LoginCustomerUser(username, password).UserId;
                Close();
                //TODO Starta User client med userId.
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

    private void LoginRestaurantButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = restaurantEmailTextBox.Text;
                string password = restaurantPasswordTextBox.Text;
                int restaurantId = _loginBackend.LoginRestaurantUser(username, password).Restaurant.RestaurantId;
                Close();
                //TODO Starta Restaurant client med restaurantId.
            /*

             typ så här. Eventuellt behövs lite ändras i AdminFrontend.Program för att det ska funka
             RestaurantClient.Program.Main(new string [] {_databaseName, restaurantId.ToString()});
             Ta med id:t och konvertera tillbaka till en int. 
             */
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void AdminLoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = AdminEmailTextBox.Text;
                string password = AdminPasswordTextBox.Text;
                _loginBackend.LoginAdmin(username, password);
                Close();
                //TODO Starta admin client.
                /*

                 typ så här. Eventuellt behövs lite ändras i AdminFrontend.Program för att det ska funka
             AdminFrontend.Program.Main(new string [] {_databaseName});
                 
                 */
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}