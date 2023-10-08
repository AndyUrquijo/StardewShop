using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopEntry : MonoBehaviour
{
    public Item Item;
    public Toggle Toggle;
    [SerializeField] Image Icon;
    [SerializeField] TextMeshProUGUI Label;
    [SerializeField] TextMeshProUGUI Price;

    public void Initialize(Item item)
    {
        this.Item = item;
        Icon.sprite = item.Icon;
        Label.SetText(item.Name);

		bool isHeld = Inventory.Instance.IsHeld(item);
        bool isEquipped = Inventory.Instance.IsEquipped(item as Outfit);
        Price.SetText( isEquipped?"EQUIPPED":isHeld?"OWNED":$"${(int)item.Price}");

		name = $"Entry: {item.Name}";
    }


}
