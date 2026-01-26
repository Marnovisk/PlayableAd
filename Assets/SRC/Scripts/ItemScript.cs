using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private ItemScriptable _brain;
    [SerializeField]  private Image _image;
    [SerializeField]  private GameObject _imageObject;
    [SerializeField]  private RectTransform _imageRect;
    private RectTransform _rectTransform;
    private GameplayScript _gmScript;
    public void Init(ItemScriptable brain)
    {
        _brain = brain;
        _rectTransform = GetComponent<RectTransform>();
        GetImage();        
        SetPosition();
    }

    private void GetImage()
    {
        if (!_brain) return;

        //Image[] _images = GetComponentsInChildren<Image>();
        //foreach (Image image in _images)
        //{
        //    if(!image.GetComponent<Button>())
        //    {
        //        _image = image;
        //    }
        //}


        _image = GetComponentInChildren<Image>();
        _imageObject = _image.gameObject;
        _imageRect = _imageObject.GetComponent<RectTransform>();

        SetSprite();
        SetRotation();
    }

    private void SetSprite()
    {
        if(!_brain) return;
        if(!_image) return;

        _image.sprite = _brain.Image;
        Debug.Log("Sprite Setted");
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
        if(!_imageObject) return;
        float randomZ = Random.Range(0, 380);

        _imageRect.rotation = Quaternion.Euler(0, 0, randomZ);
    }

    public void SlectItem()
    {
        _gmScript = GetComponentInParent<GameplayScript>();
        Debug.Log("Click");
        if (_gmScript == null) return;
        _gmScript.AddItenOnBar(this.gameObject);
        _imageRect.rotation = Quaternion.Euler(0, 0, 90);
    }
    
}
