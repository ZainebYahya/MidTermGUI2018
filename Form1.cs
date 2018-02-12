using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidTermGUI
{
    public partial class Form1 : Form
    {
        private static List<Book> BookList = LibraryApp.CreateBookList("../../Library.txt");

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) //display library
        {
            listBox1.Items.Clear();
            foreach (Book thisBook in BookList)
            {
                if (thisBook.status == "On Shelf")
                    listBox1.Items.Add($"{thisBook.title} by {thisBook.author} Status: {thisBook.status}");
                else
                    listBox1.Items.Add($"{thisBook.title} by {thisBook.author} Due: {thisBook.duedate}");
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //search by title keyword
        {
            listBox1.Items.Clear();
            List<Book> ToPrint = LibraryApp.LookByTitleKeyword(ref BookList, textBox1.Text);
            if (ToPrint.Count == 0)
                MessageBox.Show("No books matched that search!");
            else
                PrintTitles(ToPrint);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) // search by author
        {
            listBox1.Items.Clear();
            List<Book> ToPrint = LibraryApp.LookByAuthor(ref BookList, textBox2.Text);
            if (ToPrint.Count == 0)
                MessageBox.Show("No books matched that search!");
            else
                PrintTitles(ToPrint);
        }

        private void PrintTitles(List<Book> ThisList)
        {
            if (BookList.Count != 0)
            {
                foreach (Book b in ThisList)
                {
                    listBox1.Items.Add($"{b.title} by {b.author}");
                }
            }
            else
                MessageBox.Show("No books matched that search!");
        }

        void button4_Click(object sender, EventArgs e) //checkout book
        {
            try
            {
                int index = listBox1.SelectedIndex;
                string y = listBox1.SelectedItem.ToString().Substring(0, 5);
                foreach(Book x in BookList)
                {
                    if (x.title.Contains(y) && x.status == "Checked Out")
                    {
                        MessageBox.Show($"That book is already checked out and is due back {BookList[index].duedate}");
                    }
                    else if (x.title.Contains(y) && x.status != "Checked Out")
                    {
                        LibraryApp.CheckOutBook(x);
                        MessageBox.Show($"{x.title} is due back on {x.duedate}\n");
                    }
                }
            }
            catch
            {
                MessageBox.Show("No book was selected!");
            }
        }

        private void button5_Click(object sender, EventArgs e) //return book
        {
            try
            {
                int index = listBox1.SelectedIndex;
                List<Book> ReturnList = Validation.CreateReturnList(ref BookList);
                ReturnList[index] = LibraryApp.ReturnBook(ReturnList[index]);
                foreach (Book x in BookList)
                {
                    if (x.title == ReturnList[index].title)
                    {
                        x.duedate = ReturnList[index].duedate;
                        x.status = ReturnList[index].status;
                    }
                }
                MessageBox.Show("Thank you for not stealing our book!");
                listBox1.Items.Clear();
            }
            catch
            {
                MessageBox.Show("There were no books to return!");
            }
        }

        private void button8_Click(object sender, EventArgs e) //display borrowed
        {
            List<Book> CheckedOut = Validation.CreateReturnList(ref BookList);
            listBox1.Items.Clear();
            if (CheckedOut.Count == 0)
            {
                MessageBox.Show("There are no books to return!");
            }
            else
            {
                int z = 1;
                foreach (Book x in CheckedOut)
                {
                    listBox1.Items.Add($"{x.title} by {x.author}");
                    z++;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            StreamWriter Writer = new StreamWriter("../../Library.txt");
            foreach (Book book in BookList)
            {
                Writer.WriteLine($"{book.title},{book.author},{book.duedate},{book.status}");
            }
            Writer.Close();
            MessageBox.Show("Thank you for shopping at Walmart!");
            Application.Exit();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            Book Donated = new Book();
            Donated.title = textBox3.Text;
            Donated.author = textBox4.Text;
            BookList.Add(Donated);
            MessageBox.Show("Thanks for your donation");
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
