using UnityEngine;

[CreateAssetMenu]
public class Outfit : Item
{
	public enum eType { HAT, CLOTHES };
	public eType Type;

	public SpriteSheet SpriteSheet;
}
