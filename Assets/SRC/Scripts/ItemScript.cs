using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private ItemScriptable _brain;
    private Image _image;
    private RectTransform _rectTransform;
    private GameplayScript _gmScript;
    public void Init(ItemScriptable brain)
    {
        _brain = brain;
        _rectTransform = GetComponent<RectTransform>();
        SetSprite();
        SetPosition();
        //SetRotation();
    }

    private void SetSprite()
    {
        if(!_brain) return;

        _image = GetComponent<Image>();
        _image.sprite = _brain.Image;
    }

    private void SetPosition()
    {
        if (!_brain) return;
        float randomX = Random.Range(-400f, 400f);
        float randomY = Random.Range(-400, 400);
        float randomZ = Random.Range(0, 10);

        _rectTransform.anchoredPosition = new Vector3(randomX, randomY, randomZ);
    }

    private void SetRotation()
    {
        if (!_brain) return;
        float randomX = Random.Range(-200f, 550f);
        float randomY = Random.Range(-400, 400);
        float randomZ = Random.Range(0, 10);

        _rectTransform.rotation = new Quaternion(randomX, randomY, randomZ, 0);
    }

    public void SlectItem()
    {
        _gmScript = GetComponentInParent<GameplayScript>();
        Debug.Log("Click");
        if (_gmScript == null) return;
        _gmScript.AddItenOnBar(this.gameObject);
    }
    
}
