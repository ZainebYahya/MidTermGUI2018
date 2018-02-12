using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MidTermGUI
{
    public class Validation
    {
        public static Book ConfirmBook(ref List<Book> BookList, int Input)
        {
            int z = 1;
            foreach (Book x in BookList)
            {
                Console.Write($"{z}..... {x.title} by {x.author}\n");
                z++;
            }

            string input = Console.ReadLine();
            int.TryParse(input, out int BookIndex);
            while (true)
            {
                if (BookIndex > 0 && BookIndex <= 12)
                    return BookList[BookIndex - 1];
                else
                {
                    Console.WriteLine("I didn't understand. Try again!");
                    int.TryParse(Console.ReadLine(), out BookIndex);
                }
            }
        }
        public static List<Book> CreateReturnList(ref List<Book>BookList)
        {
            List<Book> CheckedOut = new List<Book>();
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].status == "Checked Out")
                {
                    CheckedOut.Add(BookList[i]);
                }
            }
            return CheckedOut;
        }

        //public static Book ConfirmReturn(List<Book> CheckedOut, int BookIndex)
        //{
        //    while (true)
        //    {
        //        if (BookIndex > 0 && BookIndex <= CheckedOut.Count)
        //            return CheckedOut[BookIndex];
        //        else
        //        {
        //            Console.WriteLine("I didn't understand. Try again!");
        //            int.TryParse(Console.ReadLine(), out BookIndex);
        //        }
        //    }
        //}

        public static void Search(ref List<Book> BookList)
        {
            Console.WriteLine("Do you want to search by Title or Author? (t/a)");
            string TorA = Console.ReadLine().ToLower();
            if (Regex.IsMatch(TorA, "^(t|title)$"))
            {
                Console.WriteLine("Please enter a title...");
                string Input = Console.ReadLine();
                Menu.PrintTitles(LibraryApp.LookByTitleKeyword(ref BookList, Input));
            }

            if (Regex.IsMatch(TorA, "^(a|author)$"))
            {
                Console.WriteLine("Please enter an author...");
                string Input = Console.ReadLine();
                Menu.PrintTitles(LibraryApp.LookByAuthor(ref BookList, Input));
            }
        }
    }
}
