using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public abstract class Avatars
    {
		protected int ownershipId;
		protected string avatarName;
		protected Sprite sprite;
        protected Sprite editorSprite;
		protected Texture2D iconSprite;
		protected int gender;
		protected int isEquiped;

		public Avatars(int ownershipId, string avatarName, Sprite sprite, Sprite editorSprite, Texture2D iconSprite, int gender, int isEquiped)
        {
			this.sprite = sprite;
            this.editorSprite = editorSprite;
			this.iconSprite = iconSprite;
            this.ownershipId = ownershipId;
            this.avatarName = avatarName;
			this.gender = gender;
			this.isEquiped = isEquiped;
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
			return Sprite.Create(this.iconSprite, new Rect(0, 0, this.iconSprite.width, this.iconSprite.height), new Vector2(0.5f,0.5f));
		}

		public Texture2D GetIconTexture()
		{
			return this.iconSprite;
		}

        public int OwnershipID { get { return this.ownershipId; } }

        public string AvatarName { get { return this.avatarName; } }

		public int Gender { get { return this.gender; } }

        public int IsEquiped { get { return this.isEquiped; } set { this.isEquiped = value; } }
    }
}