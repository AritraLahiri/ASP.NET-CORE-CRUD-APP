namespace EdominarAssignmentTask.Models
{
    public class UserInfo
    {

        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string State { get; set; } = String.Empty;
        public string Hobby { get; set; } = String.Empty;
        public int HobbyId { get; set; }
        public int StateId { get; set; }
        public string Mobile { get; set; } = String.Empty;

    }
}
