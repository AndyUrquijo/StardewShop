using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteSynchronizer : MonoBehaviour
{
    [SerializeField] int x, y;

    [SerializeField] SpriteRenderer body;
	[SerializeField] SpriteRenderer clothes;
	[SerializeField] SpriteRenderer hat;

    [SerializeField] SpriteSheet bodySheet;
    [SerializeField] SpriteSheet clothesSheet;
    [SerializeField] SpriteSheet hatSheet;

	Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if(bodySheet) body.sprite = bodySheet.GetSprite(x, y);
		if(clothesSheet) clothes.sprite = clothesSheet.GetSprite(x, y);
		if(hatSheet) hat.sprite = hatSheet.GetSprite(x, y);

		float dirX = animator.GetFloat(PlayerMovement.ID_DirX);
		bool flip = dirX < 0;
		body.flipX = flip;
		clothes.flipX = flip;
		hat.flipX = flip;
	}

}
