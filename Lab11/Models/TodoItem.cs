namespace Lab11.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
} 