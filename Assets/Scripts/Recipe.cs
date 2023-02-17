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
		if (slots[i].slottedItem == item1) return item1;
		else if (slots[i].slottedItem == item2) return item2;
		else if (slots[i].slottedItem == item3) return item3;
		else if (slots[i].slottedItem == item4) return item4;
		
		return null;
	}
}
