using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidTermGUI
{
    public class Menu
    {
        public static string GCLMenu()
        {
            Console.WriteLine("[1] Display Library\n[2] Search Library\n[3] Checkout a Book\n[4] Return a Book\n[5] Exit Library");
            Console.WriteLine("Enter a number to perform an action!");
            string UserInput = Console.ReadLine();
            return UserInput;
        }

        public static void PrintTitles(List<Book> BookList)
        {
            if (BookList.Count != 0)
            {
                foreach (Book b in BookList)
                {
                    Console.WriteLine($"{b.title} by {b.author}");
                }
            }
            else
                Console.WriteLine("No books matched that search!");
        }

        public static void WriteToFile(ref List<Book> BookList)
        {
            
        }
    }
}
