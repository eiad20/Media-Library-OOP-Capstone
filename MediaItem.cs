using System;
using System.Text.Json.Serialization;

namespace MediaLibraryApp
{
    /// <summary>
    /// Represents an abstract base class for all media types.
    /// </summary>
    [JsonDerivedType(typeof(Book), typeDiscriminator: "Book")]
    [JsonDerivedType(typeof(DVD), typeDiscriminator: "DVD")]
    [JsonDerivedType(typeof(MusicAlbum), typeDiscriminator: "MusicAlbum")]
    public abstract class MediaItem : IBorrowable
    {
        private string _id;
        private string _title;
        private int _releaseYear;

        public string Id
        {
            get { return _id; }
            set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                    throw new ArgumentException("ID cannot be empty.");
                _id = value; 
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty.");
                _title = value;
            }
        }

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set
            {
                if (value < 1000 || value > DateTime.Now.Year + 1)
                    throw new ArgumentException("Invalid release year.");
                _releaseYear = value;
            }
        }

        [JsonInclude]
        public bool IsBorrowed { get; private set; }

        protected MediaItem(string id, string title, int releaseYear)
        {
            Id = id;
            Title = title;
            ReleaseYear = releaseYear;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            if (IsBorrowed)
                Console.WriteLine($"[Error] '{Title}' is already borrowed.");
            else
            {
                IsBorrowed = true;
                Console.WriteLine($"[Success] You have borrowed '{Title}'.");
            }
        }

        public void Return()
        {
            if (!IsBorrowed)
                Console.WriteLine($"[Error] '{Title}' was not borrowed.");
            else
            {
                IsBorrowed = false;
                Console.WriteLine($"[Success] You have returned '{Title}'.");
            }
        }

        /// <summary>
        /// Displays the details of the media item. Overridden by derived classes.
        /// </summary>
        public virtual void DisplayInfo()
        {
            string status = IsBorrowed ? "Borrowed" : "Available";
            Console.WriteLine($"[{Id}] {Title} ({ReleaseYear}) - Status: {status}");
        }

        /// <summary>
        /// Checks if the query matches the item's title. Overridden by derived classes for specific fields.
        /// </summary>
        public virtual bool MatchesSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return false;
            return Title.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}