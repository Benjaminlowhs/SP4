using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
	public Item item;
	public int index;

	public void SetItem(Item outputItem)
	{
		if (index == 4)
		{
			item = outputItem;
		}
	}
}
