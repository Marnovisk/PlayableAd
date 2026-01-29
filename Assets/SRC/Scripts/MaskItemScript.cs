using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaskItemScript : MonoBehaviour
{
    private float _duration = 0.025f;
    [SerializeField] private AnimationCurve _easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void Init(GameObject targetItem, bool is3, float duration)
    {
        GetComponent<Image>().sprite = targetItem.GetComponent<ItemScript>().GetItemSprite();
        _duration = duration;
        targetItem.GetComponent<ItemScript>().SetInvisible(true);
        StartCoroutine(MoveToPosition(targetItem, is3));
    }

    private IEnumerator MoveToPosition(GameObject target, bool is3)
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0;
        Vector3 targetPosition = target.GetComponent<RectTransform>().transform.position;
       
        while (timeElapsed < _duration)
        {
            if (target)
            {
                if (is3)
                {
                    targetPosition = target.transform.position - new Vector3(0, 300, 0);
                }
                else
                {
                    targetPosition = target.transform.position;
                }
            }

            float t = timeElapsed / _duration;
            float curveValue = _easeCurve.Evaluate(t);

            transform.position = Vector3.Lerp(startPosition, targetPosition, curveValue);
            GetComponent<RectTransform>().rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 90), curveValue);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition;
        GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 90);
        if(target) target.GetComponent<ItemScript>().SetInvisible(false);
        Destroy(gameObject);
    }
}
