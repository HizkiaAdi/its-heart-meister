using UnityEngine;
using System.Collections;

namespace SocialModule.Avatar
{
    public abstract class Avatars
    {
        protected int avatarId;
		protected int ownershipId;
		protected string avatarName;
		protected GameObject sprite;
        protected GameObject editorSprite;
		protected Texture2D iconSprite;
		protected int gender;
		protected int isEquiped;
        protected int inAuction;

		public Avatars(int ownershipId, string avatarName, GameObject sprite, GameObject editorSprite, Texture2D iconSprite, int gender, int isEquiped, int inAuction)
        {
			this.sprite = sprite;
            this.editorSprite = editorSprite;
			this.iconSprite = iconSprite;
            this.ownershipId = ownershipId;
            this.avatarName = avatarName;
			this.gender = gender;
			this.isEquiped = isEquiped;
            this.inAuction = inAuction;
        }

		public GameObject GetSprite()
		{
			return this.sprite;
		}

        public GameObject GetEditorSprite()
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

        public int AvatarID { get { return this.avatarId; } }

        public int OwnershipID { get { return this.ownershipId; } }

        public string AvatarName { get { return this.avatarName; } }

		public int Gender { get { return this.gender; } }

        public int IsEquiped { get { return this.isEquiped; } set { this.isEquiped = value; } }

        public int InAuction { get { return this.inAuction; } set { this.inAuction = value; } }
    }
}