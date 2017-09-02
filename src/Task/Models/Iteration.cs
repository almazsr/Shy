using System;

namespace Task.Models
{
    public class Iteration
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public bool Closed { get; set; }
    }
}