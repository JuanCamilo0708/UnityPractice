using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text timerText;

    void Start()
    {
        float time = GameManager.Instance.Timer;
        if (time < 60)
        {
            timerText.text = "Your time: " + (time.ToString("F3"));
        }
        else
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("Your time: {0:00}:{1:00}", minutes, seconds);
        }
    }

}
