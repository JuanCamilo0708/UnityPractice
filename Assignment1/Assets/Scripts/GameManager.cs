using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pins;
    [SerializeField]
    private GameObject _pinPrefab;
    [SerializeField]
    private GameObject _pinPrefab2;
    [SerializeField]
    private GameObject _pinPrefab3;
    [SerializeField]
    private GameObject _pinPrefab4;
    [SerializeField]
    private float _rows;
    [SerializeField]
    private float _columns;
    [SerializeField]
    private float _spacingX = 2f;
    [SerializeField]
    private float _spacingY = 1.0f;
    [SerializeField]
    private TMP_Text _scoreText = null;


    private int _score = 0;
    private static GameManager _instance = null;
    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            UpdateScore();
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        Generate();
        UpdateScore();
    }


    public void Generate()
    {
        for (float row = -2f; row < _rows - 2; row++)
        {
            for (float col = -(_columns - 1); col < _columns - 1; col++)
            {
                float offset = (row % 2 == 0) ? 0f : _spacingX / 2f;
                Vector3 position = new Vector3(
                    col + 0.25f * _spacingX + offset,
                    -row * _spacingY,
                    0f
                );
                float rand = Random.Range(0f, 100f);
                if (rand < 30)
                    Instantiate(_pinPrefab, position, Quaternion.identity, _pins.transform);
                else if (rand < 60)
                    Instantiate(_pinPrefab4, position, Quaternion.identity, _pins.transform);
                else if (rand < 85)
                    Instantiate(_pinPrefab2, position, Quaternion.identity, _pins.transform);
                else
                    Instantiate(_pinPrefab3, position, Quaternion.identity, _pins.transform);
            }
        }
    }
    public void AddScore(int score)
    {
        _score += score;
        UpdateScore();
    }
    public void UpdateScore()
    {
        _scoreText.text = $"Score: {_score}";
    }
}
