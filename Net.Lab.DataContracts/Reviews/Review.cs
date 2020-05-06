using System;

namespace Net.Lab.DataContracts.Reviews
{
    public class Review
    {
        public int Id { get; set; }

        public bool IsPositive { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}
