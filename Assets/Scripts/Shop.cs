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
            SetInfoText();

        }
    }

    void OnMouseDown()
    {
        Buy();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(LevelManager.instance.interactCursor, Vector2.zero, CursorMode.Auto);
        SetInfoText();
    }

    private void SetInfoText()
    {
        string costText = "";
        foreach (var item in resources)
        {
            costText += item.amount + " " + item.resource.name + " ";
        }
        LevelManager.instance.SetInfoText("Comprar coletador por " + costText);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        LevelManager.instance.infoText.text = "";
    }
}
