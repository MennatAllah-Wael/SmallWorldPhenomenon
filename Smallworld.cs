using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace SmallWorldPhenomenon
{
    class Smallworld
    {
        public static Dictionary<string, List<string>> movie = new Dictionary<string, List<string>>();//movie name, list of actors
        public static Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();//actor name, list of adjacent actors
        public static Dictionary<KeyValuePair<string, string>, int> relation = new Dictionary<KeyValuePair<string, string>, int>();//pair<actor, actor>, no of common movies
        public static Dictionary<KeyValuePair<string, string>, List<string>> chain = new Dictionary<KeyValuePair<string, string>, List<string>>();//pair<actor, actor>,common movies names
        public static List<string> actors = new List<string>();
        public static List<KeyValuePair<string, string>> read_quiries(string path, bool sample)
        {
            string text = File.ReadAllText(path);
            string[] lineItems;
            if (sample)
            {
                string[] c = { "\r\n" };
                lineItems = text.Split(c, StringSplitOptions.None);
            }
            else
                lineItems = text.Split('\n');

            List<KeyValuePair<string, string>> quiries = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < lineItems.Length - 1; i++)
            {
                string[] s = lineItems[i].Split('/');
                KeyValuePair<string, string> pair = new KeyValuePair<string, string>(s[0], s[1]);
                quiries.Add(pair);
            }
            return quiries;
        }
        public static void read_movies(string path)
        {
            //split on /  [0] movie name    [:] actors
            List<string> movie_name = new List<string>();
            string text = File.ReadAllText(path);
            string[] lineItems = text.Split('\n');
            for (int i = 0; i < lineItems.Length; i++)
            {
                string[] s = lineItems[i].Split('/');
                List<string> actors = new List<string>();
                for (int j = 1; j < s.Length; j++)
                {
                    actors.Add(s[j]);
                    adj[s[j]] = new List<string>();
                }
                movie_name.Add(s[0]);
                movie[movie_name[movie_name.Count - 1]] = actors;
            }
            
            graph();
        }
        public static void graph()
        {
            foreach (string movie_name in movie.Keys)
            {
                foreach (string actor1 in movie[movie_name])
                { 
                    foreach (string actor2 in movie[movie_name])
                    {
                        KeyValuePair<string, string> pair = new KeyValuePair<string, string>(actor1, actor2);
                        if (actor1 != actor2)
                        {
                            chain[pair] = new List<string>();
                            if (adj[actor1].Contains(actor2))
                            {
                                chain[pair].Add(movie_name);
                                relation[pair]++;
                            }
                            else
                            {
                                adj[actor1].Add(actor2);
                                chain[pair].Add(movie_name);
                                relation[pair] = 1;
                            }
                        }
                    }
                }
            }
        }
        public static void BFS(string source, string dist)
        {
            Dictionary<string, List<string>> parent = new Dictionary<string, List<string>>();//key = child, value = parent
            Dictionary<string, char> color = new Dictionary<string, char>();
            Dictionary<string, int> relation_strength = new Dictionary<string, int>();
            Dictionary<string, int> degree = new Dictionary<string, int>();
            Queue<string> q = new Queue<string>();
            q.Enqueue(source);
            //initialize the parents list for evry actor
            //color of all the actors = white
            foreach (string child in adj.Keys)
            {
                parent[child] = new List<string>();
                color[child] = 'w';
            }
            color[source] = 'g';
            degree[source] = 0;
            relation_strength[source] = 0;
            string u = "";
                        
            while (q.Count != 0)
            {
                u = q.Dequeue();
                if (u == dist)
                    break;
                foreach (string i in adj[u])
                {
                    if (color[i] == 'w')
                    {
                        KeyValuePair<string, string> pair = new KeyValuePair<string, string>(u, i);
                        relation_strength[i] = relation_strength[u] + relation[pair];
                        color[i] = 'g';
                        degree[i] = degree[u] + 1;
                        parent[i].Add(u);
                        q.Enqueue(i);
                    }
                }
                color[u] = 'b';
            }
            string v = dist;
            u = source;
            List<string> parent_hold = new List<string>();
            parent_hold.Add(dist);

            while (v != u)
            {
                int max = -1;
                string hold = "";
                foreach (string p in parent[v])
                {
                    if (relation_strength[p] >= max)
                    {
                        max = relation_strength[p];
                        hold = p;
                    }
                }
                parent_hold.Add(hold);
                v = hold;
            }
            Console.WriteLine("DoS = " + degree[dist] + ", RS = " + relation_strength[dist]);
            Console.Write("CHAIN OF ACTORS: ");
            for (int i = parent_hold.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                    Console.WriteLine(parent_hold[i]);
                else
                    Console.Write(parent_hold[i] + " -> ");
            }
            Console.Write("CHAIN OF MOVIES:  ");
            for (int i = parent_hold.Count - 1; i > 0; i--)
            {
                KeyValuePair<string, string> pair = new KeyValuePair<string, string>(parent_hold[i], parent_hold[i - 1]);
                if (i == 1)
                    Console.WriteLine(chain[pair][0]);
                else
                    Console.Write(chain[pair][0] + " => ");
            }
        }
        public static void execute(List<KeyValuePair<string, string>> queiry)
        {
            foreach (KeyValuePair<string, string> pair in queiry)
            {
                Console.WriteLine(pair.Key + '/' + pair.Value);
                BFS(pair.Key, pair.Value);
            }
        }
    }
}
