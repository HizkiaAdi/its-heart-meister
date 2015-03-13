using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public class BaseAvatar : Avatars
    {
		public BaseAvatar(int ownershipID, string avatarName, GameObject sprite, GameObject editorSprite, Texture2D iconSprite, int gender, int isEquiped)
			: base(ownershipID, avatarName, sprite, editorSprite, iconSprite, gender, isEquiped, 0)
        {

        }
    }
}