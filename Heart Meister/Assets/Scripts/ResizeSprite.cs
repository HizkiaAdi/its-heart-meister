﻿using UnityEngine;
using System.Collections;

public class ResizeSprite : MonoBehaviour
{
	void Start () 
	{
		ResizeSpriteToScreen();
	}

	void ResizeSpriteToScreen()
	{
		SpriteRenderer sr = this.gameObject.GetComponent<SpriteRenderer>();
		if (sr == null)
			return;

		transform.localScale = new Vector3(1, 1, 1);

		float width = sr.sprite.bounds.size.x;
		float height = sr.sprite.bounds.size.y;

		float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
	}
}
