using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<Item> Items;

    public Outfit Hat;
    public Outfit Clothes;
	[SerializeField] SpriteSynchronizer playerSpriteSynchronizer;

	private void Awake()
	{
		Instance = this;
	}

	public void AddItem(Item item)
	{ 
		if(!Items.Contains(item))
			Items.Add(item); 
	}

	public void EquipOutfit(Outfit outfit)
	{
		switch (outfit.Type)
		{
			case Outfit.eType.HAT: 
				Hat = outfit;
				playerSpriteSynchronizer.hatSheet = outfit.SpriteSheet;
				break;
			case Outfit.eType.CLOTHES:
				Clothes = outfit;
				playerSpriteSynchronizer.clothesSheet = outfit.SpriteSheet;
				break;
		}
	}

	public bool IsHeld(Item item) 
	{
		return Items.Contains(item); 
	}
	public bool IsEquipped(Outfit outfit)
	{
		switch (outfit.Type)
		{
			case Outfit.eType.HAT:		return Hat == outfit;
			case Outfit.eType.CLOTHES:	return Clothes == outfit;
		}
		return false;
	}
}
