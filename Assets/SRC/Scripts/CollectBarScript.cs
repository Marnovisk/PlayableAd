using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class CollectBarScript : MonoBehaviour
{
    public GameObject BarIMG;
    public AudioManagerScript _audioManagerScript;
    private List<GameObject> _itens = new List<GameObject>();
    private int _maxItens = 7;
    private List<int> _typeCount = new List<int> { 0, 0, 0 };


    public void AddItem(GameObject item)
    {
        if(_itens.Count < _maxItens)
        {
            _itens.Add(item);
            item.transform.SetParent(BarIMG.transform);
            MatchItens(item);
        } 
    }

    void MatchItens(GameObject newItem)
    {
        RealignItens(newItem);
        int curretType = newItem.GetComponent<ItemScript>().GetItemType();
        int curretnCount = 0;

        
        foreach (GameObject item in _itens)
        {
            if(curretType == item.GetComponent<ItemScript>().GetItemType())
            {
                curretnCount++;
            }
        }

        _typeCount[curretType] = curretnCount;

        if (curretnCount >= 3)
        {
            DestroyItem(curretType);
        }

    }

    void DestroyItem(int type)
    {
        for (int i = _itens.Count - 1; i >= 0; i--)
        {
            GameObject item = _itens[i];
            if (type == item.GetComponent<ItemScript>().GetItemType())
            {
                _itens.RemoveAt(i);
                item.GetComponent<ItemScript>().ItemDestroyer();
                _audioManagerScript.PlayMatch();
            }
        }
    }

    void RealignItens(GameObject item)
    {
        int type = item.GetComponent<ItemScript>().GetItemType();
        _itens.Remove(item);
        int targetIndex = -1;

        for (int i = _itens.Count - 1; i >= 0; i--)
        {

            if (_itens[i].GetComponent<ItemScript>().GetItemType() == type)
            {
                targetIndex = i + 1;
                break;
            }
        }

        if (targetIndex != -1)
        {
            _itens.Insert(targetIndex, item);
        }
        else
        {
            _itens.Add(item);
        }

        for (int i = 0; i < _itens.Count; i++)
        {
            _itens[i].transform.SetSiblingIndex(i);
        }
    }

    
}
