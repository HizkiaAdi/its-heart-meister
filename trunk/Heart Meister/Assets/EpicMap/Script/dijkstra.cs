using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    class dijkstra
    {
        GraphData graphData = GraphData.CreateGraphSingleton();
        //PrioQueue pqueue;

        public dijkstra(Node source)
        {
        //    pqueue = new PrioQueue();
        //    foreach (Node i in graphData.Nodes)
        //    {
        //        if (i != source)
        //        {
        //            i.Distance = 5000;
        //            i.Previous = null;                    
        //        }
        //        pqueue.Enqueue(i, i.Weight);
        //    }
        //    Debug.Log("size que: " + pqueue.total_size);
        //        while (pqueue.total_size!=0) 
        //        {
        //            Node u;
        //            u = pqueue.Dequeue() as Node;
        //            foreach(Node v in u.Connection)
        //            {
        //                int temp;
        //                temp = u.Distance + v.Weight;
        //                if (temp < v.Distance) 
        //                {
        //                    v.Distance = temp;
        //                    v.Previous = u;
        //                    if (pqueue.total_size > 0)
        //                        pqueue.Dequeue();
        //                }
        //            }
        //          }            
        }         
    }
}