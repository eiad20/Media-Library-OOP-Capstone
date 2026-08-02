using System;

namespace MediaLibraryApp
{
    /// <summary>
    /// Represents the entry point of the Media Library application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MediaLibrary library = new MediaLibrary();
            
            if (!library.LoadFromDisk())
            {
                SeedData(library);
            }
            
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== MEDIA LIBRARY MANAGER ===");
                Console.WriteLine("1. View All Media");
                Console.WriteLine("2. Search Media");
                Console.WriteLine("3. Borrow a Media Item");
                Console.WriteLine("4. Return a Media Item");
                Console.WriteLine("5. Save & Exit");
                Console.Write("\nSelect an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        library.DisplayAllMedia();
                        PressKeyToContinue();
                        break;
                    case "2":
                        Console.Write("\nEnter search term (Title, Author, Director, etc.): ");
                        string query = Console.ReadLine();
                        Console.Clear();
                        library.SearchMedia(query);
                        PressKeyToContinue();
                        break;
                    case "3":
                        Console.Write("\nEnter the ID of the item to borrow: ");
                        string borrowId = Console.ReadLine();
                        library.BorrowItem(borrowId);
                        PressKeyToContinue();
                        break;
                    case "4":
                        Console.Write("\nEnter the ID of the item to return: ");
                        string returnId = Console.ReadLine();
#pragma warning disable CS8604 // Possible null reference argument.
                        library.ReturnItem(returnId);
#pragma warning restore CS8604 // Possible null reference argument.
                        PressKeyToContinue();
                        break;
                    case "5":
                        Console.Clear();
                        library.SaveToDisk();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        PressKeyToContinue();
                        break;
                }
            }
        }

        static void PressKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void SeedData(MediaLibrary library)
{
    // Books
            library.AddMedia(new Book("B001", "The Martian", 2011, "Andy Weir", 369));
            library.AddMedia(new Book("B002", "C# in Depth", 2019, "Jon Skeet", 528));
            library.AddMedia(new Book("B003", "The Pragmatic Programmer", 1999, "Andrew Hunt, David Thomas", 352));
            library.AddMedia(new Book("B004", "Dune", 1965, "Frank Herbert", 412));
            library.AddMedia(new Book("B005", "Clean Code", 2008, "Robert C. Martin", 464));

    // DVDs
            library.AddMedia(new DVD("D001", "Inception", 2010, "Christopher Nolan", 148));
            library.AddMedia(new DVD("D002", "Interstellar", 2014, "Christopher Nolan", 169));
            library.AddMedia(new DVD("D003", "The Matrix", 1999, "The Wachowskis", 136));
            library.AddMedia(new DVD("D004", "The Lord of the Rings: The Return of the King", 2003, "Peter Jackson", 201));
            library.AddMedia(new DVD("D005", "Blade Runner 2049", 2017, "Denis Villeneuve", 163));

    // Music Albums
            library.AddMedia(new MusicAlbum("M001", "Abbey Road", 1969, "The Beatles", 17));
            library.AddMedia(new MusicAlbum("M002", "Random Access Memories", 2013, "Daft Punk", 13));
            library.AddMedia(new MusicAlbum("M003", "The Dark Side of the Moon", 1973, "Pink Floyd", 10));
            library.AddMedia(new MusicAlbum("M004", "To Pimp a Butterfly", 2015, "Kendrick Lamar", 16));
            library.AddMedia(new MusicAlbum("M005", "OK Computer", 1997, "Radiohead", 12));
            library.AddMedia(new MusicAlbum("M006", "Interstellar (Original Motion Picture Soundtrack)", 2014, "Hans Zimmer", 16));
        }
    }
}