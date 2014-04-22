using UnityEngine;
using System.Collections;

namespace SocialModule
{
	public class PlayerController : MonoBehaviour
	{
		float widthUnit;
		float heightUnit;
		Rect leftControl;
		Rect rightControl;
		
		public Vector2 speed;
		Vector2 velocity;
		
		void Start ()
		{
			widthUnit = Screen.width * 0.01f;
			heightUnit = Screen.height * 0.01f;
			leftControl = new Rect(0, 0, 10 * widthUnit, 100 * heightUnit);
			rightControl = new Rect(90 * widthUnit, 0, 10 * widthUnit, 100 * heightUnit);
		}
		
		void Update ()
		{
			velocity = rigidbody2D.velocity;
			#if UNITY_EDITOR
			if(Input.GetAxis("Horizontal") > 0)
				velocity.x = speed.x;
			else if(Input.GetAxis("Horizontal") < 0)
				velocity.x = -speed.x;
			#elif UNITY_ANDROID
			if(Input.touchCount > 0)
			{
				if(rightControl.Contains(Input.GetTouch(0).position))
					velocity.x = speed.x;
				else if(leftControl.Contains(Input.GetTouch(0).position))
					velocity.x = -speed.x;
			}
			#endif
		}
		
		void FixedUpdate()
		{
			rigidbody2D.velocity = velocity;
		}
	}
}