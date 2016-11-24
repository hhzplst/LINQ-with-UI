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
  }
}