using System;

namespace MediaLibraryApp
{
    /// <summary>
    /// Represents a DVD, derived from MediaItem.
    /// </summary>
    public class DVD : MediaItem
    {
        public string Director { get; set; }
        public int RunTimeMinutes { get; set; }

        public DVD(string id, string title, int releaseYear, string director, int runTimeMinutes) 
            : base(id, title, releaseYear)
        {
            Director = director;
            RunTimeMinutes = runTimeMinutes;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"      Type: DVD | Director: {Director} | Runtime: {RunTimeMinutes} mins");
            Console.WriteLine(new string('-', 40));
        }

        public override bool MatchesSearch(string query)
        {
            return base.MatchesSearch(query) || 
                   Director.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}