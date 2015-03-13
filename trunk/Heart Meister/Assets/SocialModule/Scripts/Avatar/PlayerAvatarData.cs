using UnityEngine;
using SocialModule.Avatar;
using System.Collections.Generic;

public class PlayerAvatarData : MonoBehaviour
{
    public Avatars baseAvatar;
    public Avatars headAvatar;
    public Avatars bottomAvatar;
    public Avatars topAvatar;
	public List<Avatars> ownedHeadAvatar;
	public List<Avatars> ownedTopAvatar;
	public List<Avatars> ownedBottomAvatar;
	public List<Avatars> ownedAvatar;
    public int[] equipedIndex;

    void Awake()
    {
		ownedAvatar = new List<Avatars>();
		ownedHeadAvatar = new List<Avatars>();
		ownedTopAvatar = new List<Avatars>();
		ownedBottomAvatar = new List<Avatars>();
        GetAvatarData();
    }

    public void GetAvatarData()
    {
        /*
         * To-do:
         * Get avatar data from webservice
         
        baseAvatar = new BaseAvatar(0, "Base Avatar", null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Base/Base"), Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        headAvatar = new HeadAvatar(1, "Empty Head Avatar", null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        bottomAvatar = new BottomAvatar(3, "Empty Bottom Avatar", null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        topAvatar = new TopAvatar(2, "Empty Top Avatar", null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        BottomAvatar bottom = new BottomAvatar(2, "Bottom Avatar", null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Bottom/Bottom"), Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        ownedAvatar.Add(bottom);
        ownedBottomAvatar.Add(new BottomAvatar(-1, "Empty", null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"),-1,0));
        ownedBottomAvatar.Add(bottom);
        HeadAvatar head = new HeadAvatar(1, "Hair Avatar", null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Head/Hair"), Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        ownedAvatar.Add(head);
        ownedHeadAvatar.Add(new HeadAvatar(-1, "Empty", null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"),-1,0));
        ownedHeadAvatar.Add(head);
        TopAvatar top = new TopAvatar(3, "Top Avatar", null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Top/Top"), Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, 1);
        ownedAvatar.Add(top);
        ownedTopAvatar.Add(new TopAvatar(-1, "Empty", null, null, Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"),-1,0));
        ownedTopAvatar.Add(top);

        equipedIndex = new int[] {0, 0, 0};*/
    }
}
