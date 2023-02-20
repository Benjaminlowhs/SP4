using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
	public Item slottedItem;

	public int index;
	public GameObject itemImage;

	public void SetSprite()
	{
		itemImage.GetComponent<Image>().sprite = slottedItem.icon;
	}
	public void AddItem(Item item)
	{
		slottedItem = item;
	}
}
