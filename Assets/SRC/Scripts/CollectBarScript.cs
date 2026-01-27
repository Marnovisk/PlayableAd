using System.Collections.Generic;
using UnityEngine;

public class CollectBarScript : MonoBehaviour
{
    public GameObject BarIMG;
    private List<GameObject> _itens = new List<GameObject>();
    private int _maxItens = 7;
    private List<int> _typeCount = new List<int> { 0, 0, 0 };

    public void AddItem(GameObject item)
    {
        if(_itens.Count < _maxItens)
        {
            _itens.Add(item);
            item.transform.SetParent(BarIMG.transform);
            CheckItem(item);
        } 
    }

    void CheckItem(GameObject newItem)
    {
        int curretnType = newItem.GetComponent<ItemScript>().GetItemType();
        int curretnCount = 0;
        
        foreach (GameObject item in _itens)
        {
            if(curretnType == item.GetComponent<ItemScript>().GetItemType())
            {
                curretnCount++;
            }
        }

        _typeCount[curretnType] = curretnCount;


        if (curretnCount >= 3)
        {
            DestroyItem(curretnType);
        }


        Debug.Log("Type: " + curretnType + "Has: " + curretnCount);

    }

    void DestroyItem(int type)
    {
        for (int i = _itens.Count - 1; i >= 0; i--)
        {
            GameObject item = _itens[i];
            if (type == item.GetComponent<ItemScript>().GetItemType())
            {
                _itens.Remove(item);
                Destroy(item);
            }
        }
    }
}
