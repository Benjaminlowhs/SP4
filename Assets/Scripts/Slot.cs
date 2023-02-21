using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
	public Item slottedItem;

	public Sprite emptySprite;
	private void Update()
	{
		if (slottedItem != null)
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
		if (slottedItem == null)
		{
			GetComponent<Image>().sprite = emptySprite;

		}
	}
	public void SetSprite()
	{
		GetComponent<Image>().sprite = slottedItem.icon;
	}
	public void AddItem(Item item)
	{
		slottedItem = item;
		Debug.Log("Slot " + slottedItem);
	}
}
