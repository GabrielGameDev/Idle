using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
	public Resource resource;
	public int amount;
}

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;
	public List<Item> items;
	

	private void Awake()
	{
		instance = this;
	}

	public void AddResource(Resource resource)
	{		
		foreach (var item in items)
		{
			if (item.resource == resource)
			{
				item.amount += 1;
				return;
			}
		}

		Item newItem = new Item()
		{
			resource = resource,
			amount = 1
		};

		items.Add(newItem);

	}
}
