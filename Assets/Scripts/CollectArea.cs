using UnityEngine;

public class CollectArea : MonoBehaviour
{
	public Resource resource;

	public float interval = 1f;
	bool cliked;
	float timer;


	private void Update()
	{
		if (cliked)
		{
			timer += Time.deltaTime;
			if (timer > interval)
			{
				timer = 0f;
				LevelManager.instance.AddResource(resource);
			}
		}
		else
		{
			timer = 0f;
		}
	}

	void OnMouseEnter()
	{
		Cursor.SetCursor(LevelManager.instance.interactCursor, Vector2.zero, CursorMode.Auto);
		LevelManager.instance.infoText.text = "Segure botão esquerdo para coletar " + resource.name;
	}

	void OnMouseExit()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		LevelManager.instance.infoText.text = "";
	}

	private void OnMouseDown()
	{
		cliked = true;
	}

	private void OnMouseUp()
	{
		cliked = false;
	}
}
