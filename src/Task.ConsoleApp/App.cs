using System;
using System.Data;
using CLAP;
using CLAP.Validation;
using Task.Models;
using YamlDotNet.Serialization;

namespace Task.ConsoleApp
{
    public class App
    {
        [Verb(Aliases = "new", Description = "creates new task", IsDefault = true)]
        public void New(
            [Required, Description("name")] string name, 
            [Required, Description("estimate in hours"), MoreThan(0.1), LessThan(100)] double estimateInHours, 
            [Required, Description("type")] TaskType type,
            [DefaultValue(TaskStatus.Awaiting), Description("status"), Aliases("s")] TaskStatus status,
            [Aliases("a"), Description("assignee")] string assignee,
            [Aliases("p"), Description("priority")] int priority)
        { 
            Console.WriteLine("New");
        }

        [Verb(Aliases = "project", Description = "creates new project")]
        public void Project(
            [Required, Description("id")] string id,
            [Aliases("l"), DefaultValue(false)] bool list,
            [Required, Aliases("n"), Description("name")] string name)
        {
            if (list)
            {

            }
        }
    }
}