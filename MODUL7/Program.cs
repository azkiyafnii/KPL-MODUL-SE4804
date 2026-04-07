using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace mod7_streaming
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FilmFavorite_1302213102 film = new FilmFavorite_1302213102();
            film.ReadJSON();

            Watchlist_1302213102 watchlist = new Watchlist_1302213102();
            watchlist.ReadJSON();

            GenreDictionary_1302213102 genre = new GenreDictionary_1302213102();
            genre.ReadJSON();
        }
    }

    // ====================== NOMOR 1 ======================
    // Film Favorite

    internal class Film
    {
        public string title { get; set; }
        public string director { get; set; }
        public int year { get; set; }
        public string genre { get; set; }
        public double rating { get; set; }
        public int durationMinutes { get; set; }
        public bool isWatched { get; set; }
    }

    internal class FilmFavorite_1302213102
    {
        public void ReadJSON()
        {
            string jsonString = File.ReadAllText("jurnal7_1_nim.json");
            Film film = JsonSerializer.Deserialize<Film>(jsonString);

            Console.WriteLine("=== Film Favorite ===");
            Console.WriteLine("Title : " + film.title);
            Console.WriteLine("Director : " + film.director);
            Console.WriteLine("Year : " + film.year);
            Console.WriteLine("Genre : " + film.genre);
            Console.WriteLine("Rating : " + film.rating);
            Console.WriteLine("Duration : " + film.durationMinutes + " minutes");
            Console.WriteLine("Watched : " + film.isWatched);
            Console.WriteLine();
        }
    }

    // ====================== NOMOR 2 ======================
    // Watchlist Kelompok

    internal class Movie
    {
        public string id { get; set; }
        public string title { get; set; }
        public int year { get; set; }
        public string genre { get; set; }
        public double rating { get; set; }
    }

    internal class WatchlistData
    {
        public string watchlistName { get; set; }
        public string createdBy { get; set; }
        public List<Movie> movies { get; set; }
    }

    internal class Watchlist_1302213102
    {
        public void ReadJSON()
        {
            string jsonString = File.ReadAllText("jurnal7_2_nim.json");
            WatchlistData data = JsonSerializer.Deserialize<WatchlistData>(jsonString);

            Console.WriteLine("=== Watchlist ===");
            Console.WriteLine("Watchlist Name : " + data.watchlistName);
            Console.WriteLine("Created By : " + data.createdBy);
            Console.WriteLine("Movies : ");

            for (int i = 0; i < data.movies.Count; i++)
            {
                Console.WriteLine(data.movies[i].id + " " +
                                  data.movies[i].title + " (" +
                                  data.movies[i].year + " - " +
                                  data.movies[i].rating + ")");
            }

            Console.WriteLine();
        }
    }

    // ====================== NOMOR 3 ======================
    // Genre Dictionary (Nested JSON)

    internal class GenreDictionary_1302213102
    {
        public GenreRoot GenreDictionary { get; set; }

        public void ReadJSON()
        {
            string jsonString = File.ReadAllText("jurnal7_3_nim.json");
            GenreDictionary_1302213102 result =
                JsonSerializer.Deserialize<GenreDictionary_1302213102>(jsonString);

            GenreInfo info = result.GenreDictionary.GenreInfo;

            Console.WriteLine("=== Genre Info ===");
            Console.WriteLine("ID : " + info.id);
            Console.WriteLine("Name : " + info.name);
            Console.WriteLine("Description : " + info.description);
            Console.WriteLine("Popular Movies : " +
                string.Join(", ", info.popularMovies));
        }
    }

    public class GenreRoot
    {
        public string category { get; set; }
        public GenreInfo GenreInfo { get; set; }
    }

    public class GenreInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<string> popularMovies { get; set; }
    }
}