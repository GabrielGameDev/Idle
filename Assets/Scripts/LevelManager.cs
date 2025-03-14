using System.Collections.Generic;
using System.Linq;
using TMPro;
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
	public Texture2D interactCursor;
	public TMP_Text infoText;
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

	public bool CanBuy(List<Item> resources, float increaseAmout)
	{
		if (items == null || items.Count == 0)
		{

			infoText.text = "Sem itens";
			return false;
		}

		Dictionary<Resource, int> levelItems = LevelManager.instance.items.ToDictionary(item => item.resource, item => item.amount);

		foreach (var item in resources)
		{
			if (!levelItems.ContainsKey(item.resource) || item.amount > levelItems[item.resource])
			{

				infoText.text = "Não tem recursos";
				return false;
			}
		}

		Debug.Log("Remove os recursos");
		foreach (var item in resources)
		{
			if (levelItems.ContainsKey(item.resource))
			{
				// LevelManager.instance.items
				//     .First(i => i.resource == item.resource)
				//     .amount -= item.amount;

				RemoveResource(item.resource, item.amount);

				Debug.Log("Gastou " + item.amount + " de " + item.resource);
				item.amount = Mathf.RoundToInt(item.amount * increaseAmout);
			}
		}
		return true;
	}


}
