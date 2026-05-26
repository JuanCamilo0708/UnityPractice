using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    static private CheckPointManager instance;
    static public CheckPointManager Instance { get { return instance; } }
    private CheckPoint lastSavedCheckpoint;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void SaveCheckPoint(CheckPoint checkPoint)
    {
        lastSavedCheckpoint = checkPoint;
    }
    public CheckPoint GetCheckPoint()
    {
        return lastSavedCheckpoint;
    }
}

