using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum UpgradeType
{
    Amount,
    Interval
}

public class UpgradeButton : MonoBehaviour
{
    public CollectArea collectArea;
    public UpgradeType upgradeType;
    public List<Item> resourcesCost;
    public float increaseAmount = 1.5f;

    TMP_Text buttonText;
    int level = 1;

    void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
        UpdateText();
    }

    void UpdateText()
    {
        string resourceName = collectArea.resource.resourceName;
        string upgradeTypeString = upgradeType == UpgradeType.Amount ? "Efficiency" : "Interval";
        string costText = "";
        foreach (var item in resourcesCost)
        {
            costText += item.amount + " " + item.resource.name + " ";
        }
        buttonText.text = $"{resourceName} {upgradeTypeString} Level {level}\nCost: {costText}";
    }
    public void Upgrade()
    {
        if (LevelManager.instance.CanBuy(resourcesCost, increaseAmount))
        {
            level++;
            switch (upgradeType)
            {
                case UpgradeType.Amount:
                    collectArea.UpgradeAmount();
                    break;
                case UpgradeType.Interval:
                    collectArea.UpgradeInterval();
                    break;
            }
            UpdateText();
        }
    }


}
