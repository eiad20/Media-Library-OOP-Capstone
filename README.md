# 📚 Media Library Manager

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) 

A robust, console-based media management system built in C#. This project serves as a practical demonstration of foundational .NET architecture, focusing on advanced Object-Oriented Programming (OOP) principles, Language Integrated Query (LINQ), and polymorphic JSON serialization for local data persistence. 

## ✨ Features
*   **Local Data Persistence:** Seamlessly saves and loads the library's inventory state across application sessions using `System.Text.Json`.
*   **Multi-Media Support:** Manage distinct media types including Books, DVDs, and Music Albums through a unified interface.
*   **Advanced Search:** Leverages LINQ and polymorphic matching to allow users to instantly find items by Title, Author, Director, or Artist.
*   **Borrow/Return System:** Interactive checkout mechanics with built-in state validation to prevent duplicate borrowing or returning errors.
*   **XML Documentation:** Fully documented codebase ready for standard auto-documentation tools.

## 🧠 Architecture & .NET Principles Applied
This codebase was architected to showcase enterprise-ready software patterns and modern C# features:
*   **Polymorphic Serialization:** Utilizes `[JsonDerivedType]` attributes on the base class to accurately serialize and deserialize derived entity types from a single, generic JSON collection.
*   **Abstraction:** An `IBorrowable` interface defines a strict contract for state management across all media items.
*   **Encapsulation:** Data fields (like `_id` and `_releaseYear`) are kept private and accessed strictly through properties with built-in validation rules.
*   **Inheritance:** `Book`, `DVD`, and `MusicAlbum` inherit core state and behaviors from the abstract `MediaItem` base class, adhering to DRY (Don't Repeat Yourself) principles.
*   **Polymorphism:** The `DisplayInfo()` and `MatchesSearch()` methods are defined as `virtual` in the base class and `overridden` in derived classes to execute media-specific behaviors dynamically.

## 📂 Project Structure
```text
📦 MediaLibraryApp
 ┣ 📜 Program.cs         # Application entry point and UI loop
 ┣ 📜 MediaLibrary.cs    # Manager class for inventory collection and disk I/O
 ┣ 📜 IBorrowable.cs     # Interface for borrowing contracts
 ┣ 📜 MediaItem.cs       # Abstract base class configuring JSON serialization
 ┣ 📜 Book.cs            # Derived class for books
 ┣ 📜 DVD.cs             # Derived class for DVDs
 ┣ 📜 MusicAlbum.cs      # Derived class for music
 ┗ 📜 inventory.json     # Local database file storing serialized application state
