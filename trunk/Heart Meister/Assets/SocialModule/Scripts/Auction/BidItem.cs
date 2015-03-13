using UnityEngine;
using System.Collections;

public class BidItem
{
	public string AvatarOwner { get; set;}
	public int BidId { get; set;}
	public int BidAmmount { get; set;}
	public string Gender { get; set;}
	public string AvatarName { get; set;}
	public Texture2D AvatarIcon { get; set;}
	public int Status { get; set;}
    public System.DateTime ExpireTime { get; set; }

	public BidItem(int bidId, string avatarOwner, int bidAmmount, int gender, string avatarName, Texture2D texture, int status, string expireTime)
	{
		this.BidId = bidId;
		this.AvatarOwner = avatarOwner;
        this.BidAmmount = bidAmmount;
		this.Gender = (gender == 1 ) ? "Male" : "Female";
		this.AvatarName = avatarName;
		this.AvatarIcon = (texture != null) ? texture : Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder");
		this.Status = status;
        ExpireTime = System.Convert.ToDateTime(expireTime);
	}
}
