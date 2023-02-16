using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
	private Item currentItem;
	public void OnMouseDownItem(Item item)
	{
		if (currentItem == null)
		{
			currentItem = item;
		}
	}

}
