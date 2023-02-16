using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Recipes", menuName ="Recipe/NewRecipe")]
public class Recipe : ScriptableObject
{
	public Item output;

	public Item item1;
	public Item item2;
	public Item item3;
	public Item item4;

}
