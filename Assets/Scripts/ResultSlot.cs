using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSlot : MonoBehaviour
{
	public Item craftedItem;
	public GameObject itemImage;

	public void SetSprite()
	{
		itemImage.GetComponent<Image>().sprite = craftedItem.icon;
	}
	public void AddItem(Item item)
	{
		craftedItem = item;
	}
}
