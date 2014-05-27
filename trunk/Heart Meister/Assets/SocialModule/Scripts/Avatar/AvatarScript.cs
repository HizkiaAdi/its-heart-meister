using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
	public class AvatarScript : MonoBehaviour
	{
		PlayerAvatarData avatarData;
		Avatars baseAvatar;
		Avatars headAvatar;
		Avatars topAvatar;
		Avatars bottomAvatar;
		SpriteRenderer baseSprite;
		SpriteRenderer headSprite;
		SpriteRenderer topSprite;
		SpriteRenderer bottomSprite;
		
		void Awake () 
		{
			
		}
		
		void Start()
		{
			avatarData = GameObject.Find("DataContainer").GetComponent<PlayerAvatarData>();
			baseAvatar = avatarData.baseAvatar;
			headAvatar = avatarData.headAvatar;
			topAvatar = avatarData.topAvatar;
			bottomAvatar = avatarData.bottomAvatar;

			baseSprite = this.transform.FindChild("BaseAvatar").gameObject.GetComponent<SpriteRenderer>();
			headSprite = this.transform.FindChild("HeadAvatar").gameObject.GetComponent<SpriteRenderer>();
			topSprite = this.transform.FindChild("TopAvatar").gameObject.GetComponent<SpriteRenderer>();
			bottomSprite = this.transform.FindChild("BottomAvatar").gameObject.GetComponent<SpriteRenderer>();

			baseSprite.sprite = baseAvatar.GetEditorSprite();
			headSprite.sprite = headAvatar.GetEditorSprite();
			topSprite.sprite = topAvatar.GetEditorSprite();
			bottomSprite.sprite = bottomAvatar.GetEditorSprite();
		}

		public void setHeadSprite(Sprite sprite)
		{
			this.headSprite.sprite = sprite;
		}

		public void setTopSprite(Sprite sprite)
		{
			this.topSprite.sprite = sprite;
		}

		public void setBottomSprite(Sprite sprite)
		{
			this.bottomSprite.sprite = sprite;
		}
	}

}	