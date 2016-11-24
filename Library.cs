using System;
using System.Linq;

using System.Collections.Generic;

namespace LINQwithUI {
  public class Library {
    private List<Book> books;
    private List<Member> members;
    public void AddBook(Book b) {
      books.Add(b);
    }
    public void AddMember(Member m) {
      members.Add(m);
    }
    public void CheckOut(Book book, int memberId) {
      book.IfAvailable = false;
      book.BorrowerID = memberId;
    }
    public void SearchBySubject(string searchStr) {
      var query = from book in books
                  where (book.Title.Contains(searchStr))
                  from heading in book.SubjectHeadings
                  where heading.Contains(searchStr)
                  select book;
      foreach (Book b in query)
        Console.WriteLine(b);
    }
    public void SearchBooksBorrowed(int memberId) {
      var bookQuery = from book in books
                  where (book.BorrowerID == memberId)
                  select book;

      Member m = (Member)members.Select(ID => memberId);

      Console.WriteLine("Member {0} has borrowed the following books: ", m.ToString());
      foreach (Book b in bookQuery)
        Console.WriteLine("\t" + b);
    }
    public static void Main(string[] args) {
      Member m1 = new Member{FirstName = "Ivy", LastName = "Chang", Email = "ivycwq@icloud.com"};
      Member m2 = new Member{FirstName = "Elham", LastName = "Farhodi", Email = "elhamfarhodi@gmail.com"};
      Book b1 = new Book{Year = 1988, Title = "I'm b1", Publisher = "b1's Publisher", Authors = new String[]{"Tom", "Susan"}, 
                         SubjectHeadings = {"hello", "thishey", "fox"}};
      Book b2 = new Book{Year = 1994, Title = "I'm not a b1 but a b2", Publisher = "b2's Publisher", Authors = new String[]{"a1", "a2"}, 
                         SubjectHeadings = {"fox", "hey"}};
      Book b3 = new Book{Year = 2003, Title = "hey", Publisher = "b3's Publisher", Authors = new String[]{"Tom", "Susan"}, 
                         SubjectHeadings = {"world", "my", "this"}};
      Library myLibrary = new Library {books = {b1, b2, b3}, members = {m1, m2}};
      myLibrary.SearchBySubject("hey");
    }
  }
}