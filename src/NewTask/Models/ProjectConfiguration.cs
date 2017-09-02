namespace NewTask.Models
{
    public class ProjectConfiguration
    {
        public string Name { get; set; }
        public TrelloProjectConfiguration Trello { get; set; }
    }
}