using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model;

public class UserPrivateInfo
{
    [Key]
    [Display(Name = "User id")]
    public int UserId { get; set; }

    [Required] [StringLength(20, MinimumLength = 2)] [Display(Name = "First Name")] public string FirstName { get; set; }

    [Required] [StringLength(20, MinimumLength = 2)] [Display(Name = "Last Name")] public string LastName { get; set; }
    
    [Display(Name = "Full Name")] public string FullName => LastName + ", " + FirstName;

    [Required] [EmailAddress] [StringLength(50)] public string Email { get; set; }

    [Required] public string Password { get; set; }
    [Required] public bool IsAdmin { get; set; }

    [ForeignKey("UserId")] public User User { get; set; }
}