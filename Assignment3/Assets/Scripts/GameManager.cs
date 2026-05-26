using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }
    [SerializeField]
    private TMPro.TMP_Text timerText;
    private static float time;
    public float Timer { get { return time; } }
    [SerializeField]
    private bool isRunning = true;
    private int minutes;
    private int seconds;
    private void Awake()
    {
        if (Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
                       Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (!isRunning)
        {
            ChangeScene();
            return;
        }
        time += Time.deltaTime;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        if (time < 60)
        {
            timerText.text = time.ToString("F3");
        }
        else
        {
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }
    public void StopTimer()
    {
        isRunning = false;
    }
    public void ResetTimer()
    {
        time = 0;
        isRunning = true;
    }

}
