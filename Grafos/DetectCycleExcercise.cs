using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class DetectCycleExcercise
    {
        public int DetectCycle(int V, List<List<int>> adj)
        
        {
            int count = 0;
            char[] visited = new char[V];

            for (int i = 0; i < V; i++)
            {
                visited[i] = 'W';
            }

            for (int i = 0; i < V; i++)
            {
                if (visited[i] == 'W') count += DFS_Cycles(new Node(i) ,i, visited, adj); 
            }

            return count;
        }

        public int DFS_Cycles(Node parent ,int i, char[] visited, List<List<int>> adj)
        {
            int count = 0;
            visited[i] = 'G';
            Node node = new Node(i, parent);

            foreach (var adjs in adj[i])
            {
                if (visited[adjs] == 'W') count += DFS_Cycles(node, adjs, visited, adj);
                else if (visited[adjs] == 'G' && node.Parent.Value != adjs) count++;
            }

            visited[i] = 'B';
            return count;
        }

    }
}
