using System;
using System.Collections.Generic;
using System.Reflection;
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
     * This is the Song class that is used to create all song objects
     * inherits from media
     */
    class Song : Media
    {
        String Album;// Album name
        String Artist; // Artist name

        /*
         * Constructor for the song object
         */
        public Song(String title, int year, String album, String artist): base(title, year)
        {
            Album = album;
            Artist = artist;
        }
        /*
         * tostring of the song object
         */
        public override string ToString()
        {
            return "Title: " + Title + Environment.NewLine +
                "Year released: " + Year + Environment.NewLine +
                "Album: " + Album + Environment.NewLine +
                "Artist: " + Artist + Environment.NewLine +
                "---------" + Environment.NewLine;
        }
    }
}
