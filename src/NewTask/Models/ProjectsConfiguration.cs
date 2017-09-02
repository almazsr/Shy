using System.Collections.Generic;

namespace NewTask.Models
{
    public class ProjectsConfiguration
    {
        public string CurrentProjectId { get; set; }
        public Dictionary<string, ProjectConfiguration> Projects { get; set; }
    }
}