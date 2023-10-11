using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Milestone_CST_350.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Please Enter your Full First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Please Enter your Full Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Please Enter your Gender")]
        public string Sex { get; set; }
        [Required]
        [Range (1,100)]
        [DisplayName("Please Enter your Age")]
        public int Age { get; set; }
        [Required]
        [DisplayName("Please Enter State")]
        public string State { get; set; }
        [Required]
        [DisplayName("Please Enter Valid Email Address")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        public RegistrationModel()
        {
        }
    }
}
