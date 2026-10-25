using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class Playlist
    {
        private List<string> songs = new();

        //indexer allows you to access an object using square brackets like an array or list.
        //we can use an object like a collection
        // indexer accessing by position
        public string this[int index] //this line declares an indexer on the playlist class.
            //this refers to current instance of class.
        {
            get
            {
                if (index < 0 || index >= songs.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return songs[index];
            }
            set
            {
                if (index < 0 || index >= songs.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                songs[index] = value;
            }
        }

        // indexer accessng song by title
        public string this[string title]
        {
            get
            {
                foreach (string song in songs)
                {
                    if (song.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        return song;
                    }
                }
                throw new KeyNotFoundException("Song not found");
            }
        }

        public void Add(string song)
        {//the method is to add new songs. the indexer is used to replace. 
            songs.Add(song);
        }
    }
}
