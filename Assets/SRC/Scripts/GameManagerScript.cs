using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<ItemScriptable> _brains;
    public GameObject _itemPrefab;
    public GameObject _gmCanva;
    public TargetBarScript _barScript;
    private ItemScript _itemScript;

    private void Start()
    {
        foreach (ItemScriptable item in _brains)
        {
            int value = Random.Range(20, 40);
            for(int i = 0; i < value; i++)
            {
                GameObject itemInstace = Instantiate(_itemPrefab, _gmCanva.transform);
                _itemScript = itemInstace.GetComponent<ItemScript>();
                _itemScript.Init(item);
            }

            _barScript.SetTargetItem(item.Image, value);

        }

    }
} 
