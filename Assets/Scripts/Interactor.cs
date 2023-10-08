using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
	public static int ID_Interacting = Animator.StringToHash("Interacting");
	Animator animator;

	void Awake()
	{
		animator = GetComponent<Animator>();	
	}

	public void SetInteractionActive(bool active)
	{
		animator.SetBool(ID_Interacting, active);
	}	


	public virtual void RunInteraction()
	{
		Debug.Log($"Interacting! {name}");
	}
}
