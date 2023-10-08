using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : Interactor
{
	[SerializeField] Wares wares;

	public override void RunInteraction()
	{
		Debug.Log($"Merching! {name}");
		Shop.Instance.InitializeWares(wares);
	}
}
