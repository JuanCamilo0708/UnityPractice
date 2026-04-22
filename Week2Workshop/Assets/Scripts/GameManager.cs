using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText = null;

    private int _score = 0;
    private static GameManager _instance = null;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if(Instance == null)
        {
            _instance = this;
            UpdateScore();
        }
        else
        {
            Destroy(gameObject);
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
