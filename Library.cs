using System;
using System.Linq;

using System.Collections.Generic;

namespace LINQwithUI {
  public class Library {
    private List<Book> books = new List<Book>();
    private List<Member> members = new List<Member>();
    public void AddBook(Book b) {
      books.Add(b);
    }
    public void AddMember(Member m) {
      members.Add(m);
    }
    public void CheckOut(Book book, int memberId) {
      if (book.IfAvailable == true) {
        book.IfAvailable = false;
        book.BorrowerID = memberId;
      } else {
        Console.WriteLine("The book has already been borrowed!");
      }
      
    }
    public void SearchBySubject(string searchStr) {
      var query = from book in books
                  where (book.Title.Contains(searchStr) || String.Join("", book.SubjectHeadings).Contains(searchStr))
                  select book;
      foreach (Book b in query)
        Console.WriteLine(b);
    }
    public void SearchBooksBorrowed(int memberId) {
      var bookQuery = from book in books
                  where (book.BorrowerID == memberId)
                  select book;

      Member m = (from member in members
                        where (member.ID == memberId)
                        select member).FirstOrDefault();

      Console.WriteLine("Member {0} has borrowed {1} books.", m.ToString(), bookQuery.Count());
      foreach (Book b in bookQuery)
        Console.WriteLine("\t" + b);   
      
    }
    public void SearchAllBooksBorrowed() {
      var bookQuery = from book in books
                      where (book.IfAvailable == false)
                      orderby book.BorrowerID ascending
                      select book;
      foreach (Book b in bookQuery)
        Console.WriteLine("\t" + b);
    }
    public static void Main(string[] args) {
      Member m1 = new Member("Ivy", "Chang", "ivycwq@icloud.com");
      Member m2 = new Member("Elham", "Farhodi", "elhamfarhodi@gmail.com");
    
      Book b1 = new Book(1988, "I'm b1", "b1's Publisher", new String[]{"Tom", "Susan"}, 
                         new List<string>{"hello", "thishey", "fox"});
      Book b2 = new Book(1994, "I'm not a b1 but a b2", "b2's Publisher", new String[]{"a1", "a2"}, 
                         new List<string>{"fox", "hey"});
      Book b3 = new Book(2003, "hey", "b3's Publisher", new String[]{"Tom", "Susan"}, 
                         new List<string>{"world", "my", "this"}); 
      
      Library myLibrary = new Library();
      myLibrary.AddBook(b1);
      myLibrary.AddBook(b2);
      myLibrary.AddBook(b3);
      myLibrary.AddMember(m1);
      myLibrary.AddMember(m2);

      myLibrary.SearchBySubject("b1");

      myLibrary.CheckOut(b3, 1001);
      myLibrary.CheckOut(b2, 1001);
      myLibrary.SearchBooksBorrowed(1001);
      myLibrary.CheckOut(b1, 1002);
      Console.WriteLine("All Books Borrowed: ");
      myLibrary.SearchAllBooksBorrowed();
    }
  }
}