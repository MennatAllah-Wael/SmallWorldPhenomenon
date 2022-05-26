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
        public static Dictionary<string, Dictionary<string, int>> adj = new Dictionary<string, Dictionary<string, int>>();//actor name, list of adjacent actors + their relation strength
        public static Dictionary<KeyValuePair<string, string>, string> chain = new Dictionary<KeyValuePair<string, string>, string>();//pair<actor, actor>,common movies names
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
            string movie_name = "";
            string text = File.ReadAllText(path);
            string[] lineItems = text.Split('\n');
            for (int i = 0; i < lineItems.Length; i++)
            {
                //Console.WriteLine(i);
                string[] s = lineItems[i].Split('/');
                movie_name = s[0];
                for (int j = 1; j < s.Length; j++)
                {
                    if (!adj.ContainsKey(s[j]))
                        adj[s[j]] = new Dictionary<string, int>();
                    for (int jj = 1; jj < s.Length; jj++)
                    {
                        if (j != jj)
                        {
                            KeyValuePair<string, string> pair = new KeyValuePair<string, string>(s[j], s[jj]);
                            //if (!chain.ContainsKey(pair))
                            //    chain[pair] = new List<string>();
                            if (!adj[s[j]].ContainsKey(s[jj]))
                                adj[s[j]][s[jj]] = 1;
                            else
                                adj[s[j]][s[jj]]++;
                            chain[pair] = movie_name;
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
            List<string> parent_hold = new List<string>();
            Queue<string> q = new Queue<string>();
            q.Enqueue(source);
            //initialize the parents list for evry actor
            //color of all the actors = white
            foreach (string child in adj.Keys)
            {
                parent[child] = new List<string>();
                color[child] = 'w';
                relation_strength[child] = 0;
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
                foreach (string i in adj[u].Keys)
                {
                    if (color[i] == 'w')
                    {
                        KeyValuePair<string, string> pair = new KeyValuePair<string, string>(u, i);
                        if (relation_strength[u] + adj[u][i] >= relation_strength[i])
                            relation_strength[i] = relation_strength[u] + adj[u][i];
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
            Console.Write("CHAIN OF MOVIES: ");
            for (int i = parent_hold.Count - 1; i > 0; i--)
            {
                KeyValuePair<string, string> pair = new KeyValuePair<string, string>(parent_hold[i], parent_hold[i - 1]);
                if (i == 1)
                    Console.WriteLine(chain[pair]);
                else
                    Console.Write(chain[pair] + " => ");
            }
            Console.WriteLine();
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
