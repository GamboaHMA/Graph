using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class ComponenteComplConexaEjercicio
    {
        public static int FindNumberOfGoodCompponent(int V, List<(int, int)> edges)
        {
            int count = 0;
            bool[] visited = new bool[V];
            
            List< List<int>> adj = new List<List<int>>();

            for (int i = 1; i <= V; i++)
            {
                adj.Add((new List<int>()));
            }

            foreach (var edge in edges)
            {
                adj[edge.Item1 - 1].Add(edge.Item2);
                adj[edge.Item2 - 1].Add(edge.Item1);
            }

            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    List<int> suma = new List<int>() { 0 };
                    List<int> cantNodos = new List<int>() { 0 };
                    DFS(i, visited, adj, suma, cantNodos);
                    if (suma[0] == Sumatoria(cantNodos[0] - 1)) count++;
                }
            }

            return count;
        }

        public static void DFS(int i, bool[] visited, List<List<int>> adj, List<int> suma, List<int> cantNodos)
        {
            cantNodos[0]++;
            visited[i] = true;
            if (adj[i].Count != 0)
            {
                foreach (var j in adj[i])
                {
                    adj[j - 1].Remove(i + 1);
                }

                foreach (var j in adj[i])
                {
                    suma[0] += 1;
                    if (!visited[j - 1])
                    {
                        DFS(j - 1, visited, adj, suma, cantNodos);
                    }
                }
               
                return;
                
            }
            else return;
            
        }


        public static int CompCompletConexDFS(int V, List<List<int>> edges)
        {
            List<List<int>> adj = new List<List<int>>();

            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
            }

            foreach (var edge in edges)
            {
                adj[edge[0] - 1].Add(edge[1]);
                adj[edge[1] - 1].Add(edge[0]);
            }

            int count = 0;
            char[] visited = new char[V];

            for (int i = 0;i< V; i++)
            {
                visited[i] = 'W';
            }

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == 'W') 
                {
                    List<int> suma = new List<int> { 0 };
                    List<int> cant_nodos = new List<int> { 0 };
                    DFS_(i, suma, cant_nodos, adj, visited);
                    if (suma[0] == Sumatoria(cant_nodos[0] - 1)) count++;
                }
            }

            return count;
        }

        public static void DFS_(int i, List<int> suma, List<int> cant_nodos, List<List<int>> adj, char[] visited)
        {
            visited[i] = 'G';
            cant_nodos[0] += 1;
            foreach (var nodes in adj[i])
            {
                if (visited[nodes - 1] == 'W') DFS_(nodes - 1, suma, cant_nodos, adj, visited);
                else if (visited[nodes - 1] == 'G') suma[0]++;
            }
            visited[i] = 'B';
        }

        public static int Sumatoria(int n)
        {
            if(n == 0) return 0;
            return n + Sumatoria(n - 1);
        }
    }
}
