using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

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
            CallMask(newItem, true);
            DestroyItem(curretType);
        }
        else
        {
            CallMask(newItem, false);
        }

    }

    void DestroyItem(int type)
    {
        GameObject newItem = null;
        bool itemFound = false;

        for (int i = _itens.Count - 1; i >= 0; i--)
        {
            GameObject item = _itens[i];
            if (type == item.GetComponent<ItemScript>().GetItemType())
            {
                _itens.RemoveAt(i);
                item.GetComponent<ItemScript>().ItemDestroyer();
                _audioManagerScript.PlayMatch();
                newItem = item;
                itemFound = true;
            }
        }

        
        if(newItem != null && itemFound)
        {
            GameObject VFX = Instantiate(_matchEffect, transform);
            VFX.GetComponent<MatchEffectScript>().Init(newItem.GetComponent<ItemScript>().GetItemSprite());
            VFX.transform.position = newItem.transform.position - new Vector3(0,150,0);
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

        MatchItens(item);
    }

    void CallMask(GameObject item, bool third)
    {
        _VFXMaskInstatnce = Instantiate(_VFXMaskPrefab, _gameplayHUD.transform);
        _VFXMaskInstatnce.transform.position = item.transform.position;
        _VFXMaskInstatnce.GetComponent<RectTransform>().rotation = item.GetComponent<ItemScript>().GetSpriteRect().rotation;
        _VFXMaskInstatnce.GetComponent<MaskItemScript>().Init(item, third);
    }
    
}
