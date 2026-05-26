using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool disableOnTrigger = false;
    private Collider collider;
    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckPointManager.Instance.SaveCheckPoint(this);
        if (disableOnTrigger)
        {
            collider.enabled = false;
            transform.localScale = Vector3.one * 0.5f;
        }
    }
}
