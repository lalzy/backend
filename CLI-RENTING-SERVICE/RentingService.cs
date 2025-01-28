using System.Net.Http.Headers;

public class RentingService{
    Dictionary<Book, int> bookInventory;
    Dictionary<Book, int> currentlyBorrowed;
    public RentingService (){
        bookInventory = new Dictionary<Book,int>{
            {new Book("The Marsian", "SomeDude"), 10},
            {new Book("Foundation", "SomeDude"), 99},
            {new Book("Harry Potter", "SomeDude"), 300},
        };
        
        currentlyBorrowed = new Dictionary<Book, int>();
    } 

    public void addBook (String title, String author, int amount = 1){
        bookInventory.Add(new Book(title, author), amount);
    }

    public Dictionary<Book,int> ListAllBooks(){
        return bookInventory;
    }

    public BorrowReceipt? rentBook (String title){
        foreach (Book book in bookInventory.Keys){
            if(book.title.ToLower() == title.ToLower()){
                bookInventory[book]--;
                return new BorrowReceipt(title);
            }
        }
        return null;
    }
    
    public ReturnReceipt? ReturnBook (string title, DateTime borrowDate){ 
        foreach (Book book in bookInventory.Keys){
            if(book.title.ToLower() == title.ToLower()){
                bookInventory[book]++;
                return new ReturnReceipt(title, borrowDate);
            }
        }
        return null; 
    }

}

public class Book{
    public String title;
    public String author;

    public Book(String title, String author) {
        this.title = title;
        this.author = author;
    }
}

public class BorrowReceipt{
    public string title;
    public DateTime borrowDate;
    public DateTime returnDate;

    public BorrowReceipt (string title){
        borrowDate = DateTime.Now;
        returnDate = DateTime.Now.AddMonths(3);
        this.title = title;
    }
}

public class ReturnReceipt{

    public string title;
    public DateTime borrowDate;
    public DateTime returnDate;

    public ReturnReceipt (string title, DateTime borrowedDate){
        borrowDate = borrowedDate;
        returnDate = DateTime.Now;
        this.title = title;
    }
}