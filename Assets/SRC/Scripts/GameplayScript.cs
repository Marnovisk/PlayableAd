using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GameplayScript : MonoBehaviour
{
    public CollectBarScript _collectBar;
    public TargetBarScript _targetBar;
    public GameObject _tutorialPrefab;
    private GameObject _tutorialInstance;

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
        _tutorialInstance = Instantiate(_tutorialPrefab, spawnTransform);
        _tutorialInstance.transform.position = lastItem.transform.position;
    }

    public void DestroyTutorial()
    {
        if (_tutorialInstance != null)
        {
            Destroy(_tutorialInstance);
        }
    }
}
