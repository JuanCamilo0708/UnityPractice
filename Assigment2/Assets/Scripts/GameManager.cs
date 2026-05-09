using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image _diamondImg = null;
    [SerializeField]
    private UnityEngine.UI.Image _emeraldImg = null;
    [SerializeField]
    private Sprite[] _sprites = null;

    private int _diamondCount = 0;
    private int _emeraldCount = 0;
    private static GameManager _instance = null;
    public static GameManager Instance { get { return _instance; } }
    public static int DiamondCount { get { return Instance._diamondCount; } }
    public static int EmeraldCount { get { return Instance._emeraldCount; } }

    void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            UpdateCollectables();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddDiamond()
    {
        _diamondCount++;
        UpdateCollectables();
    }
    public void AddEmerald()
    {
        _emeraldCount++;
        UpdateCollectables();
    }
    public void UpdateCollectables()
    {
        if (_diamondCount == 0)
            _diamondImg.sprite = _sprites[0];
        else
            _diamondImg.sprite = _sprites[0 + _diamondCount];

        if (_emeraldCount == 0)
            _emeraldImg.sprite = _sprites[0];
        else
            _emeraldImg.sprite = _sprites[0 + _emeraldCount];
    }
    public void Reset()
    {
        _diamondCount = 0;
        _emeraldCount = 0;
        UpdateCollectables();
    }
}
