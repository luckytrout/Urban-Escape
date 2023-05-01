using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Attack to waypoint parrent filled with children
*/

public class Waypoints : MonoBehaviour
{
    public Transform GetWaypoint(int waypointIndex) 
    {
        return transform.GetChild(waypointIndex);
    }

    public int GetNextWPI(int currentWPI) 
    {
        int nextWPI = currentWPI + 1;

        if ( nextWPI == transform.childCount) {
            
            nextWPI = 0;
        }

        return nextWPI;
    }
}
