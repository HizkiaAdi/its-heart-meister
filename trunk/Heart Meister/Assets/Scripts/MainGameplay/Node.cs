using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace MainGameplay
{
    public class Node
    {
        public string nodeName;
        public int nodeType;
        public float nodeLocX;
        public float nodeLocY;
        public int nodeID;
        public List<int> nodeChild;
        //type = 0 is not a passable node, 1 is start node, 2 is idle node, 3 is battle node, 4 is boss node, 5 is event node

        public Node(string name, int type, float locX, float locY, int id, List<int> child)
        {
            this.nodeName = name;
            this.nodeType = type;
            this.nodeLocX = locX;
            this.nodeLocY = locY;
            this.nodeID = id;
            this.nodeChild = child;
        }
    }
}
