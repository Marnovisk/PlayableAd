using System.Collections.Generic;
using UnityEngine;

public class CollectBarScript : MonoBehaviour
{
    public GameObject BarIMG;
    private List<GameObject> _itens = new List<GameObject>();
    private int _maxItens = 7;

    public void AddItem(GameObject item)
    {
        if(_itens.Count < _maxItens)
        {
            _itens.Add(item);
            item.transform.SetParent(BarIMG.transform);
        } 
    }
}
