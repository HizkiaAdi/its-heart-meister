using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public class BaseAvatar : Avatars
    {
		public BaseAvatar(int ownershipID, string avatarName, Sprite sprite, Sprite editorSprite, Texture2D iconSprite, int gender, int isEquiped)
			: base(ownershipID, avatarName, sprite, editorSprite, iconSprite, gender, isEquiped)
        {

        }
    }
}