namespace Grafos
{
    public class Grafo
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set;}
        public Grafo(List<Node> nodes, List<Edge> edges)
        {
            Nodes = nodes;
            Edges = edges;
        }

        public Dictionary<Node, int> Simple_BFS(Node node, Dictionary<Node, int> dict, Queue<Node> queue) //BFS
        {
            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                foreach (var ady in n.AdyacentNodes)
                {
                    if (dict[ady] == -1)
                    {
                        dict[ady] = dict[n] + 1;
                        queue.Enqueue(ady);
                    }
                }
            }
            return dict;
        }
                                                              //the variable dict is initialized whith all at -1, except the parameter node, it starts at 0
        public Dictionary<Node, Node> Simple_BFS_Pi(Node node, Dictionary<Node, int> dict, Queue<Node> queue, Dictionary<Node, Node> pi)
        {
            while (queue.Count > 0)
            {
                Node n = queue.Dequeue();
                foreach (var ady in n.AdyacentNodes)
                {
                    if(dict[ady] == -1)
                    {
                        dict[ady] = dict[n] + 1;
                        pi[ady] = n;
                        queue.Enqueue(ady);
                    }
                }
            }
            return pi;
        }

        public Dictionary<Node, int> Simple_DFS(Dictionary<Node, int> compConex, Dictionary<Node, bool> visited, Dictionary<Node, Node> pi)
        {
            int i = 1;
            foreach (var n in Nodes)
            {
                if (!visited[n])
                {
                    DFS(n, compConex, visited, pi, i);
                    i++;
                }
            }
            return compConex;
        }

        public Dictionary<Node, Node> Simple_DFS_Pi(Dictionary<Node, int> compConex, Dictionary<Node, bool> visited, Dictionary<Node, Node> pi)
        {
            int i = 1;
            foreach (var n in Nodes)
            {
                if (!visited[n])
                {
                    DFS(n, compConex, visited, pi, i);
                    i++;
                }
            }
            return pi;
        }


        public void DFS(Node n, Dictionary<Node, int> compConex, Dictionary<Node, bool> visited, Dictionary<Node, Node> pi, int i)
        {
            visited[n] = true;
            foreach (var node in n.AdyacentNodes)
            {
                if (!visited[node])
                {
                    pi[node] = n;
                    DFS(node, compConex, visited, pi, i);
                }
            }
            compConex[n] = i;
        }



        public Dictionary<Node, int> InicializarDict(Node n)
        {
            Dictionary<Node, int> dict = new Dictionary<Node,int>();
            foreach (var node in Nodes)
            {
                dict.Add(node, -1);
            }
            dict[n] = 0;
            return dict;
        }

        public Dictionary<Node, int> InicializarDict()
        {
            Dictionary<Node, int> dict = new Dictionary<Node, int>();
            foreach (var node in Nodes)
            {
                dict.Add(node, -1);
            }
            return dict;
        }

        public Dictionary<Node, Node> InicializarPi()
        {
            Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
            foreach (var node in Nodes)
            {
                dict.Add(node, null);
            }
            return dict;
        }

        public Dictionary<Node, bool> InicializarVisited()
        {
            Dictionary<Node, bool> visited = new Dictionary<Node, bool>();
            foreach (var node in Nodes)
            {
                visited.Add(node, false);
            }
            return visited;
        }
    }
}