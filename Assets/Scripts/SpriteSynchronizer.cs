using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteSynchronizer : MonoBehaviour
{
	public SpriteSheet bodySheet;
	public SpriteSheet clothesSheet;
	public SpriteSheet hatSheet;

	[SerializeField] SpriteRenderer body;
	[SerializeField] SpriteRenderer clothes;
	[SerializeField] SpriteRenderer hat;
	[SerializeField] int x, y;

	void Update()
	{
		if(bodySheet) body.sprite = bodySheet.GetSprite(x, y);
		if(clothesSheet) clothes.sprite = clothesSheet.GetSprite(x, y);
		if(hatSheet) hat.sprite = hatSheet.GetSprite(x, y);
		
		clothes.enabled = clothesSheet != null;
		hat.enabled = hatSheet != null;
	}

}
