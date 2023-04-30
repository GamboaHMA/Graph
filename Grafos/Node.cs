using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafos
{
    public class Node
    {
        public Node Parent { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public List<Node> AdyacentNodes { get; set; }

        public Node(int value)
        {
            Value = value;
            AdyacentNodes = new List<Node>();
            Color = "White";
        }

        public Node(int value, Node parent)
        {
            this.Value = value;
            this.Parent = parent;
        }

        public Node(int value, Node[] nodes)
        {
            Value = value;
            AdyacentNodes = new List<Node>();
            foreach (var node in nodes)
            {
                AdyacentNodes.Add(node);
            }
        }

        public void Add(Node node)
        {
            AdyacentNodes.Add(node);
        }
    }
}
