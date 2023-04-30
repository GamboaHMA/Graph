using Grafos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

Node n_1 = new Node(1);
Node n_2 = new Node(2);
Node n_3 = new Node(3);
Node n_4 = new Node(4);
Node n_5 = new Node(5);
Node n_6 = new Node(6);
Node n_7 = new Node(7);
Node n_8 = new Node(8);

n_1.AdyacentNodes.Add(n_2);
n_1.AdyacentNodes.Add(n_3);
n_1.AdyacentNodes.Add(n_4);

n_2.AdyacentNodes.Add(n_1);
n_2.AdyacentNodes.Add(n_5);

n_3.AdyacentNodes.Add(n_1);
n_3.AdyacentNodes.Add(n_6);
n_3.AdyacentNodes.Add(n_7);

n_4.AdyacentNodes.Add(n_7);
n_4.AdyacentNodes.Add(n_1);

n_5.AdyacentNodes.Add(n_2);
n_5.AdyacentNodes.Add(n_6);

n_6.AdyacentNodes.Add(n_3);
n_6.AdyacentNodes.Add(n_5);
n_6.AdyacentNodes.Add(n_8);

n_7.AdyacentNodes.Add(n_3);
n_7.AdyacentNodes.Add(n_4);
n_7.AdyacentNodes.Add(n_8);

n_8.AdyacentNodes.Add(n_6);
n_8.AdyacentNodes.Add(n_7);

List<Node> Nodes = new List<Node> { n_1, n_2, n_3, n_4, n_5, n_6, n_7, n_8 };
Grafo grafo = new Grafo(Nodes, new List<Edge>());
Dictionary<Node, int> dict = new Dictionary<Node, int>();
Queue<Node> queue = new Queue<Node>();
queue.Enqueue(n_1);

Dictionary<Node, int> bfs = grafo.Simple_BFS(n_1, grafo.InicializarDict(n_1), queue);

queue.Enqueue(n_1);

Dictionary<Node, Node> pi = grafo.Simple_BFS_Pi(n_1, grafo.InicializarDict(n_1), queue, grafo.InicializarPi());

Dictionary<Node, int> compConex = grafo.Simple_DFS(grafo.InicializarDict(), grafo.InicializarVisited(), grafo.InicializarPi());

List<List<int>> list = new List<List<int>>() { new List<int>() { 1, 2 },
                                               new List<int>() { 7, 2 },
                                               new List<int>() { 3, 5 },
                                               new List<int>() { 3, 4 },
                                               new List<int>() { 4, 5 } };
int numberOfGoodComponents = ComponenteComplConexaEjercicio.CompCompletConexDFS(7, list);

DetectCycleExcercise test = new DetectCycleExcercise();

List<List<int>> adj = new List<List<int>> { new List<int>() { 1 },
                                            new List<int>() { 0, 2, 4},
                                            new List<int>() { 1, 3, 4},
                                            new List<int>() { 2, 4},
                                            new List<int>() { 1,3, 2} };

int result = test.DetectCycle(5, adj);
Console.WriteLine(result);

List<(int, int)> edges = new List<(int, int)>() { (1, 2),
                                                  (1, 3),
                                                  (1, 4),
                                                  (1, 5),
                                                  (2, 4),
                                                  (2, 5),
                                                  (4, 5),
                                                  (3, 6),
                                                  (3, 7),
                                                  (6, 7)};

PtosArticulacion ptos_art = new PtosArticulacion();
List<int> result_PtosArticulacion = ptos_art.Ptos_Art(7, edges);
foreach (var node in result_PtosArticulacion)
{
    Console.WriteLine(node);
}