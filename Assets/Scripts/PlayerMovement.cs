using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    
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
            Vector2 dir = Vector2.zero;
            if(Mathf.Abs(input.x) >= Mathf.Abs(input.y))
                dir.x = input.x > 0 ? 1:-1;
            else
                dir.y = input.y > 0 ? 1:-1;

            animator.SetFloat(ID_DirX, dir.x);
            animator.SetFloat(ID_DirY, dir.y);
			animator.SetFloat(ID_Speed, 1);

            if (Input.GetKey(KeyCode.LeftShift))
            {
				animator.SetFloat(ID_Speed, 2);
		        body.velocity = runSpeed * input;
			}
			else
            {
                animator.SetFloat(ID_Speed, 1);
				body.velocity = walkSpeed * input;
			}

		}
        else
        {
            animator.SetFloat(ID_Speed, 0);
			body.velocity = Vector2.zero;
		}

	}
}
