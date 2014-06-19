using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace DungeonGenerator
{
    public class GraphData
    {
        private static GraphData singleton;

        public static GraphData CreateGraphSingleton()
        {
            if (singleton == null)
            {
                singleton = new GraphData();
            }
            return singleton;
        }

        List<Node> nodes;
        
        public List<Node> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }

        public GraphData()
        {
            nodes = new List<Node>();
        }
    }
}