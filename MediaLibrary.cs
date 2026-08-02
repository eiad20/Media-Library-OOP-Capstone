using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MediaLibraryApp
{
    /// <summary>
    /// Manages a collection of media items.
    /// </summary>
    public class MediaLibrary
    {
        private List<MediaItem> _inventory;
        private readonly string _filePath = "inventory.json";

        public MediaLibrary()
        {
            _inventory = new List<MediaItem>();
        }

        public void SaveToDisk()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_inventory, options);
            File.WriteAllText(_filePath, jsonString);
            Console.WriteLine("\n[System] Inventory successfully saved to disk.");
        }

        public bool LoadFromDisk()
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                var loadedData = JsonSerializer.Deserialize<List<MediaItem>>(jsonString);
                if (loadedData != null)
                {
                    _inventory = loadedData;
                    return true;
                }
            }
            return false;
        }

        public void AddMedia(MediaItem item)
        {
            _inventory.Add(item);
        }

        public void DisplayAllMedia()
        {
            Console.WriteLine("=== LIBRARY INVENTORY ===");
            if (_inventory.Count == 0)
            {
                Console.WriteLine("The library is currently empty.");
                return;
            }

            foreach (var item in _inventory)
            {
                item.DisplayInfo(); 
            }
        }

        public void BorrowItem(string id)
        {
            var item = _inventory.FirstOrDefault(m => m.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (item != null)
                item.Borrow();
            else
                Console.WriteLine($"[Error] No media item found with ID '{id}'.");
        }

        public void ReturnItem(string id)
        {
            var item = _inventory.FirstOrDefault(m => m.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (item != null)
                item.Return();
            else
                Console.WriteLine($"[Error] No media item found with ID '{id}'.");
        }

        /// <summary>
        /// Searches for media items matching the query.
        /// </summary>
        public void SearchMedia(string query)
        {
            Console.WriteLine($"\n=== SEARCH RESULTS FOR '{query}' ===");
            
            // Uses LINQ to filter items based on the polymorphic MatchesSearch method
            var results = _inventory.Where(m => m.MatchesSearch(query)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No matches found.");
            }
            else
            {
                foreach (var item in results)
                {
                    item.DisplayInfo();
                }
            }
        }
    }
}