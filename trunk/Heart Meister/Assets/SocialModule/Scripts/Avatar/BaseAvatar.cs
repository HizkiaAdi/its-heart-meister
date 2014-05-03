using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public class BaseAvatar : Avatar
    {
		public BaseAvatar(Sprite sprite, Sprite editorSprite, Sprite iconSprite, int id, string avatarName)
            : base(sprite, editorSprite, iconSprite, id, avatarName)
        {

        }
    }
}