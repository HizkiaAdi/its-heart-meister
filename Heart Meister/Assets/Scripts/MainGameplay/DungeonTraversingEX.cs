using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace MainGameplay
{
    public class DungeonTraversingEX : MonoBehaviour
    {
        public int nodeCount;
        public List<Node> dungeonNodes = new List<Node>();
        public GameObject StartNode;
        public GameObject IdleNode;
        public GameObject BattleNode;
        public GameObject BossNode;
        public GameObject EventNode;
        public GameObject MysteryNode;
        public GameObject Player;
        private Vector3 startPos = new Vector3();

        public GameObject playerSpawner;

        private Vector3 playerLoc;
        private Vector3 targetPos;
        private int targetNode;
        public float speed;
        public static bool collideFlag = false;
        private int playerPos;

        public GUITexture dgPlayer;
        public GUITexture start;
        public GUITexture a;
        public GUITexture b;
        public GUITexture c;
        public GUITexture d;
        public GUITexture boss;
        public List<GUITexture> nodes = new List<GUITexture>();
        private int targetIndex;
        private float startTime;
        private Vector3 tempPos;
        //Sementara
        //Mengambil posisi player, apakah baru mulai atau di tengah jalan
        private Vector3 currPos;
        public bool justStart = true;

        // Use this for initialization
        void Start()
        {
            dungeonDataInsertion();
            dungeonNodePlacing();
            if (justStart)
            {
                playerPos = 0; //memberi tanda bahwa posisi player berada di start node ber ID 0
                dungeonPositionStart();

                nodes.Add(start);
                nodes.Add(a);
                nodes.Add(b);
                nodes.Add(c);
                nodes.Add(d);
                nodes.Add(boss);

               //Memindahkan sprite player ke start sprite

                //startPos = start.transform.position;
                //startPos.z = 2.0f;
                //dgPlayer.transform.position = startPos;
                //currPos = startPos;
                //playerPos = 0;

                speed = 0.05f;
            }
            else
            {
                //Mengembalikan sprite player ke lokasi sebelumnya
                dgPlayer.transform.position = currPos;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("playerSpawner = " + playerSpawner.transform.position);
            //playerLoc = Camera.main.ViewportToWorldPoint(playerSpawner.transform.position);
            playerLoc = playerSpawner.transform.position;
            Move(speed);
        }

        public void Move(float moveSpd)
        {
            Debug.Log("playerPos = " + playerPos);
            //Debug.Log("collideFlag = " + collideFlag);
            if (!collideFlag)
            {
                //Debug.Log("RACING");
                //Debug.Log("playerLoc X = " + playerLoc.x);
                //Debug.Log("playerLoc Y = " + playerLoc.y);
                //Debug.Log("target X = " + targetPos.x);
                //Debug.Log("target Y = " + targetPos.x);
                //GameObject nodeSpawner = (GameObject)Instantiate(MysteryNode, targetPos, Quaternion.identity);
                //Vector3 tempe = nodeSpawner.transform.position;
                //tempe.z = 0f;
                //nodeSpawner.transform.position = tempe;
                if (playerLoc.x < targetPos.x)
                {
                    playerSpawner.transform.Translate(Vector3.right * moveSpd);
                }
                if (playerLoc.y < targetPos.y)
                {
                    playerSpawner.transform.Translate(Vector3.up * moveSpd);
                }
                if (playerLoc.x > targetPos.x)
                {
                    playerSpawner.transform.Translate(Vector3.right * -moveSpd);
                }
                if (playerLoc.y > targetPos.y)
                {
                    playerSpawner.transform.Translate(Vector3.up * -moveSpd);
                }
            }
            else
            {
                //NodeEventHandler();
                if (dungeonNodes[playerPos].nodeChild.Count > 1)
                {
                    int rand = Random.Range(0, dungeonNodes[playerPos].nodeChild.Count);
                    targetNode = dungeonNodes[playerPos].nodeChild[rand];
                    var preNodePos = new Vector3(dungeonNodes[targetNode].nodeLocX, dungeonNodes[targetNode].nodeLocY, 0.25f);
                    targetPos = Camera.main.ViewportToWorldPoint(preNodePos);
                    playerPos = dungeonNodes[playerPos].nodeChild[rand];
                }
                else
                {
                    var preNodePos = new Vector3(dungeonNodes[dungeonNodes[playerPos].nodeChild[0]].nodeLocX, dungeonNodes[dungeonNodes[playerPos].nodeChild[0]].nodeLocY, 0.25f);
                    targetPos = Camera.main.ViewportToWorldPoint(preNodePos);
                    playerPos = dungeonNodes[playerPos].nodeChild[0];
                }
                collideFlag = false;
            }
        }

        public void dungeonDataInsertion()
        {
            //Should have the webservice up. For now using dummy data
            dungeonNodes.Add(new Node("START", 1, 0.1f, 0.5f, 0, new List<int> { 1 }));
            dungeonNodes.Add(new Node("A", 2, 0.35f, 0.5f, 1, new List<int> { 2, 4 }));
            dungeonNodes.Add(new Node("B", 2, 0.65f, 0.25f, 2, new List<int> { 3 }));
            dungeonNodes.Add(new Node("C", 2, 0.9f, 0.25f, 3, new List<int> { 0 }));
            dungeonNodes.Add(new Node("D", 2, 0.65f, 0.75f, 4, new List<int> { 5 }));
            dungeonNodes.Add(new Node("BOSS", 4, 0.9f, 0.75f, 5, new List<int> { 0 }));
            dungeonNodes = dungeonNodes.OrderBy(o => o.nodeID).ToList();
        }

        public void dungeonNodePlacing()
        {
            //places node sprites on their coordinates
            foreach (Node n in dungeonNodes)
            {
                var preNodePos = new Vector3(n.nodeLocX, n.nodeLocY, 0.25f);
                var nodePos = Camera.main.ViewportToWorldPoint(preNodePos);
                if (n.nodeType == 1)
                {
                    GameObject nodeSpawner = (GameObject)Instantiate(StartNode, nodePos, Quaternion.identity);
                    Vector3 tempe = nodeSpawner.transform.position;
                    //Debug.Log("Start Node = " + tempe);
                    tempe.z = 0f;
                    nodeSpawner.transform.position = tempe;
                    startPos = tempe;
                }
                else if (n.nodeType == 2)
                {
                    GameObject nodeSpawner = (GameObject)Instantiate(IdleNode, nodePos, Quaternion.identity);
                    Vector3 tempe = nodeSpawner.transform.position;
                    tempe.z = 0f;
                    nodeSpawner.transform.position = tempe;
                }
                else if (n.nodeType == 3)
                {
                    GameObject nodeSpawner = (GameObject)Instantiate(BattleNode, nodePos, Quaternion.identity);
                    Vector3 tempe = nodeSpawner.transform.position;
                    tempe.z = 0f;
                    nodeSpawner.transform.position = tempe;
                }
                else if (n.nodeType == 4)
                {
                    GameObject nodeSpawner = (GameObject)Instantiate(BossNode, nodePos, Quaternion.identity);
                    Vector3 tempe = nodeSpawner.transform.position;
                    tempe.z = 0f;
                    nodeSpawner.transform.position = tempe;
                }
                else if (n.nodeType == 5)
                {
                    GameObject nodeSpawner = (GameObject)Instantiate(IdleNode, nodePos, Quaternion.identity);
                    Vector3 tempe = nodeSpawner.transform.position;
                    tempe.z = 0f;
                    nodeSpawner.transform.position = tempe;
                }
                else
                {
                    GameObject nodeSpawner = (GameObject)Instantiate(MysteryNode, nodePos, Quaternion.identity);
                    Vector3 tempe = nodeSpawner.transform.position;
                    tempe.z = 0f;
                    nodeSpawner.transform.position = tempe;
                }
            }
        }

        public void dungeonPositionStart()
        {
            //starts the player's on the start node
            playerSpawner = (GameObject)Instantiate(Player, startPos, Quaternion.identity);
            Vector3 tempe = playerSpawner.transform.position;
            playerLoc = Camera.main.ViewportToWorldPoint(playerSpawner.transform.position);
            tempe.z = 0f;
            playerSpawner.transform.position = tempe;

            //prepares the player to move to the next node
            if (dungeonNodes[playerPos].nodeChild.Count > 1)
            {
                int rand = Random.Range(0, dungeonNodes[playerPos].nodeChild.Count);
                targetNode = dungeonNodes[playerPos].nodeChild[rand];
                var preNodePos = new Vector3(dungeonNodes[targetNode].nodeLocX, dungeonNodes[targetNode].nodeLocY, 0.25f);
                targetPos = Camera.main.ViewportToWorldPoint(preNodePos);
                playerPos = dungeonNodes[playerPos].nodeChild[rand];
            }
            else
            {
                var preNodePos = new Vector3(dungeonNodes[dungeonNodes[playerPos].nodeChild[0]].nodeLocX, dungeonNodes[dungeonNodes[playerPos].nodeChild[0]].nodeLocY, 0.25f);
                targetPos = Camera.main.ViewportToWorldPoint(preNodePos);
                playerPos = 0;
            }
        }

        public void NodeEventHandler()
        {
            if (dungeonNodes[targetNode].nodeType == 2) //if idle node
            {
                Time.timeScale = 0f;
                Debug.Log("There's nothing here...");
                Time.timeScale = 1.0f;
            }
            else if (dungeonNodes[targetNode].nodeType == 3) //if battle node
            {
                Time.timeScale = 0f;
                //Call battle scene
                Time.timeScale = 1.0f;
            }
            else if (dungeonNodes[targetNode].nodeType == 4) //if boss node
            {
                Time.timeScale = 0f;
                Application.LoadLevel("LoadScreen");// me load loadscreen yang untuk sementara masuk ke node battle coba2
                Time.timeScale = 1.0f;
            }
            else if (dungeonNodes[targetNode].nodeType == 5) //if event node
            {
                Time.timeScale = 0f;
                //Call event scene
                Time.timeScale = 1.0f;
            }
        }
    }
}
