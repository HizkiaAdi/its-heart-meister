using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonTraversing : MonoBehaviour
{
    public GUITexture dgPlayer;
    public GUITexture start;
    public GUITexture a;
    public GUITexture b;
    public GUITexture c;
    public GUITexture d;
    public GUITexture boss;
    public List<GUITexture> nodes = new List<GUITexture>();
    private int playerPos;
    private int targetIndex;
    private float startTime;
    private int branch = 0;
    public Vector3 speed;
    private Vector3 startPos;
    private Vector3 tempPos;
    //Sementara
    private Vector3 nextPosA;
    private Vector3 nextPosB;
    private Vector3 nextPosC;
    private Vector3 nextPosD;
    private Vector3 nextPosBoss;
    private Vector3 target;
    //Mengambil posisi player, apakah baru mulai atau di tengah jalan
    private Vector3 currPos;
    public bool justStart = true;

    public GameObject playtest;
    private Vector3 testpos;

    // Use this for initialization
    void Start()
    {
        if (justStart)
        {
            nodes.Add(start);
            nodes.Add(a);
            nodes.Add(b);
            nodes.Add(c);
            nodes.Add(d);
            nodes.Add(boss);

            //Posisi Node sementara
            nextPosA = a.transform.position;
            nextPosB = b.transform.position;
            nextPosC = c.transform.position;
            nextPosD = d.transform.position;
            nextPosBoss = boss.transform.position;
            //Memindahkan sprite player ke start sprite
            startPos = start.transform.position;
            startPos.z = 2.0f;
            dgPlayer.transform.position = startPos;
            currPos = startPos;
            playerPos = 0;

            speed.x = 0.1f;
            speed.y = 0.1f;
            speed.z = 0f;
            branch = 2;
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
        if (Input.GetMouseButtonDown(0))
        {
            if (playerPos == 0)
            {
                targetIndex = 1;
                target = nodes[targetIndex].transform.position;
                playerPos = targetIndex;
            }
            else if (playerPos == 1)
            {
                int rand = Random.Range(0, branch);
                Debug.Log("rand = " + rand);
                switch (rand)
                {
                    case 0:
                        targetIndex = 2;
                        target = nodes[targetIndex].transform.position;
                        playerPos = targetIndex;
                        break;
                    case 1:
                        targetIndex = 4;
                        target = nodes[targetIndex].transform.position;
                        playerPos = targetIndex;
                        break;
                    default:
                        targetIndex = 4;
                        target = nodes[targetIndex].transform.position;
                        playerPos = targetIndex;
                        break;
                }
            }
            else if (playerPos == 2)
            {
                targetIndex = 3;
                target = nodes[targetIndex].transform.position;
                playerPos = targetIndex;
            }
            else if (playerPos == 3)
            {
                targetIndex = 0;
                target = nodes[targetIndex].transform.position;
                playerPos = targetIndex;
            }
            else if (playerPos == 4)
            {
                targetIndex = 5;
                target = nodes[targetIndex].transform.position;
                playerPos = targetIndex;
            }
            else if (playerPos == 5)
            {
                Application.LoadLevel("Dungeon-HootunForestBATTLE");
                targetIndex = 0;
                target = nodes[targetIndex].transform.position;
                playerPos = targetIndex;
            }
        }
        Move();
    }

    public void Move()
    {
        currPos = dgPlayer.transform.position;
        tempPos = currPos;
        if (target.x > 0)
        {
            dgPlayer.transform.position = new Vector3(target.x, dgPlayer.transform.position.y, dgPlayer.transform.position.z);
        }
        if (target.y > 0)
        {
            dgPlayer.transform.position = new Vector3(dgPlayer.transform.position.x, target.y, dgPlayer.transform.position.z);
        }
    }
}
