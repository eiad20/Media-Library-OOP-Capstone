# 📚 Media Library Manager

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) 

A fully functional, console-based media management system built in C#. This capstone project serves as a practical demonstration of advanced Object-Oriented Programming (OOP) principles, including abstraction, encapsulation, inheritance, and polymorphism. 

## ✨ Features
*   **Multi-Media Support:** Manage Books, DVDs, and Music Albums.
*   **Inventory Tracking:** Check the real-time status of all media items (Available/Borrowed).
*   **Advanced Search:** Polymorphic search functionality allowing users to find items by Title, Author, Director, or Artist.
*   **Borrow/Return System:** Interactive borrowing and returning with validation to prevent double-borrowing.
*   **XML Documentation:** Fully documented codebase ready for auto-documentation tools.

## 🧠 OOP Principles Applied
This project was architected specifically to showcase enterprise-level software patterns:
*   **Abstraction:** An `IBorrowable` interface defines a strict contract for how items interact with the borrowing system.
*   **Encapsulation:** Data fields (like `_id` and `_releaseYear`) are kept private and accessed only through properties with built-in validation rules.
*   **Inheritance:** `Book`, `DVD`, and `MusicAlbum` all inherit common properties and methods from the abstract `MediaItem` base class, keeping the code DRY (Don't Repeat Yourself).
*   **Polymorphism:** The `DisplayInfo()` and `MatchesSearch()` methods are defined as `virtual` in the base class and `overridden` in derived classes to provide media-specific behaviors.

## 📂 Project Structure
```text
📦 MediaLibraryApp
 ┣ 📜 Program.cs         # Application entry point and UI loop
 ┣ 📜 MediaLibrary.cs    # Manager class for inventory collection
 ┣ 📜 IBorrowable.cs     # Interface for borrowing contracts
 ┣ 📜 MediaItem.cs       # Abstract base class for all media
 ┣ 📜 Book.cs            # Derived class for books
 ┣ 📜 DVD.cs             # Derived class for DVDs
 ┗ 📜 MusicAlbum.cs      # Derived class for music
