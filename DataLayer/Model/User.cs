using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model;

public class User
{
    [Display(Name = "User id")]
    public int UserId { get; set; }
    public ICollection<Sale> Sales { get; set; }
    public UserPrivateInfo PrivateInfo { get; set; }
    public override string ToString()
    {
        string str = $"User ID: {UserId}";
        str += PrivateInfo != null
            ? $"\t Name: {PrivateInfo.FullName}\t Email: {PrivateInfo.Email}"
            : "\t This user has no private information and has been deleted";
        return str;
    }
}