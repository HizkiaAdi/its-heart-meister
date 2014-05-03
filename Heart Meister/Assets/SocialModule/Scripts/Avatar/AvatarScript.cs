using UnityEngine;
using System.Collections;
using SocialModule.Avatar;

public class AvatarScript : MonoBehaviour
{
    PlayerAvatarData avatarData;
	BaseAvatar baseAvatar;
	HeadAvatar headAvatar;
	TopAvatar topAvatar;
	BottomAvatar bottomAvatar;

    void Start () 
    {
        avatarData = GameObject.Find("DataContainer").GetComponent<PlayerAvatarData>();
		baseAvatar = avatarData.baseAvatar;
		headAvatar = avatarData.headAvatar;
		topAvatar = avatarData.topAvatar;
		bottomAvatar = avatarData.bottomAvatar;

		this.transform.FindChild("BaseAvatar").gameObject.GetComponent<SpriteRenderer>().sprite = baseAvatar.GetEditorSprite();
		this.transform.FindChild("HeadAvatar").gameObject.GetComponent<SpriteRenderer>().sprite = headAvatar.GetEditorSprite();
		this.transform.FindChild("TopAvatar").gameObject.GetComponent<SpriteRenderer>().sprite = topAvatar.GetEditorSprite();
		this.transform.FindChild("BottomAvatar").gameObject.GetComponent<SpriteRenderer>().sprite = bottomAvatar.GetEditorSprite();
	}
}
