namespace MediaLibraryApp
{
    /// <summary>
    /// Defines a contract for items that can be borrowed and returned.
    /// </summary>
    public interface IBorrowable
    {
        bool IsBorrowed { get; }
        void Borrow();
        void Return();
    }
}