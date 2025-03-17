using System.Collections.Generic;
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

    public void Upgrade()
    {
        if (LevelManager.instance.CanBuy(resourcesCost, increaseAmount))
        {
            switch (upgradeType)
            {
                case UpgradeType.Amount:
                    collectArea.UpgradeAmount();
                    break;
                case UpgradeType.Interval:
                    collectArea.UpgradeInterval();
                    break;
            }
        }
    }


}
