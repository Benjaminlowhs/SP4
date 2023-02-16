using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Recipes",menuName ="Recipe/Create New Recipe")]
public class Recipe : ScriptableObject
{
	public Item item1;
	public Item item2;
	public Item item3;
	public Item item4;
	public Item resultItem;

	public Item GetItem(Slot[] slots, int i)
	{
		if (slots[i].item = item1) return item1;
		if (slots[i].item = item2) return item2;
		if (slots[i].item = item3) return item3;
		if (slots[i].item = item4) return item4;
		
		return null;
	}
}
