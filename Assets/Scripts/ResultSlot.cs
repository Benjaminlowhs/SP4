using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour
{
	public Item craftedItem;

	public Sprite emptySprite;

	private void Update()
	{
		if (craftedItem != null)
		{
			SetSprite();
		}
		else
		{
			SetDefaultSprite();
		}
	}
	public void SetDefaultSprite()
	{
		if (craftedItem == null)
		{
			GetComponent<Image>().sprite = emptySprite;
		}
	}
	public void SetSprite()
	{
		GetComponent<Image>().sprite = craftedItem.icon;
	}
	public void AddItem(Item item)
	{
		craftedItem = item;
	}
}
