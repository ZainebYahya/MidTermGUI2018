using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermGUI
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string duedate { get; set; }
        public string status { get; set; }

        public Book(string Title, string Author, string DueDate, string Status)
        {
            title = Title;
            author = Author;
            duedate = DueDate;
            status = Status;
        }

        public Book()
        {
            title = "";
            author = "";
            duedate = DateTime.Now.ToString();
            status = "On Shelf";
        }
    }
}
