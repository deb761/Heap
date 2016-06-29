using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// Represent a Grid where the vertices are lists attached to their associated nodes
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Nodes in the grid.  The first array slot is empty so the node
        /// ids match their index
        /// </summary>
        public Node[] Nodes { get; protected set; }
        /// <summary>
        /// Number of nodes
        /// </summary>
        public int nNodes { get; protected set; }
        /// <summary>
        /// Number of edges
        /// </summary>
        public int nEdges { get; protected set; }
        /// <summary>
        /// Create the grid using input from a stream
        /// </summary>
        public Grid(StreamReader input)
        {
            string[] toks = input.ReadLine().Split();
            nNodes = int.Parse(toks[0]);
            nEdges = int.Parse(toks[1]);

            Nodes = new Node[nNodes + 1];

            for (int ndx = 1; ndx <= nNodes; ndx++)
            {
                Nodes[ndx] = new Node(ndx);
            }
            for (int edx = 0; edx < nEdges; edx++)
            {
                AddEdge(input);
            }
        }
        /// <summary>
        /// Add an undirected edge to the grid
        /// </summary>
        /// <param name="input"></param>
        private void AddEdge(StreamReader input)
        {
            string[] toks = input.ReadLine().Split();
            int n1 = int.Parse(toks[0]);
            int n2 = int.Parse(toks[1]);
            Node node1 = Nodes[n1];
            Node node2 = Nodes[n2];
            int weight = int.Parse(toks[2]);
            Edge edge = new Edge(node1, node2, weight);

            node1.Edges.Add(edge);
            node2.Edges.Add(edge);
        }
        /// <summary>
        /// Find the shortest distance between this node and all the others.
        /// </summary>
        /// <param name="nodeid">Start node</param>
        public void FindShortest(int nodeid)
        {
            Nodes[nodeid].Dist = 0;
            bool[] finished = new bool[Nodes.Length];
            MinHeap<Node> heap = new MinHeap<Node>(Nodes);

            while (heap.Count > 0)
            {
                Node node = heap.Pop();
                if (node.Dist == Node.NoConnection) break; // no more connected nodes
                finished[node.Id] = true;
                foreach (Edge edge in node.Edges)
                {
                    Node n2 = (edge.N1.Id == node.Id) ? edge.N2 : edge.N1;
                    if (finished[n2.Id]) continue;

                    int dist = node.Dist + edge.Weight;
                    if (dist < n2.Dist)
                        n2.Dist = dist;
                }
                heap.Heapify();
            }

            for (int idx = 1; idx <= nNodes; idx++)
            {
                Node node = Nodes[idx];
                if (idx != nodeid)
                {
                    Console.Write("{0} ", (node.Dist != Node.NoConnection) ? node.Dist : -1);
                }
            }
            Console.WriteLine();
        }
    }
}
