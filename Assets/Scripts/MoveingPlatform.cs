using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _speed;

    private int _targetIndex;
    private Transform _previous;
    private Transform _target;

    private float _timeto;
    private float _elapsed;

    // Start is called before the first frame update
    void Start()
    {
        TargetNext();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsed += Time.deltaTime;

        float elapstedPersent = _elapsed / _timeto;
        elapstedPersent = Mathf.SmoothStep(0, 1, elapstedPersent);
        transform.position = Vector3.Lerp(_previous.position, _target.position, elapstedPersent);
        //transform.rotation = Quarternion.Lerp(_previous.rotation, _target.rotation, elapstedPersent);

        if(elapstedPersent >= 1)
        {
            TargetNext();
        }
    }

    private void TargetNext()
    {
        _previous = _waypointPath.GetWP(_targetIndex);
        _targetIndex = _waypointPath.GetNextWP(_targetIndex);
        _target = _waypointPath.GetWP(_targetIndex);

        _elapsed = 0;

        float _distance = Vector3.Distance(_previous.position, _target.position);
        _timeto = _distance/_speed;
    }

    private void OnTriggerEnter(Collider other) 
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other) 
    {
        other.transform.SetParent(null);
    }
}
