using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public class HeadAvatar : Avatars
    {
		public HeadAvatar(Sprite sprite, Sprite editorSprite, Sprite iconSprite, int id, string avatarName)
            : base(sprite, editorSprite, iconSprite, id, avatarName)
        {
           
        }
    }
}