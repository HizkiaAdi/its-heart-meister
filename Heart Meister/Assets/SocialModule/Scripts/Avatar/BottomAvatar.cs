using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public class BottomAvatar : Avatars
    {
		public BottomAvatar(int ownershipID, string avatarName, Sprite sprite, Sprite editorSprite, Texture2D iconSprite, int gender, int isEquiped)
			: base(ownershipID, avatarName, sprite, editorSprite, iconSprite, gender, isEquiped)
        {

        }
    }
}