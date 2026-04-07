using System;
using System.Collections.Generic;

public class SayaMusicUser
{
    private int id;
    public string Username { get; private set; }
    private List<SayaMusicTrack> uploadedTracks;

    public SayaMusicUser(string username)
    {
        if (username == null)
            throw new ArgumentException("Username tidak boleh null");

        if (username.Length > 100)
            throw new ArgumentException("Username maksimal 100 karakter");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.Username = username;
        this.uploadedTracks = new List<SayaMusicTrack>();
    }

    public int GetTotalPlayCount()
    {
        int total = 0;
        foreach (var track in uploadedTracks)
        {
            total += track.GetPlayCount();
        }
        return total;
    }

    public void AddTrack(SayaMusicTrack track)
    {
        if (track == null)
            throw new ArgumentException("Track tidak boleh null");

        if (track.GetPlayCount() == int.MaxValue)
            throw new ArgumentException("PlayCount melebihi batas integer");

        uploadedTracks.Add(track);
    }

    public void PrintAllTracks()
    {
        Console.WriteLine($"User: {Username}");

        int maxPrint = uploadedTracks.Count > 8 ? 8 : uploadedTracks.Count;

        for (int i = 0; i < maxPrint; i++)
        {
            Console.WriteLine($"Track {i + 1} judul: {uploadedTracks[i]}");
        }
    }
}