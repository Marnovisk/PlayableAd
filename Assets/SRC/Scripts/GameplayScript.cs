using System.Collections;
using UnityEngine;

public class GameplayScript : MonoBehaviour
{
    public CollectBarScript _collectBar;
    public TargetBarScript _targetBar;
    public GameObject _tutorialPrefab;
    private GameObject _tutorialInstance;
    private bool _isTutorial = false;
    private float _idleTimer = 0f;
    private const float TimeToShowTutorial = 2f;

    private void Update()
    {
        if (_tutorialInstance)
        {
            _idleTimer = 0f;
            return;
        }
        _idleTimer += Time.deltaTime;

        if (_idleTimer >= TimeToShowTutorial)
        {
            if (transform.childCount > 0)
            {
                SpawnTutorial(transform.GetChild(0).gameObject, transform);
                _idleTimer = 0f;
            }
        }
    }
    public void AddItenOnBar(GameObject item)
    {
        _collectBar.AddItem(item);
    }

    public void TargetCount(int index)
    {
        _targetBar.TargetsCount(index);
    }

    public void SpawnTutorial(GameObject lastItem, Transform spawnTransform)
    {
        if (!_isTutorial)
        {
            _tutorialInstance = Instantiate(_tutorialPrefab, spawnTransform);
            _tutorialInstance.transform.position = lastItem.transform.position;
            _isTutorial = true;
        }
    }

    public void DestroyTutorial()
    {
        if (_tutorialInstance != null)
        {
            Destroy(_tutorialInstance);
            _isTutorial = false;
            _idleTimer = 0f;
        }
    }

    public void ItemSelected()
    {
        
    }
}
