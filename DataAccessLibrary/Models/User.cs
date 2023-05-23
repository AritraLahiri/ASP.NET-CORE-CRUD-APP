using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLibrary.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = String.Empty;
        [Required]
        public string Address { get; set; } = String.Empty;
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; } = String.Empty;
        [Display(Name = "State")]
        [Required]
        public int StateId { get; set; }
        [ForeignKey(nameof(StateId))]
        public State? State { get; set; }
        [Display(Name = "Hobby")]
        [Required]
        public int HobbyId { get; set; }
        [ForeignKey(nameof(HobbyId))]
        public Hobby? Hobbies { get; set; }
        [Required]
        public string Gender { get; set; } = String.Empty;

    }
}
