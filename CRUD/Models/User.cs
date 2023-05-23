using System.ComponentModel.DataAnnotations;

namespace EdominarAssignmentTask.Models
{
    public class User
    {
        [Display(Name = "Full Name")]
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; } = String.Empty;
        [Required]
        [Range(10, 10, ErrorMessage = "Please enter valid Phone Number")]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public int Mobile { get; set; }
        [Display(Name = "State")]
        [Required]
        public State? State { get; set; }
        [Display(Name = "Hobby")]
        [Required]
        public Hobby? Hobbies { get; set; }
        [Display(Name = "Gender")]
        [Required]
        public int Gender { get; set; }

    }
}
