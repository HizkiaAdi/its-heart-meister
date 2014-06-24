using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    public class mbohlahyo : MonoBehaviour
    {
        Node vertex, temp;
        // Use this for initialization
        void Start()
        {
            GraphData graphData = GraphData.CreateGraphSingleton();

            for (int i = 0; i < 5; i++)
            {
                vertex = new Node();
                vertex.Id = i;
                vertex.Weight = Random.Range(1, 10);
                graphData.Nodes.Add(vertex);
            }

            graphData.Nodes[0].Connection.Add(graphData.Nodes[1]);
            graphData.Nodes[0].Connection.Add(graphData.Nodes[2]);

            graphData.Nodes[1].Connection.Add(graphData.Nodes[3]);
            graphData.Nodes[2].Connection.Add(graphData.Nodes[4]);

            foreach (Node i in graphData.Nodes)
            {
                Debug.Log("Node: " + i.Id + ", Weight: " + i.Weight);
                foreach (Node j in i.Connection)
                {
                    Debug.Log("Connection: " + j.Id);
                }
            }
            dijkstra jikstra = new dijkstra(graphData.Nodes[0]);

            Debug.Log("-------abis dijkstra--------");
            foreach (Node i in graphData.Nodes)
            {
                if (i.Previous != null)
                    Debug.Log(i.Id + " is visited");
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}