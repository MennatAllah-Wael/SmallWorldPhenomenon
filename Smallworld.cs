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
        public static Dictionary<string, Dictionary<string, List<string>>> adj = new Dictionary<string, Dictionary<string, List<string>>>();//actor name, list of adjacent actors + their relation strength                                                                                                                     //public static string output = "";
        public static List<KeyValuePair<string, string>> read_quiries(string path, bool sample)//O(L)->numberoflines
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
            for (int i = 0; i < lineItems.Length - 1; i++) //O(L)->numberoflines
            {
                string[] s = lineItems[i].Split('/');
                KeyValuePair<string, string> pair = new KeyValuePair<string, string>(s[0], s[1]);
                quiries.Add(pair);
            }
            return quiries;
        }
        public static void read_movies(string path)//O(L*N*N)->numberoflines*numberofactorsinfilm*numberofactorsinfilm
        {
            //int z = 0;
            string movie_name = "";
            string text = File.ReadAllText(path);
            string[] lineItems = text.Split('\n');
            for (int i = 0; i < lineItems.Length; i++)//O(L*N*N)->numberoflines*numberofactorsinfilm*numberofactorsinfilm
            {
                //Console.WriteLine(z);
                string[] s = lineItems[i].Split('/');
                movie_name = s[0];
                for (int j = 1; j < s.Length; j++)//O(N*N)->numberofactorsinfilm*numberofactorsinfilm
                {
                    if (!adj.ContainsKey(s[j]))
                        adj[s[j]] = new Dictionary<string, List<string>>();
                    for (int jj = 1; jj < s.Length; jj++)//O(N)->numberofactorsinfilm
                    {
                        if (j != jj)
                        {
                            KeyValuePair<string, string> pair = new KeyValuePair<string, string>(s[j], s[jj]);

                            if (!adj[s[j]].ContainsKey(s[jj]))
                                adj[s[j]][s[jj]] = new List<string>();
                            adj[s[j]][s[jj]].Add(movie_name);
                        }
                    }
                }
                //z++;
            }
        }
        public static void BFS(string source, string dist, ref string output)//O(A*A)->numberofactorsfromsourcetodistination*numberofadjacentactors
        {
            Dictionary<string, string> parent = new Dictionary<string, string>();//key = child, value = paren
            Dictionary<string, char> color = new Dictionary<string, char>();
            Dictionary<string, int> relation_strength = new Dictionary<string, int>();
            Dictionary<string, int> degree = new Dictionary<string, int>();
            List<string> parent_hold = new List<string>();
            Queue<string> q = new Queue<string>();
            q.Enqueue(source);
            foreach (string child in adj.Keys)//O(A)->numberofactors
            {
                parent[child] = "";
                color[child] = 'w';
                relation_strength[child] = 0;
                degree[child] = 0;
            }
            color[source] = 'g';
            string u = "";
            while (q.Count != 0)//O(A*A)->numberofactorsfromsourcetodistination*numberofadjacentactors
            {
                u = q.Dequeue();
                if (degree[u] == degree[dist] && degree[u] != 0)
                    break;
                foreach (string i in adj[u].Keys)//O(A)->numberofadjacentactors
                {
                    if (color[i] == 'w')
                    {
                        relation_strength[i] = relation_strength[u] + adj[u][i].Count;
                        color[i] = 'g';
                        degree[i] = degree[u] + 1;
                        parent[i] = u;
                        q.Enqueue(i);
                    }
                    else if (degree[i] > degree[u] && relation_strength[u] + adj[u][i].Count > relation_strength[i])
                    {
                        relation_strength[i] = relation_strength[u] + adj[u][i].Count;
                        parent[i] = u;
                    }
                }
                color[u] = 'b';
            }
            string v = dist;
            u = source;
            parent_hold.Add(dist);
            while (v != u)//O(E)->numberofedgesbetweensourceanddistination
            {
                parent_hold.Add(parent[v]);
                v = parent[v];
            }
            output += "DoS = " + degree[dist] + ", RS = " + relation_strength[dist] + "\n";
            output += "CHAIN OF ACTORS: ";
            for (int i = parent_hold.Count - 1; i >= 0; i--)//O(V)->numberofactorsbetweensourceanddistination(vertices)
            {
                if (i == 0)
                    output += parent_hold[i] + "\n";
                else
                    output += parent_hold[i] + " -> ";
            }
            output += "CHAIN OF MOVIES: ";
            for (int i = parent_hold.Count - 1; i > 0; i--)//O(V)->numberofactorsbetweensourceanddistination(vertices)
            {
                if (i == 1)
                    output += adj[parent_hold[i]][parent_hold[i - 1]][0] + "\n";
                else
                    output += adj[parent_hold[i]][parent_hold[i - 1]][0] + " => ";
            }
            output += "\n";
        }
        public static void execute(List<KeyValuePair<string, string>> queiry)
        {
            int m = 0;
            string output = "";
            foreach (KeyValuePair<string, string> pair in queiry)//O(Q*A*A)->numberofqueries*numberofactorsfromsourcetodistination*numberofadjacentactors
            {
                if (m == 0)
                {
                    output = pair.Key + '/' + pair.Value + "\n";
                    m++;
                }
                else
                    output += pair.Key + '/' + pair.Value + "\n";
                BFS(pair.Key, pair.Value, ref output);//O(A*A)->numberofactorsfromsourcetodistination*numberofadjacentactors
            }
            Console.WriteLine(output);
        }
    }
}