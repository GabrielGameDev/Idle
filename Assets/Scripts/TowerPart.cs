using UnityEngine;

public class TowerPart : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void OnMouseDown()
	{
		Tower.instance.AddTowerPart();
		SetInfoText();
	}

	void OnMouseEnter()
	{
		Cursor.SetCursor(LevelManager.instance.interactCursor, Vector2.zero, CursorMode.Auto);
		SetInfoText();

	}

	void SetInfoText()
	{
		string costText = "";
		foreach (var item in Tower.instance.resources)
		{
			costText += item.amount + " " + item.resource.name + " ";
		}
		LevelManager.instance.infoText.text = "Clique para adicionar parte da torre por " + costText;
	}

	void OnMouseExit()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
