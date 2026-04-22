using TMPro;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField]
    private int _baseScore;
    [SerializeField]
    private TMP_Text _scoreText = null;

    // Update is called once per frame
    private void Start()
    {
        _scoreText.text = _baseScore.ToString();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            int finalScore = _baseScore * (int)ball.Mult;
            GameManager.Instance.AddScore(finalScore);
            Destroy(ball.gameObject);
        }
    }
}
