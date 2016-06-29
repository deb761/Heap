using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// Represent a grid node
    /// </summary>
    public class Node : IComparable
    {
        /// <summary>
        /// Distance when a node is not connected
        /// </summary>
        public const int NoConnection = int.MaxValue;
        /// <summary>
        /// Edges for this node
        /// </summary>
        public List<Edge> Edges { get; set; }
        /// <summary>
        /// Node ID
        /// </summary>
        public int Id { get; protected set; }
        /// <summary>
        /// Distance from this node to the reference node
        /// </summary>
        public int Dist { get; set; }
        /// <summary>
        /// Create the node
        /// </summary>
        /// <param name="id">node id</param>
        public Node(int id)
        {
            Edges = new List<Edge>();
            Id = id;
            Dist = NoConnection;
        }
        /// <summary>
        /// Compare the node to another.  Used for sorting
        /// </summary>
        /// <param name="other">another node</param>
        /// <returns>-1 if the node has a shorter distance, 1 if the distance is greater</returns>
        public int CompareTo(object other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }
            Node node2 = other as Node;
            var result = Dist.CompareTo(node2.Dist);

            return result == 0 ? Id.CompareTo(node2.Id) : result;
        }
    }
    /// <summary>
    /// A Grid edge with a weight
    /// </summary>
    public class Edge
    {
        /// <summary>
        /// Starting node (if directional)
        /// </summary>
        public Node N1 { get; protected set; }
        /// <summary>
        /// Ending node (if directional)
        /// </summary>
        public Node N2 { get; protected set; }
        /// <summary>
        /// Edge weight
        /// </summary>
        public int Weight { get; protected set; }
        /// <summary>
        /// Construct the edge connecting 2 nodes with a weight
        /// </summary>
        /// <param name="n1">Node 1</param>
        /// <param name="n2">Node 2</param>
        /// <param name="weight">Weight</param>
        public Edge(Node n1, Node n2, int weight)
        {
            N1 = n1;
            N2 = n2;
            Weight = weight;
        }
    }
}
