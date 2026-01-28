using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TargetBarScript : MonoBehaviour
{
    public List<GameObject> targets;
    public List<int> _targetsCount;
    public Sprite _bgImage;
    private int _index = 0;
    public GameManagerScript _gameManagerScript;

    public void SetTargetItem(Sprite image, int number)
    {      

        if (_index <= targets.Count)
        {
            GameObject currentTarget = targets[_index];

            if (currentTarget)
            {
                currentTarget.GetComponentInChildren<Image>().sprite = image;
                currentTarget.GetComponentInChildren<TMP_Text>().SetText(number.ToString());
                currentTarget.GetComponent<Image>().sprite = _bgImage;
                _targetsCount.Add(number);
            }            
            _index++;
        }        
    }

    public void TargetsCount(int index)
    {
        GameObject currentTarget = targets[index];

        int number = _targetsCount[index] - 1;
        _targetsCount[index] = number;

        if (currentTarget)
        {
            currentTarget.GetComponentInChildren<TMP_Text>().SetText(number.ToString());
        }

        _gameManagerScript.ItensSum(_targetsCount[0], _targetsCount[1], _targetsCount[2]);
    }
}
