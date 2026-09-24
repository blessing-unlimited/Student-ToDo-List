namespace StudentToList_API.Models
{
    public class Student
    {
        //Properties
        public Guid StudentId { get; set; }
        public String Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //Future implementation.
        //public string Password { get; set; } = string.Empty;




    }
}
