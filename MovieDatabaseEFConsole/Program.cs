using MovieDatabaseEFConsole.Models;
using System.ComponentModel.DataAnnotations;

//static void movieList()
//{
//    using MovieDBContext context = new MovieDBContext();
//    Movie newMovie1 = new Movie()
//    {
//        Title = "The Matrix",
//        Genre = "Sci-fi",
//        Runtime = 136
//    };
//    context.Movies.Add(newMovie1);
//    context.SaveChanges();
//    Movie newMovie2 = new Movie()
//    {
//        Title = "Fight Club",
//        Genre = "Thriller",
//        Runtime = 139
//    };
//    context.Movies.Add(newMovie2);
//    context.SaveChanges();
//    Movie newMovie3 = new Movie()
//    {
//        Title = "Black Sheep",
//        Genre = "Comedy",
//        Runtime = 87
//    };
//    context.Movies.Add(newMovie3);
//    context.SaveChanges();
//    Movie newMovie4 = new Movie()
//    {
//        Title = "Beverly Hills Cop",
//        Genre = "Action",
//        Runtime = 105
//    };
//    context.Movies.Add(newMovie4);
//    context.SaveChanges();
//    Movie newMovie5 = new Movie()
//    {
//        Title = "Enemy of the State",
//        Genre = "Action",
//        Runtime = 140
//    };
//    context.Movies.Add(newMovie5);
//    context.SaveChanges();
//    Movie newMovie6 = new Movie()
//    {
//        Title = "Harry Potter and the Sorcerers Stone",
//        Genre = "Fantasy",
//        Runtime = 152
//    };
//    context.Movies.Add(newMovie6);
//    context.SaveChanges();
//    Movie newMovie7 = new Movie()
//    {
//        Title = "The Lord of the Rings: The Fellowship of the Ring",
//        Genre = "Fantasy",
//        Runtime = 178
//    };
//    context.Movies.Add(newMovie7);
//    context.SaveChanges();
//    Movie newMovie8 = new Movie()
//    {
//        Title = "Dumb and Dumber",
//        Genre = "Comedy",
//        Runtime = 107
//    };
//    context.Movies.Add(newMovie8);
//    context.SaveChanges();
//    Movie newMovie9 = new Movie()
//    {
//        Title = "Happy Gilmore",
//        Genre = "Comedy",
//        Runtime = 93
//    };
//    context.Movies.Add(newMovie9);
//    context.SaveChanges();
//    Movie newMovie10 = new Movie()
//    {
//        Title = "Ghostbusters",
//        Genre = "Comedy",
//        Runtime = 105
//    };
//    context.Movies.Add(newMovie10);
//    context.SaveChanges();
//}
//movieList

bool runProgram = true;
while (runProgram)
{
    Console.WriteLine("Would you like to search for a movie by genre or title?");
    string input = Console.ReadLine().ToLower().Trim();
    if (input == "genre")
    {
        SearchByGenre();
    }
    else if (input == "title")
    {
        SearchByTitle();
    }
    else if (input != "genre" || input != "title")
    {
        Console.WriteLine("Invalid input, please type genre or title.");
    }
    runProgram = Validator.Validator.GetContinue();
}

static void SearchByGenre()
{
    using (MovieDBContext context = new MovieDBContext())
    {
        List<Movie> DistinctCategories = context.Movies.GroupBy(m => m.Genre).Select(m => m.First()).ToList();

            Console.WriteLine("Please enter a movie category.");
            for (int i = 0; i < DistinctCategories.Count; i++)
            {
                Console.WriteLine($"{i}. {DistinctCategories[i].Genre}");
            }
            int catId = 0;
            while (true)
            {
                catId = Validator.Validator.GetUserNumberInt();
                if (Validator.Validator.InRange(catId, 0, DistinctCategories.Count - 1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("out of range");
                }
            }
            string category = DistinctCategories[catId].Genre;
            context.Movies.Where(m => m.Genre == category).OrderBy(m => m.Title).ToList().ForEach(m =>
                 Console.WriteLine($"Title: {m.Title}\tCategory: {m.Genre}\tRuntime: {m.Runtime}"));
    }
    return;
}

static void SearchByTitle()
{
    using (MovieDBContext context = new MovieDBContext())
    {
        List<Movie> DistinctCategories = context.Movies.GroupBy(m => m.Title).Select(m => m.First()).ToList();

            Console.WriteLine("Please enter a movie title.");
            for (int i = 0; i < DistinctCategories.Count; i++)
            {
                Console.WriteLine($"{i}. {DistinctCategories[i].Title}");
            }
            int catId = 0;
            while (true)
            {
                catId = Validator.Validator.GetUserNumberInt();
                if (Validator.Validator.InRange(catId, 0, DistinctCategories.Count - 1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("out of range");
                }
            }
            string category = DistinctCategories[catId].Title;
            context.Movies.Where(m => m.Title == category).OrderBy(m => m.Title).ToList().ForEach(m =>
                 Console.WriteLine($"Title: {m.Title}\tCategory: {m.Genre}\tRuntime: {m.Runtime}"));
    }
    return;
}


//Methods I originally came up with...

//static void SearchByGenre()
//{
//    Console.WriteLine("Which genre would you like to see? Our current options are: Sci-fi, Thriller, Comedy, Action, Fantasy");
//    string choice = Console.ReadLine();
//    using (MovieDBContext context = new MovieDBContext())
//    {
//        List<Movie> result = context.Movies.Where(m => m.Genre == choice).ToList();
//        foreach (Movie m in result)
//        {
//            Console.WriteLine($"Title: {m.Title}\tGenre: {m.Genre}\tRuntime: {m.Runtime} minutes");
//        }
//    }
//    return;
//}

//static void SearchByTitle()
//{
//    Console.WriteLine("Which title would you like to see?");
//    string choice = Console.ReadLine();
//    using (MovieDBContext context = new MovieDBContext())
//    {
//        List<Movie> result = context.Movies.Where(m => m.Title == choice).ToList();
//        foreach (Movie m in result)
//        {
//            Console.WriteLine($"Title: {m.Title}\tGenre: {m.Genre}\tRuntime: {m.Runtime} minutes");
//        }
//    }
//    return;
//}