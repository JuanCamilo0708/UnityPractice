using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private List<float> _collectableItems = new List<float>() {-2.5f,-1.5f, -0.5f, 0.5f, 1.5f,};
    [SerializeField]
    private int _index;
    private static CollectableScript _instance = null;
    public static CollectableScript Instance { get { return _instance; } }
    public void Generate()
    {
        _index = Random.Range(0, _collectableItems.Count);
        Vector2 pos = new Vector2(0, _collectableItems[_index]);
        Instantiate(_prefab, pos, Quaternion.identity);
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Generate();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

}
