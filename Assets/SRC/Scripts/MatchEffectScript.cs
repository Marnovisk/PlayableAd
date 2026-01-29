using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class MatchEffectScript : MonoBehaviour
{
    public List<GameObject> _itens;

    public void Init(Sprite sprite)
    {
        foreach (GameObject itens in _itens)
        {
            itens.GetComponent<Image>().sprite = sprite;
        }
    }
    public void CallDestroy()
    {
        Destroy(gameObject);
    }
}
