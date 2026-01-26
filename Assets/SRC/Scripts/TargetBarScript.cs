using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class TargetBarScript : MonoBehaviour
{
    public List<GameObject> targets;
    public Sprite _bgImage;
    [SerializeField] private int _index = 0;

    public void SetTargetItem(Sprite image, int number)
    {
        if(_index <= targets.Count)
        {
            GameObject currentTarget = targets[_index];

            if (currentTarget)
            {
                currentTarget.GetComponentInChildren<Image>().sprite = image;
                currentTarget.GetComponentInChildren<TMP_Text>().SetText(number.ToString());
                currentTarget.GetComponent<Image>().sprite = _bgImage;
            }

            
            _index++;
        }
        
    }
}
