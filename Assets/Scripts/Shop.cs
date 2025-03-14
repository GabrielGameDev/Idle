using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public float increaseAmout = 1.5f;
    public List<Item> resources;
    public CharacterMiner miner;
    public Transform destinationPoint;

    void Buy()
    {
        if (LevelManager.instance.CanBuy(resources, increaseAmout))
        {
            CharacterMiner newMiner = Instantiate(miner, transform.position, Quaternion.identity);
            newMiner.destinationPoint = destinationPoint;
        }
    }

    void OnMouseDown()
    {
        Buy();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(LevelManager.instance.interactCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
