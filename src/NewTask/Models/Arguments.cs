namespace NewTask.Models
{
    public class Arguments
    {
        public string Name { get; set; }
        public int EstimateInHours { get; set; }
        public int Priority { get; set; }
        public string Assignee { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
    }
}