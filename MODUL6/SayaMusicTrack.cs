using System;

public class SayaMusicTrack
{
    private int id;
    private string title;
    private int playCount;

    public SayaMusicTrack(string title)
    {
        if (title == null)
            throw new ArgumentException("Judul track tidak boleh null");

        if (title.Length > 200)
            throw new ArgumentException("Judul track maksimal 200 karakter");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0)
            throw new ArgumentException("Play count tidak boleh negatif");

        if (count > 25000000)
            throw new ArgumentException("Maksimal penambahan 25.000.000 per panggilan");

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow pada playCount!");
        }
    }

    public int GetPlayCount()
    {
        return playCount;
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}