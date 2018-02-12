//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MidTermGUI
//{
//    public class Originalprogram
//    {

//        //static void Main(string[] args)
//        //{
//        //    Console.WriteLine("Welcome to the Grand Circus Library!\n");
//        //    RunProgram();
//        //    Console.WriteLine("Goodbye!");
//        //}

//        public static void RunProgram()
//        {
//            string Input = Menu.GCLMenu();

//            while (true)
//            {
//                if (Input == "1")
//                {
//                    LibraryApp.PrintBookList(ref BookList);
//                    Input = Menu.GCLMenu();
//                }
//                else if (Input == "2")
//                {
//                    Validation.Search(ref BookList);
//                    Input = Menu.GCLMenu();
//                }
//                else if (Input == "3")
//                {
//                    LibraryApp.CheckOutBook(Validation.ConfirmBook(ref BookList));
//                    Input = Menu.GCLMenu();
//                }
//                else if (Input == "4")
//                {
//                    LibraryApp.ReturnBook(Validation.ConfirmReturn(ref BookList));
//                    Input = Menu.GCLMenu();
//                }
//                else if (Input == "5")
//                {
//                    Menu.WriteToFile(ref BookList);
//                    break;
//                }
//                else
//                {
//                    Console.WriteLine("That's not an option! Try again!");
//                    Input = Console.ReadLine();
//                }
//            }
//        }
//    }
//}
