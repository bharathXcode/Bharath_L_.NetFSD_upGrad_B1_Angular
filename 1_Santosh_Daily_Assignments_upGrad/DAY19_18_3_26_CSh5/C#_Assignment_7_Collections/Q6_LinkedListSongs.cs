using System;
using System.Collections.Generic;
using System.Linq;

class Song
{
    public int Id;
    public string Title;
    public string Artist;
}

class Q6_LinkedListSongs
{
    public static void Main()
    {
        LinkedList<Song> playlist = new LinkedList<Song>();

        var s1 = new Song { Id = 1, Title = "Song1", Artist = "A" };
        var s2 = new Song { Id = 2, Title = "Song2", Artist = "B" };
        var s3 = new Song { Id = 3, Title = "Song3", Artist = "C" };

        // Add songs
        playlist.AddFirst(s1);
        playlist.AddLast(s2);
        playlist.AddAfter(playlist.First, s3);

        // Forward traversal
        Console.WriteLine("Forward:");
        foreach (var s in playlist)
            Console.WriteLine(s.Title);

        // Backward traversal (FIX)
        Console.WriteLine("Backward:");
        var node = playlist.Last;
        while (node != null)
        {
            Console.WriteLine(node.Value.Title);
            node = node.Previous;
        }

        // Remove
        playlist.Remove(s2);

        // Find
        var found = playlist.FirstOrDefault(x => x.Title == "Song1");
        Console.WriteLine("Found: " + found?.Title);
    }
}