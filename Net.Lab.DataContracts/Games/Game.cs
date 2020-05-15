using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Lab.DataContracts.Games
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1950, 2020)]
        public int ReleaseYear { get; set; }
    }
}
