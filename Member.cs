namespace LINQwithUI {
  public class Memeber {
    private static int nextID = 1000;
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public int ID {get {return nextID;} private set {ID = nextID++;}}
    public string Email {get; set;}
  }
}