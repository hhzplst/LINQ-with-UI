using System.Collections.Generic;

namespace LINQwithUI {
  public class Book {
    private static int nextID = 0;
    public int ID {get {return nextID;} private set {ID = nextID++;}}
    public int Year {get; set;}
    public string Title {get;set;}
    public string Publisher {get; set;}
    public string[] Authors {get; set;}
    public List<string> SubjectHeadings {get; set;}
    public bool IfAvailable {get; set;} = true;
    public int BorrowerID {get; set;}

    public override string ToString() {
      return string.Format("{0, -5}{1, -5}{2, -20}{3, -20", "ID", "Year", "Title", "Authors" +
                           "{0, -5}{1, -5}{2, -20}{3, -20}", ID, Year, Title, string.Join(", ", Authors));
    }
  }
}