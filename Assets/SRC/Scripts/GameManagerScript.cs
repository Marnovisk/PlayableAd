using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public List<ItemScriptable> _brains;
    public GameObject _itemPrefab;
    public GameObject _gmCanva;
    public TargetBarScript _barScript;
    public TMP_Text _timeText;
    private ItemScript _itemScript;
    private float _time;

    private void Start()
    {
        _time = 30.0f;
        foreach (ItemScriptable item in _brains)
        {
            int value = Random.Range(20, 40);
            for(int i = 0; i < value; i++)
            {
                GameObject itemInstace = Instantiate(_itemPrefab, _gmCanva.transform);
                _itemScript = itemInstace.GetComponent<ItemScript>();
                _itemScript.Init(item);
            }

            _barScript.SetTargetItem(item.Image, value);

        }

    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_time >= 0)
        {
            _time -= Time.deltaTime;
            _timeText.SetText("0:" + Mathf.CeilToInt(_time).ToString());
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {

    }
} 
