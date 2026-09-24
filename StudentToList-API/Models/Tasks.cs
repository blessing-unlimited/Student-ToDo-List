namespace StudentToList_API.Models
{
    public class Tasks
    {
        //Properties
        public int Id { get; set; }
        public Guid StudentId { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public Importance ImportanceList { get; set; }

        public enum Importance
        {
            Low, Medium, High
        }
    }
}
