namespace LINQwithUI {
  public class Memeber {
    private static int nextID = 1000;
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public int ID {get {return nextID;} private set {ID = nextID++;}}
    public string Email {get; set;}
    public override string ToString() {
      return string.Format("{0, -5}- {1, -20} {2, -20}, Email: {3, -20}", ID, FirstName, LastName, Email);
    }
  }
}