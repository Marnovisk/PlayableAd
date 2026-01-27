using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GameplayScript : MonoBehaviour
{
    public CollectBarScript _collectBar;
    public TargetBarScript _targetBar;

    public void AddItenOnBar(GameObject item)
    {
        _collectBar.AddItem(item);
    }

    public void TargetCount(int index)
    {
        _targetBar.TargetsCount(index);
    }
}
