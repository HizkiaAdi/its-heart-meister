using UnityEngine;

namespace SocialModule.Avatar
{
    public interface IAvatar
    {
		Sprite GetSprite();
        Sprite GetEditorSprite();
		Sprite GetIconSprite();
    }
}