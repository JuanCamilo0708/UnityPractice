using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private bool _player1InZone = false;
    private bool _player2InZone = false;
    void Update()
    {
        if(_player1InZone&&_player2InZone&&GameManager.EmeraldCount ==3 && GameManager.DiamondCount == 3)
        {
            GameManager.Instance.Reset();
            UnityEngine.SceneManagement.SceneManager.LoadScene("WinScreen");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            _player1InZone = true;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            _player2InZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            _player1InZone = false;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            _player2InZone = false;
        }
    }
}
