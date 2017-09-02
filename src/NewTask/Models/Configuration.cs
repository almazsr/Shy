namespace NewTask.Models
{
    public class Configuration
    {
        public TrelloConfiguration Trello { get; set; }
        public GoogleApiConfiguration GoogleApi { get; set; }
        public GitlabConfiguration Gitlab { get; set; }
    }
}