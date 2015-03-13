using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public class TopAvatar : Avatars
    {
        public TopAvatar(int ownershipID, string avatarName, GameObject sprite, GameObject editorSprite, Texture2D iconSprite, int gender, int isEquiped, int inAuction)
			: base(ownershipID, avatarName, sprite, editorSprite, iconSprite, gender, isEquiped, inAuction)
        {

        }
    }
}