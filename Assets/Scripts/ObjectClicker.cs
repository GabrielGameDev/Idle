using UnityEngine;
using UnityEngine.Events;

public class ObjectClicker : MonoBehaviour
{

	public UnityEvent OnMouseClick;
	public UnityEvent OnMouseClickUp;

	private void OnMouseDown()
	{
		OnMouseClick.Invoke();
	}

	private void OnMouseUp()
	{
		OnMouseClickUp.Invoke();
	}
}
