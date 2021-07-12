using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Schema;

/*
 * Name: Michael Mena
 * Date: 10/29/2020
 * This program creates an application that reads all of the data from a "Data.txt" file and then adds each item to an array.
 * the user can then search for items in the array, display all of certain types of items, and finally close the program
 * I, Michael Mena, 000817498 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
 */
namespace Lab3A
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<int> startMedia = new List<int>(); //A list that holds all of the lines that a piece of media STARTS
            List<int> endMedia = new List<int>(); // A list that holds where each piece of media ENDS
            int counter = 0; //counter for each of the char spots in each line
            int counter2 = 0; // counter for each line in the txt file
            string line; // holds the string for each line of the txt file
            List<string> lines = new List<string>(); // list that holds each line in the txt file
            string fileName = @"Data.txt"; // the txt file, reads from the bin folder
            Media[] mediaArray; // array that will hold all of the media objects


            /*
             * This method essentially reads the entire  "Data.txt" file, adds each line into a list, and then
             * creates a single array containing each specific item.
             */
            void ReadData()
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                /*
                 * This while loop goes through every line of the Data.txt file, adds each line to an arraylist,
                 * and adds every instance where there is the word "book" "song", or "movie" to an arraylist of integers.
                 */
                while ((line = file.ReadLine()) != null)
                {
                    try
                    {
                        if (line.Substring(0, 4) == "BOOK" || line.Substring(0, 4) == "SONG" || line.Substring(0, 4) == "MOVI")
                        {
                            startMedia.Add(counter);
                        }
                        else if(line.Substring(0, 4) == "----")
                        {
                            endMedia.Add(counter);
                        }
                    }
                    catch (Exception e) { }

                    lines.Add(line);
                    counter++;
                }



                // Initializes the array that will hold all of the media. Makes the length equal to the amount of entries in the "startMedia" list
                mediaArray = new Media[startMedia.Count];  

                //Creates an integer list of all of the lines that are included in each item
                List<int> objectLength = new List<int>();

                //Fills the List with all of the lines that are included in each item
                for(int i = 0; i < startMedia.Count; i++)
                {
                    objectLength.Add(endMedia[i] - startMedia[i]);
                }


                // Gets the value of the "|" object that is used to separate each item. I initially just used the "|" character, but it wasnt registering
                string splitter = (lines[0].Substring(4, 1));

                int mediaPosition = 0; //Keeps track of the position that the media will be inserted into
                int position = 0; // Keeps track of each character in the line that will have a "|"
                int start1=0; // Marks the beginning of the first variable in the line
                int start2=0; // Marks the beginning of the second variable in the line
                int start3=0; // Marks the beginning of the third variable in the line
                int start4 = 0; // Marks the beginning of the first variable in the line

                /*
                 * This foreach loop goes through each of the lines where the description of a piece of media begins
                 */
                foreach (int i in startMedia)
                {

                    /*
                     * An if statement that specifies if the line is a book, and then creates the book object accordingly
                     */
                    if (lines[i].Substring(0,4) == "BOOK")
                    {
                        string title; // Title of the book
                        int year; // Year the book was released
                        string author; // Author of the book
                        string summary = ""; //Summary of the book


                        /*
                         * Foreach loop that goes through each line that contains the book information and then creates the object
                         * with the proper variables
                         */
                        foreach(char x in lines[i])
                        {
                            if (x.Equals(char.Parse(splitter)) && start1 == 0)
                            {
                                start1 = position+1;
                                
                            }
                            else if(x.Equals(char.Parse(splitter)) && start1!=0 && start2 == 0)
                            {
                                start2 = position+1;
                            }
                            else if(x.Equals(char.Parse(splitter)) && start1 != 0 && start2 != 0 && start3 == 0)
                            {
                                start3 = position+1;
                            }
                            position++;
                        }
                        title = lines[i].Substring(start1, (start2 - start1 -1)); //initializes the title
                        year = int.Parse(lines[i].Substring(start2, (start3 - start2-1))); //initializes the year
                        author = lines[i].Substring(start3, (lines[i].Length - start3)); //initializes the author


                        /*
                         * the goal of this for loop is to add all of the lines between the start of the media and the end of the media to the summary 
                         */
                        int temp = i+1;

                        /*
                         * for loop that captures all of the lines that make up the summary
                         */
                        for (int j = temp; lines[j] != "-----"; j++)
                        {
                            summary += lines[j];
                        }

                        mediaArray[counter2] = new Book(title, year, author, summary); // Creates the book object


                        /*
                         * the next 6 lines sets all of the variables back to zero so they can be refilled
                         */
                        summary = "";
                        position = 0;
                        start1 = 0;
                        start2 = 0;
                        start3 = 0;
                        counter2++;
                        
                        
                        

                    }

                    /*
                     * An if statement that specifies if the line is a song, and then creates the song object accordingly
                     */
                    else if (lines[i].Substring(0, 4) == "SONG")
                    {
                        string title; // title of the song
                        int year; // year it was released
                        string album; // name of the album
                        string artist; // name of the artist

                        /*
                         * Foreach loop that goes through each line that contains the song information and then creates the object
                         * with the proper variables
                         */
                        foreach (char x in lines[i])
                        {
                            if (x.Equals(char.Parse(splitter)) && start1 == 0)
                            {
                                start1 = position + 1;

                            }
                            else if (x.Equals(char.Parse(splitter)) && start1 != 0 && start2 == 0)
                            {
                                start2 = position + 1;
                            }
                            else if (x.Equals(char.Parse(splitter)) && start1 != 0 && start2 != 0 && start3 == 0)
                            {
                                start3 = position + 1;
                            }
                            else if (x.Equals(char.Parse(splitter)) && start1 != 0 && start2 != 0 && start3 != 0 && start4 == 0)
                            {
                                start4 = position + 1;
                            }
                            position++;
                        }
                        
                        title = lines[i].Substring(start1, (start2 - start1 - 1)); // initializes the title
                        year = int.Parse(lines[i].Substring(start2, (start3 - start2 - 1))); //initializes the year
                        album = lines[i].Substring(start3, (start4 - start3 - 1)); //initializes the album
                        artist = lines[i].Substring(start4, (lines[i].Length - start4)); // initializes the artist

                        mediaArray[counter2] = new Song(title, year, album, artist); //creates the song object 

                        /*
                         * The next 5 lines sets variables to zero so they can be reused4
                         */
                        position = 0;
                        start1 = 0;
                        start2 = 0;
                        start3 = 0;
                        start4 = 0;

                        counter2++;// sets the position that objects are added to the mediaArray
                    }

                    /*
                     * An if statement that specifies if the line is a movie, and then creates the movie object accordingly
                     */
                    else if (lines[i].Substring(0, 4) == "MOVI")
                    {
                        string title; // title of the movie
                        int year; // year of the release
                        string director; // directors name
                        string summary = ""; //summary of the movie

                        /*
                         * Foreach loop that goes through each line that contains the movie information and then creates the object
                         * with the proper variables
                         */
                        foreach (char x in lines[i])
                        {
                            if (x.Equals(char.Parse(splitter)) && start1 == 0)
                            {
                                start1 = position + 1;

                            }
                            else if (x.Equals(char.Parse(splitter)) && start1 != 0 && start2 == 0)
                            {
                                start2 = position + 1;
                            }
                            else if (x.Equals(char.Parse(splitter)) && start1 != 0 && start2 != 0 && start3 == 0)
                            {
                                start3 = position + 1;
                            }
                            position++;
                        }
                        title = lines[i].Substring(start1, (start2 - start1 - 1)); //initializes the title of the movie
                        year = int.Parse(lines[i].Substring(start2, (start3 - start2 - 1))); //initializes the year of the movie
                        director = lines[i].Substring(start3, (lines[i].Length - start3)); // initializes the director

                        int temp = i + 1;

                        /*
                         * for loop that goes through the lines and saves each line of summary to the summary
                         */
                        for (int j = temp; lines[j] != "-----"; j++)
                        {
                            summary += lines[j];
                        }


                        mediaArray[counter2] = new Movie(title, year, summary, director); // creates the movie object

                        /*
                         * the next 5 lines set values back to zero so they can be reused
                         */
                        summary = "";
                        position = 0;
                        start1 = 0;
                        start2 = 0;
                        start3 = 0;
                        counter2++;


                    }
                    
                    mediaPosition++;
                }
                

            }

            ReadData();
            bool yup = true;

            /*
             * The face of the program. Has the options to list all books, list all movies, list alll songs, list all media,
             * search for a certin title, and exit.
             */
            while (yup==true)
            {
                System.Console.WriteLine("Michaels Media Collection");
                System.Console.WriteLine("1. List all Books");
                System.Console.WriteLine("2. List all Movies");
                System.Console.WriteLine("3. List all Songs");
                System.Console.WriteLine("4. List all Media");
                System.Console.WriteLine("5. Search all Media by title");
                System.Console.WriteLine("e. Exit");

                switch (System.Console.ReadLine())
                {
                    //prints out all books with information
                    case "1":
                        foreach(Media m in mediaArray)
                        {
                            if (m.GetType().Equals(typeof(Book))) {
                                System.Console.WriteLine(m.ToString());
                            }
                        }
                        break;
                    //prints out all movies with information
                    case "2":
                        foreach (Media m in mediaArray)
                        {
                            if (m.GetType().Equals(typeof(Movie)))
                            {
                                System.Console.WriteLine(m.ToString());
                            }
                        }
                        break;
                    //prints out all songs with information
                    case "3":
                        foreach (Media m in mediaArray)
                        {
                            if (m.GetType().Equals(typeof(Song)))
                            {
                                System.Console.WriteLine(m.ToString());
                            }
                        }
                        break;
                    //prints out all media with information
                    case "4":
                        foreach (Media m in mediaArray)
                        {
                                System.Console.WriteLine(m.ToString());
                        }
                        break;
                    //searches for whatever title you type in and displays the information if there is a match
                    case "5":
                        System.Console.WriteLine("Enter the title you want to search");
                        string tempTitle = System.Console.ReadLine();
                        foreach (Media m in mediaArray)
                        {
                            if (m.Title.ToLower().Contains(tempTitle.ToLower()))
                            {
                                System.Console.WriteLine(m.ToString());
                            }
                            //System.Console.WriteLine(m.Title);
                            /*
                            if ((tempTitle.ToLower()).Equals(m.Title.ToLower()))
                            {
                                System.Console.WriteLine(m.ToString());
                            }
                            */
                        }
                        break;
                    //closes the program
                    case "e":
                        yup = false;
                        break;
                    //handles any entry that isnt one of the specified options
                    default:
                        System.Console.WriteLine("That is not an option, please try again");
                        break;
                }

            }
            
        }
    }
}
