using DataLayer.Backend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
namespace UserFrontend.Models
{
    public class Users
    {
        public string typeOfFood { get; set; }
        public string foodName { get; set; }
        public string price { get; set; }
        public string foodboxId { get; set; }
        public string restaurantId { get; set; }
        public string purchaseNumber { get; set; }
        public List<Users> GetUsersInfo(List<Users> firstName)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog= FoodRescue_ProjectDatabase_REAL ; Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            //string sqlQuery = "Select FirstName, LastName,Email,UserId, Password, isAdmin From UserPrivateInfos Where UserId =1 ";
            string sqlQuery = "Select FoodboxId, FoodName,Price,TypeOfFood,PurchaseNumber, RestaurantId From FoodBoxes ";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            //Users users = new Users();
           List<Users> usersInfoList = new List<Users>();

            while (dr.Read())
            {
                Users users = new Users();
                users.typeOfFood = dr["TypeOfFood"].ToString();
                users.foodName = dr["FoodName"].ToString();
                users.price = dr["Price"].ToString();
                users.foodboxId = dr["FoodboxId"].ToString();
                users.purchaseNumber = dr["PurchaseNumber"].ToString();
                users.restaurantId = dr["RestaurantId"].ToString();

                usersInfoList.Add(users);
            }
            con.Close();
            return usersInfoList;

        }
    }
}
