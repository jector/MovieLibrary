
using Movielibrary.Models;
using Newtonsoft.Json;

namespace Movielibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieFilePath = $"{Environment.CurrentDirectory}/data/movies.csv";
            
            MovieFile movieFile = new MovieFile(movieFilePath);

            string choice = "";
            do
            {
                // display choices to user
                Console.WriteLine("1) Add Movie");
                Console.WriteLine("2) Display All Movies");
                Console.WriteLine("Enter to quit");
                // input selection
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Add movie
                    Movie movie = new Movie();
                    // ask user to input movie title
                    Console.WriteLine("Enter movie title");
                    // input title
                    movie.title = Console.ReadLine();
                    // verify title is unique
                    if (movieFile.isUniqueTitle(movie.title)){
                        // input genres
                        string input;
                        do
                        {
                            // ask user to enter genre
                            Console.WriteLine("Enter genre (or done to quit)");
                            // input genre
                            input = Console.ReadLine();
                            // if user enters "done"
                            // or does not enter a genre do not add it to list
                            if (input != "done" && input.Length > 0)
                            {
                                movie.genres.Add(input);
                            }
                        } while (input != "done");
                        // specify if no genres are entered
                        if (movie.genres.Count == 0)
                        {
                            movie.genres.Add("(no genres listed)");
                        }
                        // add movie
                        movieFile.AddMovie(movie);
                    }
                } else if (choice == "2")
                {
                    // Display All Movies
                    //string json = JsonConvert.SerializeObject(movieFile);
                    foreach(Movie m in movieFile.Movies.Skip(Math.Max(0, movieFile.Movies.Count - 10)))
                    {
                        string json = JsonConvert.SerializeObject(m.Display());
                        Console.WriteLine(json);
                    }
                    /*
                     foreach (var item in list.Skip(Math.Max(0, list.Count - 50)))
                     foreach (var item in list.Skip(list.Count-50))
                     for (int i = Math.Max(0, list.Count - 50); i < list.Count; ++i)
                     for (int i = list.Count-50; i < list.Count; ++i)
                    */
                }
            } while (choice == "1" || choice == "2");
        }
    }
}
