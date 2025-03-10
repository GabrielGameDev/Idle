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
	public GameObject uiPanel;
	public Transform itemsPanel;
	public UiItem uiItemPrefab;
	public List<UiItem> uiItems;

	private void Awake()
	{
		instance = this;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			uiPanel.SetActive(!uiPanel.activeSelf);
		}
	}

	public void AddResource(Resource resource)
	{
		foreach (var item in items)
		{
			if (item.resource == resource)
			{
				item.amount += 1;
				uiItems.Find(uiItem => uiItem.resource == resource).UpdateAmount(item.amount);
				return;
			}
		}

		Item newItem = new Item()
		{
			resource = resource,
			amount = 1
		};

		items.Add(newItem);
		UiItem uiItem = Instantiate(uiItemPrefab, itemsPanel);
		uiItem.AddItem(resource, 1);
		uiItems.Add(uiItem);

	}

	public void RemoveResource(Resource resource, int amount)
	{
		foreach (var item in items)
		{
			if (item.resource == resource)
			{
				item.amount -= amount;
				uiItems.Find(uiItem => uiItem.resource == resource).UpdateAmount(item.amount);
				return;
			}
		}
	}
}
