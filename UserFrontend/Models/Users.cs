using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
namespace UserFrontend.Models
{
    public class Users
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userId { get; set; }
        public string passWord { get; set; }
        public string isAdmin { get; set; }
        public List<Users> GetUsersInfo()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog= FoodRescue_ProjectDatabase_REAL ; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlQuery = "Select FirstName, LastName,Email,UserId, Password, isAdmin From UserPrivateInfos Where UserId =2";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            //Users users = new Users();
           List<Users> usersInfoList = new List<Users>();

            while (dr.Read())
            {
                Users users = new Users();
                users.firstName = dr["FirstName"].ToString();
                users.lastName = dr["lastName"].ToString();
                users.email = dr["Email"].ToString();
                users.userId = dr["UserId"].ToString();
                users.passWord = dr["Password"].ToString();
                users.isAdmin = dr["isAdmin"].ToString();

                usersInfoList.Add(users);
            }
            con.Close();
            return usersInfoList;

        }
    }
}
