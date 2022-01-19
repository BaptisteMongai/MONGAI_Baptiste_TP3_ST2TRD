using System;
using System.Linq;
using System.Threading;

namespace TP_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var listMovie = new MovieCollection().Movies;

            var first = listMovie.OrderBy(x => x.ReleaseDate).First().Title;
            Console.WriteLine("Display the title of the oldest movie : ");
            Console.WriteLine(first);

            var count = listMovie.Count();
            Console.WriteLine("Count all movies : ");
            Console.WriteLine(count);

            var letterE = listMovie.Count(x => x.Title.Contains("e"));
            Console.WriteLine("Count all movies with the letter e. at least once in the title : ");
            Console.WriteLine(letterE);

            var letterF = listMovie.Where(x => x.Title.Contains("f")).Select(x=> x.Title);
            var titreF = string.Join(",", letterF);
            var nbF = titreF.Count(x => x == 'f');
            Console.WriteLine("Count how many time the letter f is in all the titles from this list : ");
            Console.WriteLine(nbF);

            var higherBudget = listMovie.OrderByDescending(x => x.Budget).First().Title;
            Console.WriteLine("Display the title of the film with the higher budget : ");
            Console.WriteLine(higherBudget);
            
            var lowestBoxoffice = listMovie.OrderBy(x => x.BoxOffice).First().Title;
            Console.WriteLine("Display the title of the movie with the lowest box office : ");
            Console.WriteLine(lowestBoxoffice);

            var film = listMovie.OrderByDescending(x => x.Title).Take(11);
            Console.WriteLine("Order the movies by reversed alphabetical order and print the first 11 of the list : ");
            foreach (var movies in film)
            {
                Console.WriteLine(movies.Title);
            }
            
            var before1980 = listMovie.Where(x => x.ReleaseDate.Year <= 1980).Count();
            Console.WriteLine("Count all the movies made before 1980 : ");
            Console.WriteLine(before1980);
            
            string vowel = "AEIOUY";
            var avgTime = listMovie.Where(x => vowel.Contains(x.Title[0])).Average(x => x.RunningTime);
            Console.WriteLine("Display the average running time of movies having a vowel as the first letter : ");
            Console.WriteLine(avgTime);
            
            var titleWithLetter = listMovie.Where(x => (x.Title.Contains("H") || x.Title.Contains("W")
                                                                || x.Title.Contains("h") || x.Title.Contains("w")) &&
                                                            !(x.Title.Contains("I")|| x.Title.Contains("i") 
                                                                || x.Title.Contains("t")  || x.Title.Contains("T")));
            
            Console.WriteLine("Print all movies with the letter H or W in the title, but not the letter I or T : ");
            foreach (var film2 in titleWithLetter)
            {
                Console.WriteLine(film2.Title);
            }
            
            var meanBudgetBox = listMovie.Average(x => x.Budget / x.BoxOffice);
            Console.WriteLine("Calculate the mean of all Budget / Box Office of every movie ever : ");
            Console.WriteLine(meanBudgetBox);

            Exercice2 thread = new Exercice2();
            var thread1 = new Thread(() => thread.Run(10, 50, " " ));
            var thread2 = new Thread(() => thread.Run(11, 40, "*"));
            var thread3 = new Thread(() => thread.Run(9, 20, "°"));

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            
        }
    }
}