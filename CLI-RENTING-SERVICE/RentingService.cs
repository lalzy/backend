using System.Net.Http.Headers;
using System.Runtime.InteropServices;

// Inummerable - interface for dictionary i stede?
// conflict-free-replicated-datatypes
public class RentingService{
    Dictionary<Book, int> bookInventory;
    Dictionary<Book, int> currentlyBorrowed;
    public RentingService (){
        bookInventory = new Dictionary<Book,int>{
            {new Book("The Marsian", "SomeDude"), 2},
            {new Book("Foundation", "SomeDude"), 2},
            {new Book("Harry Potter", "SomeDude"), 1},
        };
        
        currentlyBorrowed = new Dictionary<Book, int>();
    } 

    public void addBook (String title, String author, int amount = 1){
        bookInventory.Add(new Book(title, author), amount);
    }

    public Dictionary<Book,int> ListAllBooks(){
        return bookInventory;
    }

    public KeyValuePair<Book, int>? CheckAvailability(String title){
        KeyValuePair<Book, int> bookKey = bookInventory.FirstOrDefault(entry => entry.Key.title.ToLower() == title.ToLower());

        if (bookKey.Equals(default(KeyValuePair<Book, int>))){
            return null;
        }else if(bookInventory[bookKey.Key] <= 0){
            return null;
        }else{
            return bookKey;
        }
    }

    // public bool checkAvailability(String title){
    //     foreach(Book book in bookInventory.Keys){
    //         if(book.title.ToLower() == title.ToLower()){
    //             if (bookInventory[book] > 0)
    //                 return true;
    //         }
    //     }

    //     return false;
    // }

    private void addToBorrowed(Book book){
        KeyValuePair<Book, int> borrowedBook = currentlyBorrowed.FirstOrDefault(
            entry=> entry.Key.title.Equals(book.title, StringComparison.OrdinalIgnoreCase));
        
        if(!borrowedBook.Equals(default(KeyValuePair<Book, int>))){
            currentlyBorrowed[book]++;
        }else{
            currentlyBorrowed.Add(book, 1);
        }
    }

    public BorrowReceipt? rentBook (String title){
        KeyValuePair<Book, int>? bookKey = CheckAvailability(title);

        if(bookKey == null){
            return null;
        }

        Book book = bookKey.Value.Key;
        bookInventory[book]--;
        addToBorrowed(book);

        return new BorrowReceipt(title);

        // foreach (Book book in bookInventory.Keys){
        //     if(book.title.ToLower() == title.ToLower()){
        //         if(checkAvailability(book.title)){
        //             bookInventory[book]--;
        //             //currentlyBorrowed.Add(book, (currentlyBorrowed[book] + 1));
        //             return new BorrowReceipt(title);
        //         }else{
        //             return null;
        //         }
        //     }
        // }
        // return null;
    }

    public ReturnReceipt? ReturnBook (string title, DateTime borrowDate){
        KeyValuePair<Book, int> bookKey = currentlyBorrowed.FirstOrDefault((entry)=>entry.Key.title.Equals(title, StringComparison.OrdinalIgnoreCase));
    
        if(bookKey.Equals(default(KeyValuePair<Book, int>))){
            return null;
        }

        currentlyBorrowed[bookKey.Key]--;
        bookInventory[bookKey.Key]++;

        if(currentlyBorrowed[bookKey.Key] <= 0){
            currentlyBorrowed.Remove(bookKey.Key);
        }
    //     foreach (Book book in bookInventory.Keys){
    //         if(book.title.ToLower() == title.ToLower()){
    //             bookInventory[book]++;
    //             return new ReturnReceipt(title, borrowDate);
    //         }
    //     }
    //     return null; 
    // }
        return new ReturnReceipt(title, borrowDate);
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