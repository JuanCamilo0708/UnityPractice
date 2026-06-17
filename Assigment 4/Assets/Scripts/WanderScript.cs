using UnityEngine;
using UnityEngine.AI;

public class WanderScript : MonoBehaviour
{

    [SerializeField]
    private float _wanderRadius = 10f;
    private NavMeshAgent _agent;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        SetRandomDirection();
    }
    private void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
        {
            SetRandomDirection();
        }
    }
    private void SetRandomDirection()
    {
        Vector3 randomDirec = Random.insideUnitSphere * _wanderRadius;
        randomDirec += transform.position;
        if (NavMesh.SamplePosition(
                randomDirec,
                out NavMeshHit hit,
                _wanderRadius,
                NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }

    }
}
