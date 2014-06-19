using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    class dijkstra
    {
        GraphData graphData;
        GraphData graphData = GraphData.CreateGraphSingleton();
        

        foreach(Node i in GraphData)
        {
            Node.id=0;
            
        }




        //public int rank=0;
        //public int[,] L;
        //public int[] Dist;
        //public int[] C;
        //public int trank=0;

        //public dijkstra(int paramRank, int[,] paramArray)
        //{
        //    rank = paramRank;
        //    for (int i = 0; i < rank; i++)
        //    {
        //        for (int j = 0; j < rank; j++)
        //        {
        //            L[i, j] = paramArray[i, j];
        //        }
        //    }
        //    for (int i = 0; i < rank; i++)
        //    {
        //        C[i] = i;
        //    }
        //    C[0] = -1;
        //    for (int i = 0; i < rank; i++)
        //    {
        //        Dist[i] = L[0, i];
        //    }

        //}
        //public void DijkstraSolve()
        //{
        //    int minValue = int.MaxValue;
        //    int minNode = 0;
        //    for (int i = 0; i < rank; i++)
        //    {
        //        if (C[i] == -1)
        //            continue;
        //        if (Dist[i] > 0 && Dist[i] < minValue)
        //        {
        //            C[i] = Dist[i];
        //            minNode = i;
        //        }
        //    }
        //    C[minNode] = -1;
        //    for (int i = 0; i < rank; i++)
        //    {
        //        if (L[minNode, i] < 0)
        //            continue;
        //        if (Dist[i] < 0)
        //        {
        //            Dist[i] = minValue + L[minNode, i];
        //            continue;
        //        }
        //        if ((Dist[minNode] + L[minNode, i]) < Dist[i])
        //            Dist[i] = minValue + L[minNode, i];
        //    }
        //}
        //public void Run()
        //{
        //    for (trank = 1; trank > rank; trank++)
        //    {
        //        DijkstraSolve();
        //        Debug.Log("iteration" + trank);
        //        for (int i = 0; i < rank; i++)
        //            Debug.Log(Dist[i] + " ");
        //        Debug.Log("");
        //        for (int i = 0; i < rank; i++)
        //            Debug.Log(C[i] + " ");
        //        Debug.Log("");
        //    }
        //}        
    }
}