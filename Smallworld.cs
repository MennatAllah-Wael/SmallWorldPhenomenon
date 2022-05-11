using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace SmallWorldPhenomenon
{
    class Smallworld
    {
        public static void read_movies(string path)
        {
            //split on /  [0] movie name    [:] actors
            Dictionary<string, List<string>> movie = new Dictionary<string, List<string>>();
            List<string> movie_name = new List<string>();
            string text = File.ReadAllText(path);
            string[] lineItems = text.Split('\n');
            for(int i = 0; i < lineItems.Length; i ++)
            {
                string[] s = lineItems[i].Split('/');
                List<string> actors = new List<string>();
                for (int j = 1; j < s.Length; j++)
                    actors.Add(s[j]);
                movie_name.Add(s[0]);
                movie[s[0]] = actors;
                Console.WriteLine(movie_name[movie_name.Count - 1]);
                for(int j = 0; j < movie_name.Count - 1; j ++)
                     Console.WriteLine(movie[movie_name[i]].);
            }

        }
        public static void read_quiries(string path)
        {
            string text = File.ReadAllText(path);
            string[] lineItems = text.Split('\n');
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < lineItems.Length - 1; i ++)
            {
                string[] s = lineItems[i].Split('/');
                KeyValuePair<string, string> pair = new KeyValuePair<string, string>(s[0], s[1]);
                list.Add(pair);
            }
        }
    }
}
