using UnityEngine;
using UnityEngine.AI;

public class Seeking : MonoBehaviour
{
    enum State
    {
        Seek,
        Idle
    }
    public class SeekData
    {
        public const float maxSearchTime = 5f;
        public float searchTime = 0f;
        public Vector3 targetPosition = Vector3.zero;
    }
    private Vector3 _initialPosition;
    [SerializeField]
    private GameObject _targetObject;
    [SerializeField]
    private float _viewDistance = 10f;
    private NavMeshAgent _agent;
    private State _currentState = State.Idle;
    private SeekData _seekData = new SeekData();
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _initialPosition = transform.position;
    }
    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
    private void Update()
    {
        switch (_currentState)
        {
            case State.Seek:
                DoSeek();
                break;
            case State.Idle:
                DoIdle();
                break;
            default:
                break;
        }
    }
    private bool CanSeekTarget()
    {
        if (_targetObject != null)
        {
            Vector3 direction = _targetObject.transform.position - transform.position;
            direction.Normalize();
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, direction, out hitInfo, _viewDistance))
            {
                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.gameObject == _targetObject)
                    {
                        Debug.DrawLine(transform.position, hitInfo.point, Color.green, 1f);
                        return true;
                    }
                }
                Debug.DrawLine(transform.position, hitInfo.point, Color.red, 1f);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + direction * _viewDistance, Color.red, 1f);
            }
        }
        return false;
    }
    private void StartSeek()
    {
        _seekData.targetPosition = _targetObject.transform.position;
        SetDestination(_seekData.targetPosition);
        _currentState = State.Seek;
    }
    private void DoSeek()
    {
        if (!CanSeekTarget())
        {
            _seekData.searchTime -= Time.deltaTime;
            if (_seekData.searchTime <= 0f)
            {
                StartIdle();
            }
            return;
        }
        else
        {
            _seekData.searchTime = SeekData.maxSearchTime;
            _seekData.targetPosition = _targetObject.transform.position;
        }
        SetDestination(_seekData.targetPosition);

    }
    private void StartIdle()
    {
        SetDestination(_initialPosition);
        _currentState = State.Idle;
    }
    private void DoIdle()
    {
        if (CanSeekTarget())
        {
            StartSeek();
            return;
        }

    }
}
