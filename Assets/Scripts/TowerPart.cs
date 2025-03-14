using UnityEngine;

public class TowerPart : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void OnMouseDown()
	{
		Tower.instance.AddTowerPart();
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
