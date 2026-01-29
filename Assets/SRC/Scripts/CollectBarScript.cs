using System.Collections.Generic;
using UnityEngine;

public class CollectBarScript : MonoBehaviour
{
    public GameObject _barIMG;
    public GameObject _matchEffect;
    public GameObject _VFXMaskPrefab;
    public GameObject _gameplayHUD;
    public AudioManagerScript _audioManagerScript;
    private List<GameObject> _itens = new List<GameObject>();
    private int _maxItens = 7;
    private List<int> _typeCount = new List<int> { 0, 0, 0 };
    private GameObject _VFXMaskInstatnce;


    public void AddItem(GameObject item)
    {
        if(_itens.Count < _maxItens)
        {
            _itens.Add(item);
            item.transform.SetParent(_barIMG.transform);
            RealignItens(item);
        } 
    }

    void MatchItens(GameObject newItem)
    {
        //RealignItens(newItem);
        int curretType = newItem.GetComponent<ItemScript>().GetItemType();
        int curretCount = 0;

        
        foreach (GameObject item in _itens)
        {
            if(curretType == item.GetComponent<ItemScript>().GetItemType())
            {
                curretCount++;             
            }
        }

        _typeCount[curretType] = curretCount;

        if (curretCount >= 3)
        {
            CallMask(newItem, true, 0.25f);
            DestroyItem(curretType);
        }
        else
        {
            CallMask(newItem, false, 0.25f);
        }

    }

    void DestroyItem(int type)
    {
        List<GameObject> matchedItems = new List<GameObject>();

        for (int i = _itens.Count - 1; i >= 0; i--)
        {
            GameObject item = _itens[i];
            if (type == item.GetComponent<ItemScript>().GetItemType())
            {
                _itens.RemoveAt(i);
                matchedItems.Add(item);
            }
        }

        if(matchedItems.Count > 0)
        {
            _audioManagerScript.PlayMatch();
            GameObject targetItem = matchedItems[1];
            GameObject VFX = Instantiate(_matchEffect, transform);
            VFX.GetComponent<MatchEffectScript>().Init(targetItem.GetComponent<ItemScript>().GetItemSprite());
            VFX.transform.position = targetItem.transform.position;
        }

        foreach (GameObject item in matchedItems)
        {
            item.GetComponent<ItemScript>().ItemDestroyer();
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
            int localType = _itens[i].GetComponent<ItemScript>().GetItemType();
            if (localType != type)
            {
                CallMask(_itens[i], false, 0.8f);
            }


        }

        MatchItens(item);
    }

    void CallMask(GameObject item, bool third, float time)
    {
        _VFXMaskInstatnce = Instantiate(_VFXMaskPrefab, _gameplayHUD.transform);
        _VFXMaskInstatnce.transform.position = item.transform.position;
        _VFXMaskInstatnce.GetComponent<RectTransform>().rotation = item.GetComponent<ItemScript>().GetSpriteRect().rotation;
        _VFXMaskInstatnce.GetComponent<MaskItemScript>().Init(item, third, time);
    }
    
}
