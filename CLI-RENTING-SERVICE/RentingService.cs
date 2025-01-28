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

    public void ListAllBooks(){
        foreach (var book in bookInventory){
            Console.WriteLine(String.Format("Book: {0} by {1}, Available: {2}", 
                book.Key.title, book.Key.author, book.Value));
        }
    }

    public void BorrowBook (){
        
    }

    public void ReturnBook (){

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

}

public class ReturnReceipt{

}