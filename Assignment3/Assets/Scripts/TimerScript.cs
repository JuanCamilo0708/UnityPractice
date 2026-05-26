using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text timerText;
    private float time;
    private bool isRunning;
    void Update()
    {
        if(!isRunning)
        {
            return;
        }
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void RestartTimer()
    {
        time = 0;
        isRunning = true;
    }
    public void StopTimer()
    {
        isRunning = false;
    }
}
