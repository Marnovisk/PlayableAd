using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public List<ItemScriptable> _brains;

    public GameObject _itemPrefab;

    public GameObject _canva;
    public GameObject _infoBar;
    public GameObject _targetPrefab;
    public GameObject _collectBar;
    public GameObject _gameOverScreen;
    public GameObject _gameOverheart;
    public GameObject _gameOverStars;
    public GameObject _gameOverBG;
    public GameObject _gameOverBTN;

    public GameObject _gmCanva;

    public GameObject _alertImagePrefab;

    public Slider _timeSlider;    

    public AudioManagerScript _audioManagerScript;

    public TargetBarScript _barScript;

    private ItemScript _itemScript;

    public TMP_Text _timeText;

    public int _itensQTD;
    
    public float _time;

    private bool _done = false;

    private bool _alertPlayed = false;

    private GameObject _alertImageInstace;

    private GameplayScript _gameplayScript;

    public Sprite _stars;
    public Sprite _heart;
    public Sprite _winBTN;
    public Sprite _loseBTN;
    public Sprite _winBG;
    public Sprite _loseBG;


    private void Start()
    {
        _gameplayScript = _gmCanva.GetComponent<GameplayScript>();
        _gameOverScreen.SetActive(false);
        _time = 30.0f;
        GameObject lastItem = null;
        foreach (ItemScriptable item in _brains)
        {
            int value = _itensQTD;
            for(int i = 0; i < value; i++)
            {
                GameObject itemInstace = Instantiate(_itemPrefab, _gmCanva.transform);
                _itemScript = itemInstace.GetComponent<ItemScript>();
                _itemScript.Init(item);
                lastItem = itemInstace;
            }

            _barScript.SetTargetItem(item.Image, value);
            
        }

        if(lastItem != null)
        {
            _gameplayScript.SpawnTutorial(lastItem, _gmCanva.transform);            
        }
        

    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (!_done)
        {
            if (_time >= 0)
            {
                _time -= Time.deltaTime;
                int seconds = Mathf.CeilToInt(_time);
                _timeText.SetText($"0:{seconds:00}");
                _timeSlider.value = seconds;

                if (_time <= 10 && !_alertPlayed)
                {
                    _audioManagerScript.PlayAlert();
                    _alertPlayed = true;
                    _alertImageInstace = Instantiate(_alertImagePrefab, _canva.transform);
                }
            }
            else
            {
                GameOverScreenCall(false);
            }
        }
    }

    public void ItensSum(int type1, int type2, int type3)
    {
        if (type1 == 0 && type2 == 0 && type3 == 0)
        {
            GameOverScreenCall(true);
        }
    }

    void GameOverScreenCall(bool win)
    {
        _gameOverScreen.SetActive(true);
        _infoBar.SetActive(false);
        _targetPrefab.SetActive(false);
        _collectBar.SetActive(false);
        _audioManagerScript.PlayGameOver(win);
        Destroy(_alertImageInstace);

        _done = true;

        if (win)
        {
            _gameOverBG.GetComponent<Image>().sprite = _winBG;
            _gameOverheart.SetActive(false);
            _gameOverStars.SetActive(true);
            _gameOverBTN.GetComponent<Image>().sprite = _winBTN;
        }
        else
        {
            _gameOverBG.GetComponent<Image>().sprite = _loseBG;
            _gameOverheart.SetActive(true);
            _gameOverStars.SetActive(false);
            _gameOverBTN.GetComponent<Image>().sprite = _loseBTN;
            _gameOverBTN.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
} 
