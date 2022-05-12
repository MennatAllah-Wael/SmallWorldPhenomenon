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
            long timeBefore, timeAfter;
            if (choice == '1')
            {                
                timeBefore = System.Environment.TickCount;
                queries = "Testcases\\Sample\\queries1.txt";
                Smallworld.read_quiries(queries);
                movies = "Testcases\\Sample\\movies1.txt";
                Smallworld.read_movies(movies);

                //function call
                //print the output
                timeAfter = System.Environment.TickCount;
                timeAfter -= timeBefore;
                Console.Write("Time taken : ");
                Console.WriteLine(timeAfter);
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
                    //Case 1
                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\small\\Case1\\queries110.txt";
                    Smallworld.read_quiries(queries);
                    movies = "Testcases\\Complete\\small\\Case1\\Movies193.txt";
                    Smallworld.read_movies(movies);

                    
                    Console.WriteLine("Case 1 (110 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);

                    //Case 2
                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\small\\Case2\\queries50.txt";
                    Smallworld.read_quiries(queries);
                    movies = "Testcases\\Complete\\small\\Case2\\Movies187.txt";
                    Smallworld.read_movies(movies);
                    
                    Console.WriteLine("Case 2 (50 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);


                }
                else if (choice2 == '2')
                {
                    //Case 1
                    timeBefore = System.Environment.TickCount;

                    queries = "Testcases\\Complete\\medium\\Case1\\queries85.txt";
                    Smallworld.read_quiries(queries);
                    movies = "Testcases\\Complete\\medium\\Case1\\Movies967.txt";
                    Smallworld.read_movies(movies);


                    Console.WriteLine("Case 1 (85 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);

                    queries = "Testcases\\Complete\\medium\\Case1\\queries4000.txt";
                    Smallworld.read_quiries(queries);

                    Console.WriteLine("Case 1 (4000 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);

                    //Case 2
                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\medium\\Case2\\queries110.txt";
                    Smallworld.read_quiries(queries);
                    movies = "Testcases\\Complete\\medium\\Case2\\Movies4736.txt";
                    Smallworld.read_movies(movies);

                    Console.WriteLine("Case 2 (110 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);

                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\medium\\Case2\\queries2000.txt";
                    Smallworld.read_quiries(queries);

                    Console.WriteLine("Case 2 (2000 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);

                }
                else if (choice2 == '3')
                {
                    //large
                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\large\\queries26.txt";
                    Smallworld.read_quiries(queries);
                    movies = "Testcases\\Complete\\large\\Movies14129.txt";
                    Smallworld.read_movies(movies);

                    Console.WriteLine("Case (26 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : "); 
                    Console.WriteLine(timeAfter);

                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\large\\queries600.txt";
                    Smallworld.read_quiries(queries);

                    Console.WriteLine("Case (600 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);
                }
                else if (choice2 == '4')
                {
                    //extreme
                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\extreme\\queries22.txt";
                    Smallworld.read_quiries(queries);
                    movies = "Testcases\\Complete\\extreme\\Movies122806.txt";
                    Smallworld.read_movies(movies);


                    Console.WriteLine("Case (22 queries): ");
                    //function call 
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);

                    timeBefore = System.Environment.TickCount;
                    queries = "Testcases\\Complete\\extreme\\queries200.txt";
                    Smallworld.read_quiries(queries);
                    
                    Console.WriteLine("Case (200 queries): ");
                    //function call
                    //print the output
                    timeAfter = System.Environment.TickCount;
                    timeAfter -= timeBefore;
                    Console.Write("Time taken : ");
                    Console.WriteLine(timeAfter);
                }
                else
                    Console.WriteLine("Invalide input!");
            }
            else
                Console.WriteLine("Invalide input!");
        }
    }
}
