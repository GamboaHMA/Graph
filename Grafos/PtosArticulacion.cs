using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class PtosArticulacion
    {
        public List<int> Ptos_Art(int V, List<(int, int)> edges)
        {
            List<List<int>> adj = new List<List<int>>();
            for (int i = 0; i < V; i++)
            {
                adj.Add(new List<int>());
            }

            foreach (var edge in edges)
            {
                adj[edge.Item1 - 1].Add(edge.Item2);
                adj[edge.Item2 - 1].Add(edge.Item1);
            }

            List<int> result = new List<int>();
            DFS_Ptos_Art(1, adj, new bool[V], new int[V], new int[V], new int[V], result, new List<int>(){ 0 });

            return result;
        }

        public void DFS_Ptos_Art(int i, List<List<int>> adj, bool[] visited, int[] d, int[] low, int[] pi, List<int> result, List<int> time)
        {
            visited[i - 1] = true;
            time[0]++;
            d[i - 1] = low[i - 1] = time[0];
            foreach (var node in adj[i - 1])
            {
                if (!visited[node - 1])
                {
                    pi[node - 1] = i;
                    DFS_Ptos_Art(node, adj, visited, d, low, pi, result, time);
                    low[i - 1] = Math.Min(low[i - 1], low[node - 1]);
                    if (low[node - 1] >= d[i - 1]) result.Add(i);
                }
                else if(pi[i - 1] != node)
                {
                    low[i - 1] = Math.Min(low[i - 1], d[node - 1]);
                }
            }
        }
    }
}
