using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemData", order = 0)]
public class ItemScriptable : ScriptableObject
{
    public int Type;
    public string Name;
    public Sprite Image;
}
