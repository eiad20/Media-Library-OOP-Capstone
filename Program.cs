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
            SeedData(library);
            
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== MEDIA LIBRARY MANAGER ===");
                Console.WriteLine("1. View All Media");
                Console.WriteLine("2. Search Media");
                Console.WriteLine("3. Borrow a Media Item");
                Console.WriteLine("4. Return a Media Item");
                Console.WriteLine("5. Exit");
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
            library.AddMedia(new Book("B001", "The Martian", 2011, "Andy Weir", 369));
            library.AddMedia(new DVD("D001", "Inception", 2010, "Christopher Nolan", 148));
            library.AddMedia(new DVD("D002", "Interstellar", 2014, "Christopher Nolan", 169));
            library.AddMedia(new MusicAlbum("M001", "Abbey Road", 1969, "The Beatles", 17));
        }
    }
}