using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public abstract class Avatar : IAvatar
    {
		protected Sprite sprite;
        protected Sprite editorSprite;
		protected Sprite iconSprite;
        protected int id;
        protected string avatarName;

        public Avatar(Sprite sprite, Sprite editorSprite, Sprite iconSprite, int id, string avatarName)
        {
			this.sprite = sprite;
            this.editorSprite = editorSprite;
			this.iconSprite = iconSprite;
            this.id = id;
            this.avatarName = avatarName;
        }

		public Sprite GetSprite()
		{
			return this.sprite;
		}

        public Sprite GetEditorSprite()
        {
            return this.editorSprite;
        }

		public Sprite GetIconSprite()
		{
			return this.iconSprite;
		}

        public int Id { get { return this.id; } }

        public string AvatarName { get { return this.avatarName; } }
    }
}