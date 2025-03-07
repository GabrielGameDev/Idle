using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static Tower instance;

    public float increaseAmout = 1.1f;
    public List<Item> resources;

    public Transform towerTop;
    public GameObject towerPart;

	private void Awake()
	{
		instance = this;
	}

	public void AddTowerPart()
    {
        if(LevelManager.instance.items == null || LevelManager.instance.items.Count == 0)
        {
            Debug.Log("Sem itens");
            return;
        }

        Dictionary<Resource, int> levelItems = LevelManager.instance.items.ToDictionary(item => item.resource, item => item.amount);

        foreach (var item in resources)
        {
            if(!levelItems.ContainsKey(item.resource) || item.amount > levelItems[item.resource]) 
            {
                Debug.Log("Não tem recursos");
                return;
            }
        }

        Debug.Log("Adiciona uma parte");

        
    }

}
