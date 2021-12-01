using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace UserFrontend.Pages
{
    public class IndexModel : PageModel
    {
        public string firstName;
        public string lastName;
        public string email;
        public string userId;
        //public string email;

        public void OnGet()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog= FoodRescue_inlamning_2 ; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sqlQuery = "Select FirstName, LastName,Email,UserId From UserPrivateInfos Where UserId =2";
            SqlCommand cmd = new SqlCommand(sqlQuery,con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                firstName = dr["FirstName"].ToString();
                lastName= dr["lastName"].ToString();
                email = dr["Email"].ToString();
                userId = dr["UserId"].ToString();
            }
            con.Close();
            
        }
        //public void OnGet()
        //{
        //    UserBackend user = new UserBackend(1,"vdhddd");
        //    user.GetUserInfo();
        //    Console.WriteLine(user);
           
        //}
    }
}