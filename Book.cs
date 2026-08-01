using System;

namespace MediaLibraryApp
{
    /// <summary>
    /// Represents a Book, derived from MediaItem.
    /// </summary>
    public class Book : MediaItem
    {
        public string Author { get; set; }
        public int PageCount { get; set; }

        public Book(string id, string title, int releaseYear, string author, int pageCount) 
            : base(id, title, releaseYear)
        {
            Author = author;
            PageCount = pageCount;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"      Type: Book | Author: {Author} | Pages: {PageCount}");
            Console.WriteLine(new string('-', 40));
        }

        public override bool MatchesSearch(string query)
        {
            // Checks if the query matches the Title (base) OR the Author
            return base.MatchesSearch(query) || 
                   Author.Contains(query, StringComparison.OrdinalIgnoreCase);
        }
    }
}