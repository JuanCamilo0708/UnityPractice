using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class PatrolScript : MonoBehaviour
{
    enum State
    {
        Patrol,
        Seek
    }
    public class WanderData
    {
        public const float minUpdateTime = 5f;
        public const float maxUpdateTime = 10f;
        public const float moveRange = 5f;

        public float updateTime = 0f;
        public Vector3 centerPoint = Vector3.zero;
        public Vector3 currentPoint = Vector3.zero;
    }
    public class SeekData
    {
        public const float maxSearchTime = 5f;
        public float searchTime = 0f;
        public Vector3 targetPosition = Vector3.zero;
    }
    [SerializeField]
    private GameObject _targetObject;
    [SerializeField]
    private float _viewDistance = 10f;
    private NavMeshAgent _agent;
    private State _currentState = State.Patrol;
    private WanderData _wanderData = new WanderData();
    private SeekData _seekData = new SeekData();
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    public void SetDestination(Vector3 destination)
    {
        _agent.SetDestination(destination);
    }
    private void Update()
    {
        switch (_currentState)
        {
            case State.Patrol:
                DoPatrol();
                break;
            case State.Seek:
                DoSeek();
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
    private void StartPatrol()
    {
        WaypointScript waypoint = WaypointManager.Instance.GetRandomWayPoint();
        _wanderData.currentPoint = waypoint.transform.position;
        _wanderData.updateTime = Random.Range(WanderData.minUpdateTime, WanderData.maxUpdateTime);
        SetDestination(_wanderData.currentPoint);
        _currentState = State.Patrol;
    }
    private void DoPatrol()
    {
        if (CanSeekTarget())
        {
            StartSeek();
            return;
        }
        _wanderData.updateTime -= Time.deltaTime;
        if (_wanderData.updateTime <= 0 || Vector3.SqrMagnitude(transform.position - _wanderData.currentPoint) < 3f)
        {
            StartPatrol();
        }
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
                StartPatrol();
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
}

