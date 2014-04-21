using UnityEngine;

namespace SocialModule
{
	public class PlayerMovement : MonoBehaviour
	{
		public Vector2 speed = new Vector2(5, 5);
		private Vector2 velocity = Vector2.zero;
		private Rect leftControl;
		private Rect rightControl;
		
		void Start ()
		{
			leftControl = new Rect(0, 0, 100, Screen.height * 0.8f);
			rightControl = new Rect(Screen.width - 100, 0, 100, Screen.height * 0.8f);
		}
		
		void Update ()
		{
			velocity = rigidbody2D.velocity;
			#if UNITY_EDITOR
			velocity.x = Input.GetAxis("Horizontal") * speed.x;
			/*if(Input.GetAxis("Vertical") > 0)
			velocity.y = Input.GetAxis("Vertical") * speed.y;*/
			#elif UNITY_ANDROID
			if(Input.touchCount > 0 && leftControl.Contains(Input.GetTouch(0).position))
				velocity.x = -(speed.x);
			else if(Input.touchCount > 0 && rightControl.Contains(Input.GetTouch(0).position))
				velocity.x = speed.x;
			#endif
			
		}
		
		void FixedUpdate()
		{
			rigidbody2D.velocity = velocity;
		}
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject == GameObject.Find("GroundPrefab"))
			{
				rigidbody2D.gravityScale = 0;
				rigidbody2D.velocity = Vector2.zero;
				transform.position = new Vector2(transform.position.x, other.transform.position.y + (other.transform.lossyScale.y * 0.5f));
			}
			else if(other.gameObject == GameObject.Find("TheWall"))
			{
				Debug.Log("CUK");
				rigidbody2D.velocity = Vector2.zero;
			}
		}
	}

}