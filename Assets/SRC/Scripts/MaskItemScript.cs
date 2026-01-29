using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MaskItemScript : MonoBehaviour
{
    [SerializeField] private float duration = 0.01f;
    [SerializeField] private AnimationCurve easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public void Init(GameObject targetItem, bool is3)
    {
        GetComponent<Image>().sprite = targetItem.GetComponent<ItemScript>().GetItemSprite();
        targetItem.GetComponent<ItemScript>().SetInvisible(true);
        StartCoroutine(MoveToPosition(targetItem, is3));
    }

    private IEnumerator MoveToPosition(GameObject target, bool is3)
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0;
        Vector3 targetPosition = target.GetComponent<RectTransform>().transform.position;
       
        while (timeElapsed < duration)
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

            float t = timeElapsed / duration;
            float curveValue = easeCurve.Evaluate(t);

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
