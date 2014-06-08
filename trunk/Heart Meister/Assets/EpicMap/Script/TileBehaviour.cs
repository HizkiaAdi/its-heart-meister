using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DungeonGenerator
{
    public class TileBehaviour : MonoBehaviour
    {

        // Use this for initialization
        public int index;
        int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public List<GameObject> Destination;
        void Start()
        {
            Destination = new List<GameObject>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}