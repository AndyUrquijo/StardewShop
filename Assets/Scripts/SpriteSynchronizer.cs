using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteSynchronizer : MonoBehaviour
{
    [SerializeField] int x, y;
    int prevX, prevY;

    [SerializeField] SpriteRenderer body;
	[SerializeField] SpriteRenderer clothes;
	[SerializeField] SpriteRenderer hat;

    [SerializeField] SpriteSheet bodySheet;
    [SerializeField] SpriteSheet clothesSheet;
    [SerializeField] SpriteSheet hatSheet;

	private void Update()
	{
		if (x == prevX && y == prevY) return;

		prevX = x; prevY = y;
		if(bodySheet) body.sprite = bodySheet.GetSprite(x, y);
		if(clothesSheet) clothes.sprite = clothesSheet.GetSprite(x, y);
		if(hatSheet) hat.sprite = hatSheet.GetSprite(x, y);
	}
}
