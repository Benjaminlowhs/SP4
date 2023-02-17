using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
	public Item slottedItem;
	public ItemController slottedControllerItem;

	public int index;
	public GameObject itemImage;
	public List<GameObject> slots = new List<GameObject>();
	public static Slot Instance;

	private void Awake()
	{
		Instance = this;
	}
	public void SetSprite()
	{
		itemImage.GetComponent<Image>().sprite = slottedItem.icon;
	}
	public void AddItem(Item item)
	{
		slottedItem = item;
	}
}
