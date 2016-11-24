namespace LINQwithUI {
  public class Member {
    private static int nextID = 1000;
    private int id;
    public int ID {get {return id;}}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string Email {get; set;}
    public Member(string fn, string ln, string email) {
      FirstName = fn;
      LastName = ln;
      Email = email;
      id = ++nextID;
    }
    public override string ToString() {
      return string.Format("{0, -5}- {1, -6} {2, -6}, Email: {3, -20}", ID, FirstName, LastName, Email);
    }
  }
}