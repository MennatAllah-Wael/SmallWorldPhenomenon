using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SmallWorldPhenomenon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Small world phenomenon:\n" +
                              "[1] Sample test cases\n" +
                              "[2] Complete testing");
            Console.Write("\nEnter your choice [1-2]: ");
            char choice = (char)Console.ReadLine()[0];
            string queries, movies;
            bool sample = false;
            if (choice == '1')
            {
                Stopwatch s = new Stopwatch();
                s.Start();
                sample = true;               
                queries = "Testcases\\Sample\\queries1.txt";
                movies = "Testcases\\Sample\\movies1.txt";
                Smallworld.read_movies(movies);
                Smallworld.execute(Smallworld.read_quiries(queries, sample));
                s.Stop();
                TimeSpan ts = s.Elapsed;
                Console.WriteLine("Time taken : " + ts);
            }
            else if (choice == '2')
            {
                Console.WriteLine("[1] Small\n" +
                                  "[2] Medium\n" +
                                  "[3] Large\n" +
                                  "[4] Extreme\n" +
                                  "Enter your choice [1-4]: ");
                char choice2 = (char)Console.ReadLine()[0];
                if (choice2 == '1')
                {
                    Console.WriteLine("[1] Case 1\n" +
                                      "[2] Case 2\n" +
                                      "Enter your choice [1-2]: ");
                    choice2 = (char)Console.ReadLine()[0];
                    if (choice2 == '1') //Case 1
                    {
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        queries = "Testcases\\Complete\\small\\Case1\\queries110.txt";
                        movies = "Testcases\\Complete\\small\\Case1\\Movies193.txt";
                        Console.WriteLine("Case 1 (110 queries): ");
                        Smallworld.read_movies(movies);
                        Smallworld.execute(Smallworld.read_quiries(queries, sample));
                        s.Stop();
                        TimeSpan ts = s.Elapsed;
                        Console.WriteLine("Time taken : " + ts);
                    }
                    else  //Case 2
                    {
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        queries = "Testcases\\Complete\\small\\Case2\\queries50.txt";
                        movies = "Testcases\\Complete\\small\\Case2\\Movies187.txt";
                        Console.WriteLine("Case 2 (50 queries): ");
                        Smallworld.read_movies(movies);
                        Smallworld.execute(Smallworld.read_quiries(queries, sample));
                        s.Stop();
                        TimeSpan ts = s.Elapsed;
                        Console.WriteLine("Time taken : " + ts);
                    }
                }
                else if (choice2 == '2')
                {
                    Console.WriteLine("[1] Case 1\n" +
                                      "[2] Case 2\n" +
                                      "Enter your choice [1-2]: ");
                    choice2 = (char)Console.ReadLine()[0];

                    if (choice2 == '1') //Case 1
                    {
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        queries = "Testcases\\Complete\\medium\\Case1\\queries85.txt";
                        movies = "Testcases\\Complete\\medium\\Case1\\Movies967.txt";
                        Console.WriteLine("Case 1 (85 queries): ");
                        Smallworld.read_movies(movies);
                        Smallworld.execute(Smallworld.read_quiries(queries, sample));
                        s.Stop();
                        TimeSpan ts = s.Elapsed;
                        Console.WriteLine("Time taken : " + ts);
                        Console.WriteLine("Case 1 (4000 queries): ");
                        s = new Stopwatch();
                        s.Start();
                        queries = "Testcases\\Complete\\medium\\Case1\\queries4000.txt";
                        Smallworld.execute(Smallworld.read_quiries(queries, sample));
                        s.Stop();
                        ts = s.Elapsed;
                        Console.WriteLine("Time taken : " + ts);
                    }
                    else
                    {
                        //Case 2
                        Stopwatch s = new Stopwatch();
                        s.Start();
                        queries = "Testcases\\Complete\\medium\\Case2\\queries110.txt";
                        movies = "Testcases\\Complete\\medium\\Case2\\Movies4736.txt";
                        Console.WriteLine("Case 2 (110 queries): ");
                        Smallworld.read_movies(movies);
                        Smallworld.execute(Smallworld.read_quiries(queries, sample));
                        s.Stop();
                        TimeSpan ts = s.Elapsed;
                        Console.WriteLine("Time taken : " + ts);

                        s = new Stopwatch();
                        s.Start();
                        queries = "Testcases\\Complete\\medium\\Case2\\queries2000.txt";
                        Console.WriteLine("Case 2 (2000 queries): ");
                        Smallworld.execute(Smallworld.read_quiries(queries, sample));
                        s.Stop();
                        ts = s.Elapsed;
                        Console.WriteLine("Time taken : " + ts);
                    }
                }
                else if (choice2 == '3')
                {
                    //large
                    Stopwatch s = new Stopwatch();
                    s.Start();
                    queries = "Testcases\\Complete\\large\\queries26.txt";
                    movies = "Testcases\\Complete\\large\\Movies14129.txt";
                    Console.WriteLine("Case (26 queries): ");

                    Smallworld.read_movies(movies);
                    Smallworld.execute(Smallworld.read_quiries(queries, sample));
                    s.Stop();
                    TimeSpan ts = s.Elapsed;
                    Console.WriteLine("Time taken : " + ts);
                    s = new Stopwatch();
                    s.Start();
                    queries = "Testcases\\Complete\\large\\queries600.txt";
                    Console.WriteLine("Case (600 queries): ");
                    Smallworld.execute(Smallworld.read_quiries(queries, sample));
                    s.Stop();
                    ts = s.Elapsed;
                    Console.WriteLine("Time taken : " + ts);
                }
                else if (choice2 == '4')
                {
                    //extreme
                    Stopwatch s = new Stopwatch();
                    s.Start();
                    queries = "Testcases\\Complete\\extreme\\queries22.txt";
                    movies = "Testcases\\Complete\\extreme\\Movies122806.txt";
                    Console.WriteLine("Case (22 queries): ");
                    Smallworld.read_movies(movies);
                    Smallworld.execute(Smallworld.read_quiries(queries, sample));
                    s.Stop();
                    TimeSpan ts = s.Elapsed;
                    Console.WriteLine("Time taken : " + ts);
                    s = new Stopwatch();
                    s.Start();
                    queries = "Testcases\\Complete\\extreme\\queries200.txt";
                    Console.WriteLine("Case (200 queries): ");
                    Smallworld.execute(Smallworld.read_quiries(queries, sample));
                    s.Stop();
                    ts = s.Elapsed;
                    Console.WriteLine("Time taken : " + ts);
                }
                else
                    Console.WriteLine("Invalide input!");
            }
            else
                Console.WriteLine("Invalide input!");
        }
    }
}
