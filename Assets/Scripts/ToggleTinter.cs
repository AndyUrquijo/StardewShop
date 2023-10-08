using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleTinter : MonoBehaviour
{
	[SerializeField] Color toggleColor;
	private Toggle toggle;
	ColorBlock defaultColors;

	private void Awake()
	{
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(OnToggleValueChanged);
		defaultColors = toggle.colors;
	}

	private void OnToggleValueChanged(bool isOn)
	{
		if (isOn)
		{
			ColorBlock cb = toggle.colors;
			cb.normalColor = toggleColor;
			cb.highlightedColor = toggleColor;
			cb.selectedColor = toggleColor;
			toggle.colors = cb;
		}
		else
		{
			toggle.colors = defaultColors;
		}
	}
}
