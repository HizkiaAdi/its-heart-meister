using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    public class Node
    {
        Vector2 index;
        int stat;

        public int Stat
        {
            get { return stat; }
            set { stat = value; }
        }
        List<Node> destination;

        public List<Node> Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public Vector2 Index
        {
            get { return index; }
            set { index = value; }
        }

    }
}
