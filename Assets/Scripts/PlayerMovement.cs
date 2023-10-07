using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    
    Rigidbody2D body;
    Animator animator;
    
    Vector2 input;
    public static int ID_DirX = Animator.StringToHash("DirX");
    public static int ID_DirY = Animator.StringToHash("DirY");
    public static int ID_Speed = Animator.StringToHash("Speed");

	void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

	void FixedUpdate()
	{
		input.x = Input.GetAxisRaw("Horizontal");
		input.y = Input.GetAxisRaw("Vertical");
        if (input != Vector2.zero)
        {
            animator.SetFloat(ID_DirX, input.x);
            animator.SetFloat(ID_DirY, input.y);
			animator.SetFloat(ID_Speed, 1);
        }
        else
        {
            animator.SetFloat(ID_Speed, 0);
		}

		body.velocity = speed * input;
	}
}
