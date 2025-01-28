public class RentingService{
    public Dictionary<Book, int> bookInventory;
    public Dictionary<Book, int> currentlyBorrowed;
    public RentingService (Dictionary<Book, int> bookInventory, Dictionary<Book, int> currentlyBorrowed){
        this.bookInventory = bookInventory;
        this.currentlyBorrowed = currentlyBorrowed;
    } 
}

public class Book{
    public String Title;
    public String Author;

    public Book(String title, String author) {
        this.Title = title;
        this.Author = author;
    }
}

public class BorrowReceipt{

}

public class ReturnReceipt{

}