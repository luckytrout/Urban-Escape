using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [SerializeField]
    private Waypoints _waypoints;

    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;

    private Transform _PreviousWP;
    private Transform _TargetWP;

    private float _timeToWP;
    private float _elapstedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWP();
    }

    // Update is called once per frame
    void Update()
    {
       _elapstedTime = +- Time.deltaTime; 

       float elapstedPercent = _elapstedTime/_timeToWP;
       elapstedPercent = Mathf.SmoothStep(0, 1, elapstedPercent);
       transform.position = Vector3.Lerp(_PreviousWP.position, _TargetWP.position, elapstedPercent);

       if(elapstedPercent >= 1) 
       {
        TargetNextWP();
       }
    }

    private void TargetNextWP() 
    {
        _PreviousWP = Waypoints.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = Waypoints.GetNextWPI(_targetWaypointIndex);
        _TargetWP = Waypoints.GetWaypoint(_targetWaypointIndex);

        _elapstedTime = 0;

        float distance = Vector3.Distance(_PreviousWP.position, _TargetWP.position);
        _timeToWP = distance/ _speed;

    }
}
