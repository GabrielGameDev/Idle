using UnityEngine;

public class TowerPart : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private void OnMouseDown()
	{
		Tower.instance.AddTowerPart();
	}
}
