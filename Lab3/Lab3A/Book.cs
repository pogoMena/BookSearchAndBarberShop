using System;
using System.Collections.Generic;
using System.Text;

/*
 * Name: Michael Mena
 * Date: 10/29/2020
 * This program creates an application that reads all of the data from a "Data.txt" file and then adds each item to an array.
 * the user can then search for items in the array, display all of certain types of items, and finally close the program
 * I, Michael Mena, 000817498 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */
namespace Lab3A
{
    /*
     * This Class represents the Book object. it creates the book and decrypts the summary that is input
     * inherits form media, implements IEncryptable
     */
    class Book : Media, IEncryptable
    {
        String Author; // Author of the book
        String Summary;//Summary of the book

        //constructor of the book object
        public Book(String title, int year, String author, String summary): base(title,year)
        {
            Author = author;
            Summary = summary;
        }

        public string Encrypt()
        {
            return "";
        }

        //method that decrypts the summary of the book
        public string Decrypt()
        {
            string temp = "";
            foreach (char x in Summary)
            {
                char tempChar;
                if (Char.IsUpper(x))
                {
                    tempChar = Char.ToLower(x);
                }
                else
                {
                    tempChar = x;
                }
                switch (tempChar)
                {
                    case 'a':
                        temp += "n";
                        break;
                    case 'b':
                        temp += "o";
                        break;
                    case 'c':
                        temp += "p";
                        break;
                    case 'd':
                        temp += "q";
                        break;
                    case 'e':
                        temp += "r";
                        break;
                    case 'f':
                        temp += "s";
                        break;
                    case 'g':
                        temp += "t";
                        break;
                    case 'h':
                        temp += "u";
                        break;
                    case 'i':
                        temp += "v";
                        break;
                    case 'j':
                        temp += "w";
                        break;
                    case 'k':
                        temp += "x";
                        break;
                    case 'l':
                        temp += "y";
                        break;
                    case 'm':
                        temp += "z";
                        break;
                    case 'n':
                        temp += "a";
                        break;
                    case 'o':
                        temp += "b";
                        break;
                    case 'p':
                        temp += "c";
                        break;
                    case 'q':
                        temp += "d";
                        break;
                    case 'r':
                        temp += "e";
                        break;
                    case 's':
                        temp += "f";
                        break;
                    case 't':
                        temp += "g";
                        break;
                    case 'u':
                        temp += "h";
                        break;
                    case 'v':
                        temp += "i";
                        break;
                    case 'w':
                        temp += "j";
                        break;
                    case 'x':
                        temp += "k";
                        break;
                    case 'y':
                        temp += "l";
                        break;
                    case 'z':
                        temp += "m";
                        break;
                    default:
                        temp += x;
                        break;
                }
            }
            return temp;
        }

        /*
         * Tostring method of the book object
         */
        public override string ToString()
        {
            return "Title: " + Title + Environment.NewLine +
                "Year released: " + Year + Environment.NewLine +
                "Author: " + Author + Environment.NewLine +
                "Summary: " + Decrypt() + Environment.NewLine +
                "---------" + Environment.NewLine;
        }

    }
}
