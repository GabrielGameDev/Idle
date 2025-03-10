using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiItem : MonoBehaviour
{
    public TMP_Text title, amountText;
    public Image icon;
    public Resource resource;

    public void AddItem(Resource newResource, int amount)
    {
        resource = newResource;
        title.text = newResource.name;
        icon.sprite = newResource.image;
        amountText.text = "x " + amount;
    }

    public void UpdateAmount(int amount)
    {
        amountText.text = "x " + amount;
    }
}
