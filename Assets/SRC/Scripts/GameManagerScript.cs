using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class GameManagerScript : MonoBehaviour
{
    public List<ItemScriptable> _brains;
    public GameObject _itemPrefab;
    public GameObject _gmCanva;
    public TargetBarScript _barScript;
    public TMP_Text _timeText;
    public int _itensQTD;
    private ItemScript _itemScript;
    private float _time;

    private void Start()
    {
        _time = 30.0f;
        foreach (ItemScriptable item in _brains)
        {
            int value = _itensQTD;
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

    public void ItensSum(int type1, int type2, int type3)
    {
        if (type1 == 0 && type2 == 0 && type3 == 0)
        {
            Debug.Log("Win");
        }
    }

    void GameOver()
    {
        Debug.Log("Lose");
    }
} 
