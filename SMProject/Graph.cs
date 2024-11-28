using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMProject
{
    public class Graph
    {
        public List<Node> Nodes { get; private set; }
        public Dictionary<(Node, Node), double> Edges { get; private set; } // Edges with weights

        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new Dictionary<(Node, Node), double>();
        }

        // Add a node to the graph
        public void AddNode(int food)
        {
            Nodes.Add(new Node(food));
        }

        // Add an edge between two nodes with initial weight 0
        public void AddEdge(Node node1, Node node2)
        {
            if (!Edges.ContainsKey((node1, node2)) && !Edges.ContainsKey((node2, node1)))
            {
                Edges[(node1, node2)] = 0;
            }
        }

        // Update weight of an edge
        public void UpdateEdgeWeight(Node node1, Node node2, double weightIncrease)
        {
            var edge = (node1, node2);
            if (Edges.ContainsKey(edge))
            {
                Edges[edge] += weightIncrease;
            }
            else if (Edges.ContainsKey((node2, node1)))
            {
                edge = (node2, node1);
                Edges[edge] += weightIncrease;
            }
        }

        // Decay weights over time
        public void DecayWeights(double decayRate)
        {
            var keys = new List<(Node, Node)>(Edges.Keys);
            foreach (var edge in keys)
            {
                Edges[edge] = Math.Max(0, Edges[edge] - decayRate);
            }
        }

        // Get neighbors of a node
        public List<Node> GetNeighbors(Node node)
        {
            var neighbors = new List<Node>();
            foreach (var edge in Edges.Keys)
            {
                if (edge.Item1 == node)
                    neighbors.Add(edge.Item2);
                else if (edge.Item2 == node)
                    neighbors.Add(edge.Item1);
            }
            return neighbors;
        }
/*
        // Visualize the graph
        public override string ToString()
        {
            string graphInfo = "Graph:\n";
            foreach (var node in Nodes)
            {
                graphInfo += $"{node.Name} (Food: {node.Food})\n";
            }
            foreach (var edge in Edges)
            {
                graphInfo += $"{edge.Key.Item1.Name} <-> {edge.Key.Item2.Name}: Weight {edge.Value}\n";
            }
            return graphInfo;
        }
*/
    }

    public class Node
    {
        //public int Name { get; set; }
        public int Food { get; set; }
        public Boolean isHome { get; set; }
        public Point Position { get; set; }

        public Node(int food)
        {
            Food = food;
            isHome = false;
            Position = new Point(0, 0);
        }
    }
}
