using System.IO;
using NewTask.Models;
using SharpYaml.Serialization;

namespace NewTask
{
    public class App
    {
        public Configuration ReadConfiguration()
        {
            var serializer = CreateSerializer();
            var executablePath = GetExecutablePath();
            using (var fileStream = File.OpenRead(Path.Combine(executablePath, "config.yaml")))
            {
                return serializer.Deserialize<Configuration>(fileStream);
            }
        }

        public ProjectsConfiguration ReadProjectsConfiguration()
        {
            var serializer = CreateSerializer();
            var executablePath = GetExecutablePath();
            using (var fileStream = File.OpenRead(Path.Combine(executablePath, "projects.yaml")))
            {
                return serializer.Deserialize<ProjectsConfiguration>(fileStream);
            }
        }

        private Serializer CreateSerializer()
        {
            Serializer serializer = new Serializer();
            serializer.Settings.EmitShortTypeName = true;
            return serializer;
        }

        private string GetExecutablePath()
        {
            return Path.GetDirectoryName(typeof(Program).Assembly.Location);
        }
    }
}