using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<ItemScriptable> _brains;
    public GameObject _itemPrefab;
    public GameObject _gmCanva;
    private ItemScript _itemScript;

    private void Start()
    {
        foreach (ItemScriptable item in _brains)
        {
            GameObject itemInstace = Instantiate(_itemPrefab, _gmCanva.transform);
            _itemScript = itemInstace.GetComponent<ItemScript>();
            _itemScript.Init(item);
        }

    }
}
