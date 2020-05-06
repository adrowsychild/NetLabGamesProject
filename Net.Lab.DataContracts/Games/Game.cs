using System;
using Net.Lab.DataContracts.Awards;
using Net.Lab.DataContracts.Reviews;

namespace Net.Lab.DataContracts.Games
{
    public class Game
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        public Award[] Awards { get; set; }

        public Review[] Reviews { get; set; }
    }
}
