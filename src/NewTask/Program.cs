using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Fclp;
using RestSharp.Serializers;
using Newtonsoft.Json;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Json;
using Google.Apis.Services;
using RestSharp;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System.Threading;
using Fclp.Internals;
using NewTask.Models;
using NGitLab;
using TaskStatus = NewTask.Models.TaskStatus;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                return;
            }

            var action = args[0];

            switch (action)
            {
                case "new":

                    break;
                case "state":

                    break;
            }

            var app = new App();
            var configuration = app.ReadConfiguration();
            var projectsConfiguration = app.ReadProjectsConfiguration();

            var parser = new FluentCommandLineParser<Arguments>();
            parser.IsCaseSensitive = false;

            parser.Setup(arg => arg.Name).As('n', "name").Required().WithDescription("Name");
            parser.Setup(arg => arg.Type).As('t', "type").SetDefault(TaskType.Implementation).WithDescription("Type");
            parser.Setup(arg => arg.Status).As('s', "status").SetDefault(TaskStatus.Awaiting).WithDescription("Initial status");
            parser.Setup(arg => arg.EstimateInHours).As('e', "estimate").Required().WithDescription("Estimate in hours");
            parser.Setup(arg => arg.Priority).As('p', "priority").SetDefault(100).WithDescription("Priorty");
            parser.Setup(arg => arg.Assignee).As('a', "assignee").SetDefault(null).WithDescription("Assignee");
            parser.Setup(arg => arg.Description).As('d', "description").SetDefault(null)
                .WithDescription("Description");
            parser.SetupHelp("?", "h", "help")
                .Callback(text => Console.WriteLine(text));

            var result = parser.Parse(args);

            if (!result.HasErrors && !result.HelpCalled)
            {
                var task = parser.Object;
                var trelloHelper = new TrelloHelper(configuration, projectsConfiguration);
                var card = trelloHelper.CreateNewCard(task.Name, task.Status, task.Type, task.Priority, task.EstimateInHours, new DateTime(2017, 8, 18));
            }
            else
            {
                Console.WriteLine(result.ErrorText);
            }
        }
    }
}
