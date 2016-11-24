using System.Collections.Generic;

namespace LINQwithUI {
  public class Book {
    private static int nextID = 0;
    private int id;
    public int ID {get {return id;}}
    public int Year {get; set;}
    public string Title {get;set;}
    public string Publisher {get; set;}
    public string[] Authors {get; set;}
    public List<string> SubjectHeadings {get; set;}
    public bool IfAvailable {get; set;} = true;
    public int BorrowerID {get; set;}

    public Book(int year, string title, string publisher, string[] authors, List<string> subHeadings) {
      Year = year;
      Title = title;
      Publisher = publisher;
      Authors = authors;
      SubjectHeadings = subHeadings;
      id = ++nextID;
    }

    public override string ToString() {
      return string.Format("{0, -3}{1, -6}{2, -25}{3, -10}", ID, Year, Title, string.Join(", ", Authors));
    }
  }
}