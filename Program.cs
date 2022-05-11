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
            if (choice == '1')
            {
                string queries = "Testcases\\Sample\\queries1.txt";
                Smallworld.read_quiries(queries);

                string movie = "Testcases\\Sample\\movies1.txt";
                Smallworld.read_movies(movie);

            }
            else if (choice == '2')
            {
                string queries1;
                Console.WriteLine("[1] Small\n" +
                                  "[2] Medium\n" +
                                  "[3] Large\n" +
                                  "[4] Extreme\n" +
                                  "Enter your choice [1-4]: ");
                char choice2 = (char)Console.ReadLine()[0];
                if (choice2 == '1')
                { 
                    //Case 1
                    queries1 = "Testcases\\Complete\\small\\Case1\\queries110.txt";
                    Smallworld.read_quiries(queries1);
                    //Case 2
                    queries1 = "Testcases\\Complete\\small\\Case2\\queries50.txt";
                    Smallworld.read_quiries(queries1);

                }
                else if (choice2 == '2')
                {
                    //Case 1
                    queries1 = "Testcases\\Complete\\medium\\Case1\\queries85.txt";
                    Smallworld.read_quiries(queries1);
                    queries1 = "Testcases\\Complete\\medium\\Case1\\queries4000.txt";
                    Smallworld.read_quiries(queries1);
                    //Case 2
                    queries1 = "Testcases\\Complete\\medium\\Case2\\queries110.txt";
                    Smallworld.read_quiries(queries1); 
                    queries1 = "Testcases\\Complete\\medium\\Case2\\queries2000.txt";
                    Smallworld.read_quiries(queries1);

                }
                else if (choice2 == '3')
                {
                    //large
                    queries1 = "Testcases\\Complete\\large\\queries26.txt";
                    Smallworld.read_quiries(queries1); 
                    queries1 = "Testcases\\Complete\\large\\queries600.txt";
                    Smallworld.read_quiries(queries1);

                }
                else if (choice2 == '4')
                {
                    //extreme
                    queries1 = "Testcases\\Complete\\extreme\\queries22.txt";
                    Smallworld.read_quiries(queries1);
                    queries1 = "Testcases\\Complete\\extreme\\queries200.txt";
                    Smallworld.read_quiries(queries1);
                }
                else
                    Console.WriteLine("Invalide input!");
            }
            else
                Console.WriteLine("Invalide input!");
        }
    }
}
