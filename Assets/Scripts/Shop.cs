using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
	[SerializeField] GameObject mainPanel;
	[SerializeField] ToggleGroup toggleGroup;
	[SerializeField] Button BuyButton;
	[SerializeField] Button EquipButton;
	[SerializeField] ShopEntry entryPrototype;

	Wares wares;


	List<ShopEntry> entries = new List<ShopEntry>();
	void Awake()
	{
		Instance = this;
		entryPrototype.gameObject.SetActive(false);
		mainPanel.SetActive(false);
	}

	public void InitializeWares(Wares wares)
	{
		this.wares = wares;

		mainPanel.SetActive(true);

		var selectedItem = GetSelectedItem();

		foreach (var entry in entries)
		{
			toggleGroup.UnregisterToggle(entry.Toggle);
			Destroy(entry.gameObject);
		}
		entries.Clear();

		foreach (var item in wares.Items)
		{
			var entry = Instantiate(entryPrototype, entryPrototype.transform.parent);
			entry.gameObject.SetActive(true);
			entry.Initialize(item);
			entries.Add(entry);
			toggleGroup.RegisterToggle(entry.Toggle);

			if (selectedItem != null && selectedItem == item)
				entry.Toggle.isOn = true;
		}
		
	}

	void Update()
	{
		var selectedItem = GetSelectedItem();
		if (selectedItem != null) 
		{
			// This code assumes items are outfits (as there are no other item types currently)
			bool held = Inventory.Instance.IsHeld(selectedItem);
			bool equipped = Inventory.Instance.IsEquipped(selectedItem as Outfit);
			BuyButton.gameObject.SetActive(!held);
			EquipButton.gameObject.SetActive(held);
			EquipButton.interactable = !equipped;
		}
		else
		{
			BuyButton.gameObject.SetActive(false);
			EquipButton.gameObject.SetActive(false);
		}
	}

	public void Buy()
	{
		Inventory.Instance.AddItem(GetSelectedItem());
		InitializeWares(wares);
	}

	public void Equip()
	{
		Inventory.Instance.EquipOutfit(GetSelectedItem() as Outfit);
		InitializeWares(wares);
	}

	public void Exit()
	{
		mainPanel.SetActive(false);
	}

	Item GetSelectedItem()
	{
		return toggleGroup.GetFirstActiveToggle()?.GetComponent<ShopEntry>()?.Item;
	}
}
