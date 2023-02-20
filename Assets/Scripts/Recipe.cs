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

	public Item GetItem(int i)
	{
		Item returnItem = null;
		if (i == 0)
			returnItem =  item1;
		if (i == 1)
			returnItem = item2;
		if (i == 2)
			returnItem = item3;
		if (i == 3)
			returnItem = item4;
		
		return returnItem;
	}
}
