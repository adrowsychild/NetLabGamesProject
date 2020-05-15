using System;
using System.ComponentModel.DataAnnotations;

namespace Net.Lab.DataContracts.Awards
{
    public class Award
    {
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
