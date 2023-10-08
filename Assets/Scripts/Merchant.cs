using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : Interactor
{
	public override void RunInteraction()
	{
		Debug.Log($"Merching! {name}");
	}
}
