using System;

namespace MediaLibraryApp
{
    /// <summary>
    /// Represents a Music Album, derived from MediaItem.
    /// </summary>
    public class MusicAlbum : MediaItem
    {
        public string Artist { get; set; }
        public int TrackCount { get; set; }

        public MusicAlbum(string id, string title, int releaseYear, string artist, int trackCount) 
            : base(id, title, releaseYear)
        {
            Artist = artist;
            TrackCount = trackCount;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"      Type: Music Album | Artist: {Artist} | Tracks: {TrackCount}");
            Console.WriteLine(new string('-', 40));
        }

        public override bool MatchesSearch(string query)
        {
            return base.MatchesSearch(query) || 
                   Artist.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}