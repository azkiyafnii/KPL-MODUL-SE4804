using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SayaMusicUser user = new SayaMusicUser("Revan");

            SayaMusicTrack t1 = new SayaMusicTrack("Review Lagu Fix You oleh Revan");
            SayaMusicTrack t2 = new SayaMusicTrack("Review Lagu Bohemian Rhapsody oleh Revan");
            SayaMusicTrack t3 = new SayaMusicTrack("Review Lagu Yellow oleh Revan");
            SayaMusicTrack t4 = new SayaMusicTrack("Review Lagu Viva La Vida oleh Revan");
            SayaMusicTrack t5 = new SayaMusicTrack("Review Lagu Numb oleh Revan");
            SayaMusicTrack t6 = new SayaMusicTrack("Review Lagu Counting Stars oleh Revan");
            SayaMusicTrack t7 = new SayaMusicTrack("Review Lagu Perfect oleh Revan");
            SayaMusicTrack t8 = new SayaMusicTrack("Review Lagu Photograph oleh Revan");
            SayaMusicTrack t9 = new SayaMusicTrack("Review Lagu A Sky Full of Stars oleh Revan");
            SayaMusicTrack t10 = new SayaMusicTrack("Review Lagu Paradise oleh Revan");

            t1.IncreasePlayCount(100);
            t2.IncreasePlayCount(200);
            t3.IncreasePlayCount(300);

            user.AddTrack(t1);
            user.AddTrack(t2);
            user.AddTrack(t3);
            user.AddTrack(t4);
            user.AddTrack(t5);
            user.AddTrack(t6);
            user.AddTrack(t7);
            user.AddTrack(t8);
            user.AddTrack(t9);
            user.AddTrack(t10);

            user.PrintAllTracks();

            Console.WriteLine("Total Play Count: " + user.GetTotalPlayCount());

            // Testing overflow
            SayaMusicTrack overflowTest = new SayaMusicTrack("Overflow Test");

            for (int i = 0; i < 100; i++)
            {
                overflowTest.IncreasePlayCount(int.MaxValue);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}