using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class HealthGround : MonoBehaviour
    {

        public float speed;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.right * speed);
            if (transform.localPosition.x < -11f || transform.localPosition.y < -8f)
            {
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(this.gameObject.tag=="FragileGround" && collision.gameObject.tag=="Player")
            {
                Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
                player.AddForce(new Vector2(1000, player.transform.localPosition.y) * 0.2f);
            }
        }
    }
}