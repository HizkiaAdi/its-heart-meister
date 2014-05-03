using UnityEngine;
using SocialModule.Avatar;

public class PlayerAvatarData : MonoBehaviour
{
    public BaseAvatar baseAvatar;
    public HeadAvatar headAvatar;
    public BottomAvatar bottomAvatar;
    public TopAvatar topAvatar;

    void Awake()
    {
        GetAvatarData();
    }

    public void GetAvatarData()
    {
        /*
         * To-do:
         * Get avatar datas from webservice
         */
		baseAvatar = new BaseAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Base/Base"), null, 0, "Base Avatar");
		headAvatar = new HeadAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Head/Hair"), null, 1, "Hair Avatar");
		bottomAvatar = new BottomAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Bottom/Bottom"), null, 2, "Bottom Avatar");
		topAvatar = new TopAvatar(null, Resources.Load<Sprite>("Textures/SocialModule/Avatar/Top/Top"), null, 3, "Top Avatar");
    }
}
