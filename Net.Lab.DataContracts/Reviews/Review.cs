using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Lab.DataContracts.Reviews
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public bool IsPositive { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
