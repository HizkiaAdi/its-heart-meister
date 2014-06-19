using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    public class Node
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        List<Node> connection;

        public List<Node> Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        int distance;

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        Node previous;

        public Node Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Node()
        {
            connection = new List<Node>();
        }
    }
}
