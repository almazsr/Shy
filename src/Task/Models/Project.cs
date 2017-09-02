using System;
using System.Collections.Generic;

namespace Task.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LocalPath { get; set; }

        public List<Iteration> Iterations { get; set; }
    }
}