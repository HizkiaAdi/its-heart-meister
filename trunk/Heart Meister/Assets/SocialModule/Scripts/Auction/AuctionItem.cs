using UnityEngine;

public class AuctionItem
{
	public int AuctionId { get; set;}
	public int LowestBid { get; set;}
	public int Status { get; set;}
	public string PlayerName { get;set;}
	public string Gender { get; set;}
	public string AvatarName { get; set;}
	public System.DateTime ExpireTime { get; set;}
	public Texture2D AvatarIcon { get; set;}

	public AuctionItem(int auctionId, int lowestBid, string playerName, string avatarName, int gender, Texture2D texture, string expireTime, int status)
	{
		this.AuctionId = auctionId;
		this.LowestBid = lowestBid;
		this.PlayerName = playerName;
		this.AvatarName = avatarName;
		this.Gender = (gender == 0 ) ? "Male" : "Female";
		this.AvatarIcon = (texture != null) ? texture : Resources.Load<Texture2D>("Textures/SocialModule/Avatar/Icon/AvatarPlaceholder");
		this.Status = status;
		ExpireTime = System.Convert.ToDateTime(expireTime);
	}
}
