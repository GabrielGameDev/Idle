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

	public AudioClip buySound;
	public AudioClip hoverSound;

	AudioSource audioSource;

	private void Awake()
	{
		instance = this;
		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			uiPanel.SetActive(!uiPanel.activeSelf);
		}
	}

	public void AddResource(Resource resource, int amount)
	{
		foreach (var item in items)
		{
			if (item.resource == resource)
			{
				item.amount += amount;
				uiItems.Find(uiItem => uiItem.resource == resource).UpdateAmount(item.amount);
				return;
			}
		}

		Item newItem = new Item()
		{
			resource = resource,
			amount = amount
		};

		items.Add(newItem);
		UiItem uiItem = Instantiate(uiItemPrefab, itemsPanel);
		uiItem.AddItem(resource, amount);
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

		Dictionary<Resource, int> levelItems = items.ToDictionary(item => item.resource, item => item.amount);

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
		audioSource.PlayOneShot(buySound);
		return true;
	}

	public void SetInfoText(string text)
	{
		audioSource.PlayOneShot(hoverSound);
		infoText.text = text;
	}

	public void PlaySound(AudioClip clip)
	{
		if (audioSource.isPlaying)
		{
			return;
		}
		audioSource.clip = clip;
		audioSource.Play();
	}

}
