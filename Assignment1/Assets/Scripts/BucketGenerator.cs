using UnityEngine;

public class BucketGenerator : MonoBehaviour
{
    public GameObject _lowBucket;
    public GameObject _mediumBucket;
    public GameObject _jackpotBucket;

    public float _totalWidth = 8f;
    public float _yPosition = -5f;
    public float _yPositionKiller = -8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] layout = new GameObject[5]
       {
            _lowBucket,
            _mediumBucket,
            _jackpotBucket,
            _mediumBucket,
            _lowBucket
       };
        int count = layout.Length;

        float spacing = _totalWidth / count;
        float startX = -_totalWidth / 2f + spacing / 2f;

        for (int i = 0; i < count; i++)
        {
            float x = startX + i * spacing;
            Vector3 pos = new Vector3(x, _yPosition, 0f);

            Instantiate(layout[i], pos, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball != null)
        {
            Destroy(ball.gameObject);
        }
    }
}

