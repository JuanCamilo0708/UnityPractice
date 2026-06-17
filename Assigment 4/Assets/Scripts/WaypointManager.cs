using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    [SerializeField]
    private List<WaypointScript> _waypoints = new List<WaypointScript>();
    static WaypointManager _instance;
    public static WaypointManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            if (_waypoints.Count == 0)
            {
                _waypoints = transform.GetComponentsInChildren<WaypointScript>().ToList();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public WaypointScript GetWayPoint(int index)
    {
        if (index < _waypoints.Count)
        {
            return _waypoints[index];

        }
        return null;
    }
    public WaypointScript GetRandomWayPoint()
    {
        if (_waypoints.Count == 0)
            return null;
        int randomIndex = Random.Range(0, _waypoints.Count);
        return _waypoints[randomIndex];
    }
    public WaypointScript GetClosestWayPoint(Vector3 position)
    {

        if (_waypoints.Count == 0)
            return null;
        WaypointScript closestWaypoint = null;
        float closestDistance = float.MaxValue;
        foreach (var waypoint in _waypoints)
        {
            float distance = Vector3.SqrMagnitude(waypoint.transform.position - position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestWaypoint = waypoint;
            }
        }
        return closestWaypoint;
    }
    public WaypointScript GetRandomWayPointInRange(Vector3 position, float range)
    {
        float distanceSqr = range * range;
        List<WaypointScript> waypointInRange = new List<WaypointScript>();
        foreach (WaypointScript waypoint in _waypoints)
        {
            if (Vector3.SqrMagnitude(waypoint.transform.position - position) <= distanceSqr)
            {
                waypointInRange.Add(waypoint);
            }
        }
        if (waypointInRange.Count > 0)
        {
            int randomIndex = Random.Range(0, waypointInRange.Count);
            return waypointInRange[randomIndex];
        }
        return null;
    }
}
