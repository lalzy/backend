public class RentingService{
    Dictionary<Book, int> bookInventory;
    Dictionary<Book, int> currentlyBorrowed;
    RentingService (Dictionary<Book, int> bookInventory, Dictionary<Book, int> currentlyBorrowed){
        this.bookInventory = bookInventory;
        this.currentlyBorrowed = currentlyBorrowed;
    } 
}

public class Book{
    String Title;
    String Author;

    Book(String title, String author) {
        this.Title = title;
        this.Author = author;
    }
}

public class BorrowReceipt{

}

public class ReturnReceipt{
    
}