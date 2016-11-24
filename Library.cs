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
  }
}