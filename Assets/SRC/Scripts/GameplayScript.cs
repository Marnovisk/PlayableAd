using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GameplayScript : MonoBehaviour
{
    public CollectBarScript _collectBar;

    public void AddItenOnBar(GameObject item)
    {
        _collectBar.AddItem(item);
    }
}
