using UnityEngine;
using SocialModule.Avatar;
using System.Collections.Generic;

public class PlayerAvatarData : MonoBehaviour
{
    public IAvatar baseAvatar;
    public IAvatar headAvatar;
    public IAvatar bottomAvatar;
    public IAvatar topAvatar;
	public List<HeadAvatar> ownedHeadAvatar;
	public List<TopAvatar> ownedTopAvatar;
	public List<BottomAvatar> ownedBottomAvatar;
	public List<IAvatar> ownedAvatar;

    void Awake()
    {
		ownedAvatar = new List<IAvatar>();
        GetAvatarData();
    }

    public void GetAvatarData()
    {
        /*
         * To-do:
         * Get avatar data from webservice
         */
		baseAvatar = new BaseAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Base/Base"), Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 0, "Base Avatar");
		headAvatar = new HeadAvatar(null, null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, "Empty Head Avatar");
		bottomAvatar = new BottomAvatar(null, null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 3, "Empty Bottom Avatar");
		topAvatar = new TopAvatar(null, null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 2, "Empty Top Avatar");
		ownedAvatar.Add(new BottomAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Bottom/Bottom"), Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 2, "Bottom Avatar"));
		ownedAvatar.Add(new HeadAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Head/Hair"), Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 1, "Hair Avatar"));
		ownedAvatar.Add(new TopAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Top/Top"), Resources.Load<Sprite>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder"), 3, "Top Avatar"));
    }
}
