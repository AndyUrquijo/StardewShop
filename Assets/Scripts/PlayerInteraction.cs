using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    List<Interactor> interactors = new List<Interactor>();
    Interactor activeInteractor = null;
    Animator animator;

	void Awake()
	{
		animator = GetComponentInParent<Animator>();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && activeInteractor != null)
		{
			activeInteractor.RunInteraction();
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        Interactor interactor = collision.attachedRigidbody.GetComponent<Interactor>();
        if (interactor)
        {
            interactors.Add(interactor);
            UpdateInteractors();
        }
    }

	void OnTriggerExit2D(Collider2D collision)
	{
		Interactor interactor = collision.attachedRigidbody.GetComponent<Interactor>();
		if (interactor)
		{
			interactors.Remove(interactor);
            interactor.SetInteractionActive(false);
			UpdateInteractors();
		}
	}

	void UpdateInteractors()
    {
        float closestDistanceSq = float.MaxValue;
        activeInteractor = null;
		foreach (var interactor in interactors) // Closest interactor is the one that receives interactions
		{
            float distanceSq = (transform.position - interactor.transform.position).sqrMagnitude;
            if (distanceSq < closestDistanceSq)
            {
                closestDistanceSq = distanceSq;
				activeInteractor = interactor;
            }
		}
        foreach (var interactor in interactors) // Set interactors active state
            interactor.SetInteractionActive(interactor == activeInteractor); 

        animator.SetBool(Interactor.ID_Interacting, activeInteractor != null);
	}
}
